using Domain.Migrations;
using Domain.Order;
using Domain.Security;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Customer.Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Domain.Order.Invoice> Invoice { get; set; }
        public DbSet<Domain.Order.Order> Order { get; set; }
        public DbSet<Domain.Order.OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {

            base.OnModelCreating(builder);
        }    

    }
}
