using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_TikTok.Model
{
    [Table("bookmarks")]
    public class Bookmark
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
    }
}
