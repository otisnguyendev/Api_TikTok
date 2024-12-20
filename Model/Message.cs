using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_TikTok.Model
{
    [Table("messages")]
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public int SenderUserId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverUserId { get; set; }
        public User Receiver { get; set; }

        public string Content { get; set; }

        public MessageType MessageType { get; set; } 
    }

    public enum MessageType
    {
        Text,
        Image,
        Video,
        File
    }
}
