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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }

        public Order Get(Guid id)
        {
            return entities.Include(x=>x.Ticket).Single(x => x.Id == id);
        }

        public List<Order> GetAll(Guid? userId)
        {
            return entities.Include(x => x.Ticket).Where(x => x.UserId == userId).ToList();
        }
    }
}
