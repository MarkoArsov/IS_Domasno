using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManger.Domain.DomainModels;

namespace TicketManager.Service.Interface
{
    public interface IShoppingCartService
    {

        ShoppingCart GetShoppingCart(Guid? id);
        void ClearShoppingCart(Guid? id);
    }
}
