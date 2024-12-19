using Api_TikTok.Model;

namespace Api_TikTok.Repository
{
    public interface VideoRepository
    {
        Task<bool> CreateAsync(Video video);
    }
}
