using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Dto
{
    public class VideoDto
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string Hashtags { get; set; }
        //public string VideoUrl { get; set; }
        public string PrivacyLevel { get; set; }
    }
}
