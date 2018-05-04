using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order Get(int id);
        void Add(Order order);
        void Delete(Order order);
    }
}
