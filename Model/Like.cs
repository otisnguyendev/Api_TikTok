﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Model
{
    [Table("likes")]
    public class Like
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]  
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Video")]
        [Column("video_id")] 
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}
