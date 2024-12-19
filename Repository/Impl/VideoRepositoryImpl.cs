using Api_TikTok.Data;
using Api_TikTok.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_TikTok.Repository.Impl
{
    public class VideoRepositoryImpl : VideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepositoryImpl(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CreateAsync(Video video)
        {
            _context.Videos.Add(video);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
