using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaAPI.Interfaces.Entities;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Services
{
    public interface ICartService
    {
        Order ResetCart();
        void AddNewItem(Pizza pizza, List<Topping> toppings, Order order);
        void Remove(OrderItem orderItem, IOrder order);
    }
}
