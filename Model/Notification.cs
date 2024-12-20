using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Model
{
    [Table("notifications")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Type { get; set; }

        public bool IsRead { get; set; } = false;
    }
}
