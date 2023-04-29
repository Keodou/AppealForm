using AppealForm.DAL.Data;
using AppealForm.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;

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
                .FirstOrDefaultAsync(c => c.Name == messageDTO.ContactName
                    && c.Email == messageDTO.ContactEmail
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
                //return CreatedAtAction(nameof(GetMessage), new { id = message.Id }, message);
                return Ok(message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageDTO>>> GetMessages()
        {
            var messages = await _dbContext.Messages
                .Include(m => m.Contact)
                .Include(m => m.Topic)
                .Select(m => new MessageDTO
                {
                    ContactName = m.Contact.Name,
                    ContactEmail = m.Contact.Email,
                    ContactPhone = m.Contact.Phone,
                    TopicName = m.Topic.Name,
                    Text = m.Text
                })
                .ToListAsync();

            //return Ok(JsonSerializer.Serialize(messages));
            return Ok(JsonConvert.SerializeObject(messages));
        }

        [HttpGet("{contactId}/messages")]
        public async Task<IActionResult> GetMessagesByContactId(int contactId)
        {
            var messages = await _dbContext.Messages.Where(m => m.ContactId == contactId).ToListAsync();
            return Ok(messages);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.Id)
            {
                return BadRequest("Message not found.");
            }
            _dbContext.Entry(message).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _dbContext.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _dbContext.Messages.Remove(message);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageItemExists(int id)
        {
            return _dbContext.Messages.Any(m => m.Id == id);
        }
    }
}
