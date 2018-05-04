using System.Collections.Generic;
using PizzaAPI.Models.Helpers;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Interfaces.Api
{
    interface IPizzaEndpoint
    {

        List<PizzaViewModel> AllPizzas { get; }
        List<PizzaViewModel> UniquePizzas { get; }

    }
}
