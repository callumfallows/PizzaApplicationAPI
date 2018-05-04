using System.Collections.Generic;

namespace PizzaAPI.Interfaces.ViewModels
{
    public interface ICombinedPizzaViewModel
    {
        string Name { get; }
        List<ICombinedPizzaViewModel> Pizzas { get; }
    };
}
