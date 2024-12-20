using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Model
{
    [Table("comments")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public Video Video { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
