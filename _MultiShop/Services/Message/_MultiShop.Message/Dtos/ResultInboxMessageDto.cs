namespace _MultiShop.Message.Dtos
{
    public class ResultInboxMessageDto
    {
        public int UserMessageID { get; set; }
        public string SendedId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
