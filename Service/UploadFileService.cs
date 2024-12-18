using Api_TikTok.Dto;

namespace Api_TikTok.Service
{
    public interface UploadFileService
    {
        Task<VideoDto> UploadVideoAsync(IFormFile file, string title, string description, string hashtags, string privacyLevel);
    }
}
