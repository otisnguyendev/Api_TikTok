using Api_TikTok.Dto;
using Api_TikTok.Model;
using Api_TikTok.Repository;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Api_TikTok.Service.Impl
{
    public class VideoServiceImpl : VideoService
    {
        private readonly VideoRepository _videoRepository;

        public VideoServiceImpl(VideoRepository videoRepository)
        {
            _videoRepository = videoRepository ?? throw new ArgumentNullException(nameof(videoRepository));
        }

        public async Task<bool> UploadVideoAsync(int userId, UploadVideoDto request)
        {
            if (request == null || request.VideoFile == null || userId <= 0)
                return false;

            var videoUrl = await SaveFileAsync(request.VideoFile, "videos");

            var video = new Video
            {
                UserId = userId,
                Title = request.Title,
                Description = request.Description,
                Hashtags = request.Hashtags,
                PrivacyLevel = request.PrivacyLevel,
                // VideoUrl = videoUrl
            };

            return await _videoRepository.CreateAsync(video);
        }

        private async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            var uploadsFolder = Path.Combine("wwwroot", folderName);
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/{folderName}/{uniqueFileName}";
        }
    }
}
