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
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IOrderRepository _orderRepo;

        public OrderService(IRepository<Order> orderRepository, IOrderRepository orderRepo)
        {
            _orderRepository = orderRepository;
            _orderRepo = orderRepo;
        }

        public void Create(Order order)
        {
            _orderRepository.Insert(order);
        }

        public List<Order> GetAll(Guid? userId)
        {
            return _orderRepo.GetAll(userId);
        }
    }

        
}
