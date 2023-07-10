using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManger.Domain.DomainModels;

namespace TicketManager.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();

        Ticket GetTicket(Guid? id);

        void CreateTicket(Ticket t);

        void UpdateTicket(Ticket t);

        void DeleteTicket(Guid? id);

        void AddToCart(Guid id, Guid userId);
    }
}
