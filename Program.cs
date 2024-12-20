using Api_TikTok.Repository;
using Api_TikTok.Data;
using Microsoft.EntityFrameworkCore;
using Api_TikTok.Service;
using Api_TikTok.Service.Impl;
using Api_TikTok.Repository.Impl;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Api_TikTok.Chat;
using Api_TikTok.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))
    )
);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 104857600; // 100 MB
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<UserService, UserServiceImpl>();
builder.Services.AddScoped<UserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<VideoService, VideoServiceImpl>();
builder.Services.AddScoped<VideoRepository, VideoRepositoryImpl>();
builder.Services.AddScoped<MessageService, MessageServiceImpl>();
builder.Services.AddScoped<MessageRepository, MessageRepositoryImpl>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Description = "Nhập 'Bearer' [khoảng trắng] và token của bạn",
    });

    c.OperationFilter<AuthorizeOperationFilter>();
});

builder.Services.AddSignalR();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API TikTok");
    });
}
app.MapHub<ChatHub>("/chatHub");

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
