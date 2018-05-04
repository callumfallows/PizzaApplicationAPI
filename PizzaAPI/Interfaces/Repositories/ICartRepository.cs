using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Repositories
{
    public interface ICartRepository
    {
        List<OrderItem> GetAll();
        OrderItem Get(int id);
        void Add(OrderItem orderItem);
        void Delete(OrderItem orderItem);
    }
}
