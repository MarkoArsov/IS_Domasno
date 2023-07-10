using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketManger.Domain.DomainModels;
using TicketManger.Domain.Identity;

namespace TicketManager.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ShoppingCart>()
                .HasOne(c => c.Ticket)
                .WithMany(c => c.ShoppingCarts)
                .HasForeignKey(c => c.TicketId);

            builder.Entity<Order>()
                .HasOne(c => c.Ticket)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.TicketId);

        }

    }
}