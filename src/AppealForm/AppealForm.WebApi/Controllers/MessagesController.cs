using AppealForm.DAL.Data;
using AppealForm.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppealForm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly AppealFormDbContext _dbContext;

        public MessagesController(AppealFormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(MessageDTO messageDTO)
        {
            var contact = await _dbContext.Contacts
                .FirstOrDefaultAsync(c => c.Email == messageDTO.ContactEmail 
                    && c.Phone == messageDTO.ContactPhone);
            var topic = await _dbContext.Topics
                .FirstOrDefaultAsync(c => c.Name == messageDTO.TopicName);

            if (contact != null && topic != null)
            {
                var newMessage = new Message
                {
                    Text = messageDTO.Text,
                    Contact = contact,
                    Topic = topic
                };
                _dbContext.Messages.Add(newMessage);
                await _dbContext.SaveChangesAsync();
                return Ok(newMessage);
            }
            else
            {
                var newContact = new Contact
                {
                    Name = messageDTO.ContactName,
                    Email = messageDTO.ContactEmail,
                    Phone = messageDTO.ContactPhone
                };
                var message = new Message
                {
                    Text = messageDTO.Text,
                    Contact = newContact,
                    Topic = topic
                };

                _dbContext.Contacts.Add(newContact);
                _dbContext.Messages.Add(message);

                await _dbContext.SaveChangesAsync();
                return Ok(message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var message = await _dbContext.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }
    }
}
