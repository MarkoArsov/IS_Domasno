using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Repository.Interface;
using TicketManager.Service.Interface;
using TicketManger.Domain.DomainModels;

namespace TicketManager.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _cartRepository;

        public ShoppingCartService(IShoppingCartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void ClearShoppingCart(Guid? id)
        {
            _cartRepository.ClearShoppingCart(id);
        }

        public ShoppingCart GetShoppingCart(Guid? id)
        {
            return _cartRepository.Get(id);
        }
    }

        
}
