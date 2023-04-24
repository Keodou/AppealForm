namespace AppealForm.Domain.Models
{
    public class ContactDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
