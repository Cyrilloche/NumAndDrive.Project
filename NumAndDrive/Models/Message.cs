using System.ComponentModel.DataAnnotations.Schema;

namespace NumAndDrive.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageContent { get; set; } = string.Empty;
        public DateTime SendingDate { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string SenderUserId { get; set; } = string.Empty;
        public User SenderUser { get; set; }
        public string ReceiverUserId { get; set; } = string.Empty;
        public User ReceiverUser { get; set; }
    }
}
