namespace AppealForm.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int ContactId { get; set; }

        public int TopicId { get; set; }
    }
}
