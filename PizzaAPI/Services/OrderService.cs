using System;
using System.Collections.Generic;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Interfaces.Services;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Services
{
    public class OrderService : IOrderService
    {
        
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository repo)
        {
            _orderRepository = repo;
        }
        public List<Order> GetAllOrdersByUserId(string userId)
        {
            var allOrders = _orderRepository.GetAll();
            var ordersByUserId = allOrders.FindAll(x => x.UserId == userId);
            return ordersByUserId;
        }
        public void AddNewOrder(Order order)
        {
            _orderRepository.Add(order);
        }
    }
}