using Api_TikTok.Dto;
using Api_TikTok.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api_TikTok.Controller
{
    [Route("api/videos")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly VideoService _videoService;

        public VideoController(VideoService videoService)
        {
            _videoService = videoService ?? throw new ArgumentNullException(nameof(videoService));
        }

        [Authorize]
        [RequestSizeLimit(104857600)]
        [HttpPost("upload")]
        public async Task<IActionResult> UploadVideo([FromForm] UploadVideoDto request)
        {
            var userId = GetUserIdFromClaims();
            if (userId <= 0)
                return Unauthorized(new { Message = "Invalid user" });

            var result = await _videoService.UploadVideoAsync(userId, request);
            if (!result)
                return BadRequest(new { Message = "Video upload failed" });

            return Ok(new { Message = "Video uploaded successfully" });
        }

        private int GetUserIdFromClaims()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
            }
            return 0;
        }
    }
}
