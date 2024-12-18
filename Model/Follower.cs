using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Model
{
    [Table("followers")]
    public class Follower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("FollowerUser")]
        public int FollowerUserId { get; set; }
        public User FollowerUser { get; set; }  // Người theo dõi

        [ForeignKey("FollowingUser")]
        public int FollowingUserId { get; set; }
        public User FollowingUser { get; set; }  // Người được theo dõi

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
