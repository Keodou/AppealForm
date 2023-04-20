namespace AppealForm.Domain.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Guid ContactId { get; set; }

        public Guid TopicId { get; set; }
    }
}
