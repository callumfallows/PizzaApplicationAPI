using System.Collections.Generic;
using PizzaAPI.Interfaces.ViewModels;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Models.ViewModels
{
    public sealed class OrderItemViewModel : IOrderItemViewModel
    { 
        public IPizzaViewModel Pizza { get; set; }
        public int OrderItemId { get; set; }
        public decimal Price { get; set; }
        public List<IToppingViewModel> AdditionalToppings { get; set; }
        public string UserId { get; set; }
        private static readonly List<bool> UsedCounter = new List<bool>();

        private static int GetAvailableIndex()
        {
            for (var i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }
            return -1;
        }
        public OrderItemViewModel()
        {
            int nextIndex = GetAvailableIndex();
            if (nextIndex == -1)
            {
                nextIndex = UsedCounter.Count;
                UsedCounter.Add(true);
            }

            OrderItemId = nextIndex;
        }
        
        public OrderItemViewModel(OrderItem orderItem)
        {
            var extraToppings = new List<IToppingViewModel>();

            if (orderItem.AdditionalToppings != null)
            {
                foreach (var topping in orderItem.AdditionalToppings)
                {
                    extraToppings.Add(new ToppingViewModel(topping));
                }
                AdditionalToppings = extraToppings;
            }

            OrderItemId = orderItem.OrderItemId;
            Pizza = new PizzaViewModel(orderItem.Pizza);
            UserId = orderItem.UserId;
            Price = orderItem.Price;
        }


    }
}