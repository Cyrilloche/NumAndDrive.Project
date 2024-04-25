namespace NumAndDrive.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageContent { get; set; } = string.Empty;
        public DateTime SendingDate { get; set; }
        public DateTime ReceiptDate { get; set; }

        public int SenderUserId { get; set; }
        public User SenderUser { get; set; }
        public int ReceiverUserId { get; set; }
        public User ReceiverUser { get; set; }
    }
}
