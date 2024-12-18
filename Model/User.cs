using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        //[MaxLength(255)]
        //public string AvatarUrl { get; set; }


        // Các mối quan hệ khác
        public ICollection<Video> Videos { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Follower> Followers { get; set; } 
        public ICollection<Follower> Following { get; set; } 
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; }
    }
}
