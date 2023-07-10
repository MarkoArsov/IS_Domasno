using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManger.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Genre { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public virtual ICollection<ShoppingCart>? ShoppingCarts { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

    }
}
