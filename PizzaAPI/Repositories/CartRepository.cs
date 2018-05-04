using System;
using System.Collections.Generic;
using System.Linq;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Models;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly PizzaOrderContext _db = new PizzaOrderContext();
        public List<OrderItem> GetAll()
        {
            var unitOfWork = new UnitOfWork(_db);

            try
            {
                var entities = unitOfWork.CartRepository.Entities;
                var orderItems = new List<OrderItem>(entities);
                return orderItems;
            }
            catch (Exception e)
            {
                return new List<OrderItem>();
            }
        }
        public OrderItem Get(int id)
        {
            var unitOfWork = new UnitOfWork(_db);
            var orderItem = unitOfWork.CartRepository.Get(id);
            return orderItem;
        }
        public void Add(OrderItem orderItem)
        {
            var unitOfWork = new UnitOfWork(_db);
            unitOfWork.CartRepository.Add(orderItem);
        }
        public void Delete(OrderItem orderItem)
        {
            var unitOfWork = new UnitOfWork(_db);
            unitOfWork.CartRepository.Remove(orderItem);
        }
    }
}