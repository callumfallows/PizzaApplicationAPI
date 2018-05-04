using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Entities
{
    public interface ITopping
    {
        int Id { get; set; }
        string Name { get; set; }
        string Size { get; set;  }
        decimal Price { get; set; }
        List<Pizza> Pizza { get; set; }
    }
}
