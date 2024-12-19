using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Dto
{
    public class UploadVideoDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Hashtags { get; set; }

        [Required]
        public string PrivacyLevel { get; set; } = "public";

        [Required]
        public IFormFile VideoFile { get; set; }
    }
}
