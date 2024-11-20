using Microsoft.EntityFrameworkCore;
using Smartkitchen.API.Models;

namespace Smartkitchen.API.Data
{
    public class SmartKitchenContext : DbContext
    {
        public SmartKitchenContext(DbContextOptions<SmartKitchenContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
