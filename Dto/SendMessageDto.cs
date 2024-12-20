using Api_TikTok.Model;

namespace Api_TikTok.Dto
{
    public class SendMessageDto
    {
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public string Content { get; set; }
        public MessageType MessageType { get; set; }
    }
}
