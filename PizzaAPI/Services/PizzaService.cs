using System.Collections.Generic;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Interfaces.Services;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Services
{
    public class PizzaService : IPizzaService
    {
        
        private readonly IPizzaRepository _pizzaRepository;
        public PizzaService(IPizzaRepository repo)
        {
            _pizzaRepository = repo;
        }
        
        public List<PizzaViewModel> GetAllPizzas()
        {
            var allPizzas = _pizzaRepository.GetAllPizzas();
            var pizzaViewModel = new List<PizzaViewModel>();

            foreach (var pizza in allPizzas)
            {
                pizzaViewModel.Add(new PizzaViewModel(pizza));
            }
            
            return pizzaViewModel;
        }
        public List<PizzaViewModel> GetCombinedPizzaViewModels()
        {
            var allPizzas = _pizzaRepository.GroupedByName;
            var pizzaViewModel = new List<PizzaViewModel>();

            foreach (var pizza in allPizzas)
            {
                pizzaViewModel.Add(new PizzaViewModel(pizza));
            }

            return pizzaViewModel;
        }
        public PizzaViewModel GetPizza(int id)
        {
            var pizza = _pizzaRepository.GetPizza(id);
            var vm = new PizzaViewModel(pizza);
            return vm;
        }
        public PizzaViewModel GetPizzaBySizeAndName(string pizzaName, string pizzaSize)
        {
            var pizza = _pizzaRepository.GetPizzaBySizeAndName(pizzaName, pizzaSize);
            var vm = new PizzaViewModel(pizza);
            return vm;
        }
    }
}