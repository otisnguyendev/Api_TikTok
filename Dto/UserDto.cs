using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}
