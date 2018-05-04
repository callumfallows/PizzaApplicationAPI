using PizzaAPI.Interfaces.Entities;
using PizzaAPI.Interfaces.ViewModels;

namespace PizzaAPI.Models.ViewModels
{
    public class ToppingViewModel : IToppingViewModel
    {
        public ToppingViewModel(ITopping topping)
        {
            ToppingId = topping.Id;
            Name = topping.Name;
            Size = topping.Size;
            Price = topping.Price;
        }

        public int ToppingId { get; set; }

        public string Name { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }
        
    }
}