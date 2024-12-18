using Api_TikTok.Model;

namespace Api_TikTok.Repository
{
    public interface UploadFileRepository
    {
        Task<Video> SaveVideoAsync(Video video);

    }
}
