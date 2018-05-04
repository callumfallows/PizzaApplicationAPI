using System;
using System.Collections.Generic;
using System.Linq;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Models;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaOrderContext _db = new PizzaOrderContext();
        public List<Order> GetAll()
        {
            var unitOfWork = new UnitOfWork(_db);

            try
            {
                var entities = unitOfWork.OrderRepository.Entities;
                var orders = new List<Order>(entities);
                return orders;
            }
            catch (Exception e)
            {
                return new List<Order>();
            }
        }
        public Order Get(int id)
        {
            var unitOfWork = new UnitOfWork(_db);
            var order = unitOfWork.OrderRepository.Get(id);
            return order;
        }
        public void Add(Order order)
        {
            var unitOfWork = new UnitOfWork(_db);
            unitOfWork.OrderRepository.Add(order);
            unitOfWork.Commit();
        }
        public void Delete(Order order)
        {
            var unitOfWork = new UnitOfWork(_db);
            unitOfWork.OrderRepository.Remove(order);
        }
    }
}