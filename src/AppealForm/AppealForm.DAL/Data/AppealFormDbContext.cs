using AppealForm.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AppealForm.DAL.Data
{
    public class AppealFormDbContext : DbContext
    {
        public AppealFormDbContext(DbContextOptions<AppealFormDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
