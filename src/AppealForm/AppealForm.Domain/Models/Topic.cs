﻿namespace AppealForm.Domain.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
