namespace NotificationsService.Services
{
    public class RabbitMessage
    {
        public int SenderID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
