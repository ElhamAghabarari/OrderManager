using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagment.Application.Model;

namespace OrderManagment.Infrastructure
{
    public class OrderDbContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // order
            modelBuilder.Entity<Order>().HasKey(item => item.Id);

            modelBuilder.Entity<Order>().Property(t => t.Name).IsRequired();

            modelBuilder.Entity<Order>().Property(t => t.CustomerId).IsRequired();

            // customer
            modelBuilder.Entity<Customer>().HasKey(item => item.Id);

            modelBuilder.Entity<Customer>().Property(t => t.Name).IsRequired();
        }

        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
