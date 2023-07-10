using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManger.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        public int Quantity { get; set; }

        public int getTotalPrice()
        {
            return Ticket.Price * Quantity;
        }

    }
}
