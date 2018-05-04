using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Services
{
   public interface IOrderService
    {
        List<Order> GetAllOrdersByUserId(string userId);
        void AddNewOrder(Order order);
    }
}
