using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManger.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

    }
}
