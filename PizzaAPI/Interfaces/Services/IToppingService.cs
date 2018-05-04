using System.Collections.Generic;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Interfaces.Services
{
    public interface IToppingService
    {

        List<ToppingViewModel> GetAllToppings();
        List<ToppingViewModel> GetToppingsBySize(string size);
    }

}
