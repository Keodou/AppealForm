using AppealForm.DAL.Data;
using AppealForm.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppealForm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly AppealFormDbContext _dbContext;

        public ContactsController(AppealFormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();

            return Ok(contact.Id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            return await _dbContext.Contacts.ToListAsync();
        }
    }
}
