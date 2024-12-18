using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Dto
{
    public class RegisterDto
    {
        [MaxLength(255)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
