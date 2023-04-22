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
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _dbContext.Messages.Add(message);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessage), new { id = message.Id }, message);
        }

        [HttpGet]
        public async Task<ActionResult<List<Message>>> GetMessages()
        {
            return await _dbContext.Messages.ToListAsync();
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
