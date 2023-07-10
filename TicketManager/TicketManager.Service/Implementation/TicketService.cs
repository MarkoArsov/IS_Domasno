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
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<ShoppingCart> _cartRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public TicketService(
            IRepository<Ticket> ticketRepository, 
            IRepository<ShoppingCart> cartRepository,
            IShoppingCartRepository shoppingCartRepository)
        {
            _ticketRepository = ticketRepository;
            _cartRepository = cartRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void AddToCart(Guid id, Guid userId)
        {
            _shoppingCartRepository.ClearShoppingCart(userId);
            ShoppingCart cart = new ShoppingCart();
            cart.TicketId = id;
            cart.UserId = userId;
            this._cartRepository.Insert(cart);
        }

        public void CreateTicket(Ticket t)
        {
           this._ticketRepository.Insert(t);
        }

        public void DeleteTicket(Guid? id)
        {
            var ticket = this._ticketRepository.Get(id);
            this._ticketRepository.Delete(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return this._ticketRepository.GetAll().ToList();
        }

        public Ticket GetTicket(Guid? id)
        {
            return this._ticketRepository.Get(id);
        }

        public void UpdateTicket(Ticket t)
        {
            this._ticketRepository.Update(t);
        }
    }

        
}
