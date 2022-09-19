using Customer.Repository.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repository
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }

        public DbSet<UserEntity> Users { get; set; }
    }
}
