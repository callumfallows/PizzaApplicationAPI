using System;
using System.Collections.Generic;
using PizzaAPI.Interfaces.Entities;
using PizzaAPI.Interfaces.ViewModels;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Models.ViewModels
{
    public class PizzaViewModel : IPizzaViewModel
    {
        public bool IsValid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public List<ToppingViewModel> Toppings { get; set; }
        public List<ToppingViewModel> SetToppings(List<Topping> toppings)
        {

            var toppingViewModel = new List<ToppingViewModel>();
            if (toppings == null)
            {
                return toppingViewModel;
            }

            foreach (var topping in toppings)
            {
                toppingViewModel.Add(new ToppingViewModel(topping));
            }

            return toppingViewModel;
        }
        public List<ToppingViewModel> SetExtraToppings(List<Topping> toppings)
        {

            var toppingViewModel = new List<ToppingViewModel>();
            if (toppings == null)
            {
                return toppingViewModel;
            }

            foreach (var topping in toppings)
            {
                toppingViewModel.Add(new ToppingViewModel(topping));
            }

            return toppingViewModel;
        }
        public PizzaViewModel(IPizza pizza)
        {
            if (pizza == null)
            {
                IsValid = false;
                return;
            }

            IsValid = true;
            Id = pizza.Id;
            Name = pizza.Name;
            Size = pizza.Size;
            Price = pizza.Price;
            Toppings = SetToppings(pizza.Toppings);
        }
       
        private sealed class NameEqualityComparer : IEqualityComparer<Pizza>
        {
            public bool Equals(Pizza x, Pizza y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(Pizza obj)
            {
                return (obj.Name != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Name) : 0);
            }
        }
        public static IEqualityComparer<Pizza> NameComparer { get; } = new NameEqualityComparer();

    }
}