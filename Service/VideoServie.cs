using Api_TikTok.Dto;
using Api_TikTok.Model;

namespace Api_TikTok.Service
{
    public interface VideoService
    {
        Task<bool> UploadVideoAsync(int userId, UploadVideoDto request);
    }
}
