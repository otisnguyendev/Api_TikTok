using Api_TikTok.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_TikTok.Controller
{
    [Route("api/upload-file")]
    [RequestSizeLimit(104857600)]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly UploadFileService _uploadFileService;

        public UploadFileController(UploadFileService uploadFileService)
        {
            _uploadFileService = uploadFileService;
        }

        [Authorize]
        [HttpPost("upload-video")]
        public async Task<IActionResult> UploadVideo(IFormFile file, [FromForm] string title, [FromForm] string description, [FromForm] string hashtags, [FromForm] string privacyLevel)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is not selected.");
            }

            var result = await _uploadFileService.UploadVideoAsync(file, title, description, hashtags, privacyLevel);

            if (result == null)
            {
                return StatusCode(500, "Error uploading the video.");
            }

            return Ok(result);
        }
    }
}
