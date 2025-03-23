using _MultiShop.Message.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace _MultiShop.Message.DAL.Context
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {

        }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
