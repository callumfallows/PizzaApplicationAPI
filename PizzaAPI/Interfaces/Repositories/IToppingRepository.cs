using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Repositories
{
    public interface IToppingRepository
    {
        List<Topping> GetAllToppings();
        List<Topping> GetToppingBySize(string size);
        Topping GetTopping(int id);
    }
}
