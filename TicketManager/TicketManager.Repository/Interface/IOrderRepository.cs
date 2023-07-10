using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManger.Domain;
using TicketManger.Domain.DomainModels;

namespace TicketManager.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAll(Guid? userId);

        Order Get(Guid id);
    }
}
