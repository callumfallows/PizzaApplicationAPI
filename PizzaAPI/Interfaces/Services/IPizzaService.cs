using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaAPI.Interfaces.ViewModels;
using PizzaAPI.Models.Helpers;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Interfaces.Services
{
   public interface IPizzaService
    {

        List<PizzaViewModel> GetAllPizzas();
        List<PizzaViewModel> GetCombinedPizzaViewModels();
        PizzaViewModel GetPizza(int id);

    }
}
