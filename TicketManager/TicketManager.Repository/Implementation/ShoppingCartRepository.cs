using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Repository.Interface;
using TicketManger.Domain;
using TicketManger.Domain.DomainModels;

namespace TicketManager.Repository.Implementation
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShoppingCart> entities;
        string errorMessage = string.Empty;

        public ShoppingCartRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ShoppingCart>();
        }

        public void ClearShoppingCart(Guid? id)
        {
            entities.RemoveRange(entities.Where(e => e.UserId == id));
        }

        public ShoppingCart Get(Guid? id)
        {
            return entities.Include(x => x.Ticket).Where(x => x.UserId == id).First();
        }
    }
}
