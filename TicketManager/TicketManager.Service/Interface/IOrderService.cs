using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManger.Domain.DomainModels;

namespace TicketManager.Service.Interface
{
    public interface IOrderService
    {

        void Create(Order order);

        List<Order> GetAll(Guid? userId);

    }
}
