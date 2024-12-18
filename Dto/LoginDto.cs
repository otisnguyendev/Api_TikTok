using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Dto
{
    public class LoginDto
    {
        [MaxLength(255)]

        public string Email { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }

    }
}
