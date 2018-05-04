using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Entities
{
    public interface IPizza
    {
         int Id { get; set;  }
         string Name { get; set; }
         string Size { get; set; }
         decimal Price { get; set; }
         List<Topping> Toppings { get; set; }
    }
}
