//using Api_TikTok.Dto;
//using Api_TikTok.Repository;

//namespace Api_TikTok.Service.Impl
//{
//    public class VideoServiceImpl : VideoService
//    {
//        private readonly VideoRepository _videoRepository;

//        public VideoServiceImpl(VideoRepository videoRepository)
//        {
//            _videoRepository = videoRepository;
//        }

//        public async Task<IEnumerable<VideoDto>> GetUserVideosAsync(int userId)
//        {
//            var videos = await _videoRepository.GetVideosByUserAsync(userId);
//            return videos.Select(v => new VideoDto
//            {
//                Id = v.Id,
//                Title = v.Title,
//                Description = v.Description,
//                Hashtags = v.Hashtags,
//                PrivacyLevel = v.PrivacyLevel
//            });
//        }

//        public async Task<IEnumerable<VideoDto>> GetPublicVideosAsync()
//        {
//            var videos = await _videoRepository.GetPublicVideosAsync();
//            return videos.Select(v => new VideoDto
//            {
//                Id = v.Id,
//                Title = v.Title,
//                Description = v.Description,
//                Hashtags = v.Hashtags,
//                PrivacyLevel = v.PrivacyLevel
//            });
//        }
//    }

//}
