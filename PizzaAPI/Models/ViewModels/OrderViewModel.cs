using System.Collections.Generic;
using PizzaAPI.Interfaces.Entities;

namespace PizzaAPI.Models.ViewModels
{
    public class OrderViewModel
    {
        private decimal TotalPrice { get; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public string UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string CurrentVoucher { get; set; }
        public bool Delivery { get; set; }
        public OrderViewModel(IOrder order)
        {
            UserId = order.UserId;
            CurrentVoucher = order.CurrentVoucher;
            Delivery = order.Delivery;
            OrderItems = new List<OrderItemViewModel>();
           
            if (order.OrderItems == null)
            return;

            foreach (var orderItem in order.OrderItems)
            {
               TotalPrice += orderItem.Price;
               OrderItems.Add(new OrderItemViewModel(orderItem));
            }

            Price = TotalPrice;
        }
    }
}