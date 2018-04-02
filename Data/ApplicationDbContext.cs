using Microsoft.EntityFrameworkCore;
using Vue2Spa.Models;

namespace Vue2Spa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Items> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Orders> Orders { get; set; }

    }
}
