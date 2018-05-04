using System.Collections.Generic;
using PizzaAPI.Interfaces.Api;

namespace PizzaAPI.Models.ViewModels
{
    public class PizzaEndpoint : IPizzaEndpoint

    {
        public List<PizzaViewModel> AllPizzas { get; set;  }
        public List<PizzaViewModel> UniquePizzas { get; set; }

        public PizzaEndpoint(List<PizzaViewModel> allPizzas, List<PizzaViewModel> uniquePizzas)
        {
            AllPizzas = allPizzas;
            UniquePizzas = uniquePizzas;
        }

    }
}