using System.Collections.Generic;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Interfaces.ViewModels
{
    public interface IPizzaViewModel
    {
        
        bool IsValid { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Size { get; set; }
        decimal Price { get; set; }

        List<ToppingViewModel> Toppings { get; set; }
        List<ToppingViewModel> SetToppings(List<Topping> toppings);
    }
}
    