using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Repositories
{
    public interface IPizzaRepository
    {
        List<Pizza> GetAllPizzas();
        Pizza GetPizza(int id);
        Pizza GetPizzaBySizeAndName(string pizzaName, string size);
        List<Pizza> AllPizzas { get; }
        List<Pizza> GroupedByName { get; }
    }
}
