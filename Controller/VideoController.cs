//using Api_TikTok.Service;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Api_TikTok.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class VideoController : ControllerBase

//    {
//        public readonly VideoService _videoService;

//        public VideoService(VideoService videoService)
//        {
//            _videoService = videoService;
//        }

//        [HttpGet("user-videos/{userId}")]
//        public async Task<IActionResult> GetUserVideos(int userId)
//        {
//            var videos = await _videoService.GetUserVideosAsync(userId);
//            return Ok(videos);
//        }

//        [HttpGet("public-videos")]
//        public async Task<IActionResult> GetPublicVideos()
//        {
//            var videos = await _videoService.GetPublicVideosAsync();
//            return Ok(videos);
//        }

//    }
//}
