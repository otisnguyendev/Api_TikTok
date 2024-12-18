using Api_TikTok.Data;
using Api_TikTok.Model;

namespace Api_TikTok.Repository.Impl
{
    public class UploadFileRepositoryImpl : UploadFileRepository
    {
        private readonly AppDbContext _context;

        public UploadFileRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Video> SaveVideoAsync(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
            return video;
        }
    }
}
