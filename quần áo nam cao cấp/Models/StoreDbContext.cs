using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using quần_áo_nam_cao_cấp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace quần_áo_nam_cao_cấp.Models
{
    public class StoreDbContext :  DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
        {
        }
        private string connectionStrings;

        public StoreDbContext(): base()
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsetting.json", optional: false);

            var configuration = builder.Build();

            connectionStrings = configuration.GetConnectionString("MyConection").ToString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }

        public virtual DbSet<Detail> details { get; set; }
        public virtual DbSet<Order> orders { get; set; }
        public virtual DbSet<Cart> carts { get; set; }
        public virtual DbSet<Customer> customers { get; set; }
        public virtual DbSet<Product> products { get; set; }
    }
   
    }
