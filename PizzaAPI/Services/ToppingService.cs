using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Interfaces.Services;
using PizzaAPI.Interfaces.ViewModels;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.Helpers;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Services
{

    public class ToppingService : IToppingService
    {
        
        private readonly IToppingRepository _toppingRepository;
        public ToppingService(IToppingRepository repo)
        {
            _toppingRepository = repo;
        }
        public List<ToppingViewModel> GetAllToppings()
        {
            var allToppings = _toppingRepository.GetAllToppings();
            var toppingViewModels = new List<ToppingViewModel>();

            foreach (var topping in allToppings)
            {
                toppingViewModels.Add(new ToppingViewModel(topping));
            }
            
            return toppingViewModels;
        }
        public List<ToppingViewModel> GetToppingsBySize(string size)
        {
            var combinedToppingBySize = _toppingRepository.GetToppingBySize(size);
            var toppingViewModel = new List<ToppingViewModel>();

            foreach (var topping in combinedToppingBySize)
            {
                toppingViewModel.Add(new ToppingViewModel(topping));
            }

            return toppingViewModel;
        }
        public ToppingViewModel GetToppingsById(int id)
        {
            var topping = _toppingRepository.GetTopping(id);
            var toppingViewModel = new ToppingViewModel(topping);
            return toppingViewModel;
        }

        public List<ToppingViewModel> GetMultipleToppingsById(List<int> toppingIds)
        {
            var parsedList = new List<ToppingViewModel>();

            foreach (var id in toppingIds)
            {
                parsedList.Add(GetToppingsById(id));
            }

            return parsedList;
        }
    }

}