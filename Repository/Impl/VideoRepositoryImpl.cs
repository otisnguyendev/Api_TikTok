using Api_TikTok.Data;
using Api_TikTok.Model;

namespace Api_TikTok.Repository.Impl
{
    public class VideoRepositoryImpl : VideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task<bool> CreateAsync(Video video)
        {
            _context.Videos.Add(video);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
