using System.Security.Claims;
using Api_TikTok.Dto;
using Api_TikTok.Model;
using Api_TikTok.Repository;

namespace Api_TikTok.Service.Impl
{
    public class UploadFileServiceImpl : UploadFileService
    {
        private readonly UploadFileRepository _uploadFileRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UploadFileServiceImpl(UploadFileRepository uploadFileRepository, IHttpContextAccessor httpContextAccessor)
        {
            _uploadFileRepository = uploadFileRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<VideoDto> UploadVideoAsync(IFormFile file, string title, string description, string hashtags, string privacyLevel)
        {
            var userId = GetUserId();

            if (userId == null)
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            var allowedExtensions = new[] { ".mp4", ".png", ".mov", ".mkv" }; 
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new ArgumentException("File type is not supported. Only video files are allowed.");
            }

            var filePath = Path.Combine("uploads/videos", file.FileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var video = new Video
            {
                UserId = userId.Value,
                Title = title,
                Description = description,
                Hashtags = hashtags,
                PrivacyLevel = privacyLevel,
                VideoUrl = filePath
            };

            var savedVideo = await _uploadFileRepository.SaveVideoAsync(video);

            return new VideoDto
            {
                Id = savedVideo.Id,
                Title = savedVideo.Title,
                Description = savedVideo.Description,
                Hashtags = savedVideo.Hashtags,
                //VideoUrl = savedVideo.VideoUrl,
                PrivacyLevel = savedVideo.PrivacyLevel
            };
        }

        private int? GetUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : null;
        }

    }
}
