using System.Collections.Generic;
using PizzaAPI.Interfaces.ViewModels;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Models.ViewModels
{
    public class CartViewModel : ICartViewModel
    {
       

        public Pizza Pizza { get; set; }
        public Order Order { get; set; }
        public List<Topping> AdditionalToppings { get; set; }
        public OrderItem OrderItem { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Delivery { get; set; }
        public string VoucherCode { get; set; }
        
    }
}