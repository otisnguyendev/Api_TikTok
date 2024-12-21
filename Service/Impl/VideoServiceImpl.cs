using Api_TikTok.Data;
using Api_TikTok.Dto;
using Api_TikTok.Model;
using Api_TikTok.Repository;

namespace Api_TikTok.Service.Impl
{
    public class VideoServiceImpl : VideoService
    {
        private readonly VideoRepository _videoRepository;
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public VideoServiceImpl(VideoRepository videoRepository, IConfiguration configuration, UserRepository userRepository)
        {
            _userRepository = userRepository;
            _videoRepository = videoRepository ?? throw new ArgumentNullException(nameof(videoRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> UploadVideoAsync(int userId, UploadVideoDto request)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return false;

            if (request.Video != null)
            {
                var videoUrl = await SaveFileAsync(request.Video, "videos");

                var video = new Video
                {
                    UserId = userId,
                    Title = request.Title,
                    Description = request.Description,
                    Hashtags = request.Hashtags,
                    PrivacyLevel = request.PrivacyLevel.ToString(),  
                    VideoUrl = videoUrl
                };

                await _videoRepository.CreateAsync(video);
                return true;
            }

            return false;
        }



        private async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            var uploadsFolder = Path.Combine("wwwroot", folderName);
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/{folderName}/{uniqueFileName}";  
        }

    }
}
