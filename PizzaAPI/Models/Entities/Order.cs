using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaAPI.Interfaces.Entities;

namespace PizzaAPI.Models.Entities
{
    public class Order : IOrder
    {
        public Order() { }

        private decimal TotalPrice { get; set; }

        public Order(Order order)
        {
            if (order != null)
            {
                List<OrderItem> orderItems = new List<OrderItem>();

                if (order.OrderItems != null)
                {
                    foreach (OrderItem item in order.OrderItems)
                    {
                        item.UserId = order.UserId;
                        TotalPrice += item.Price;
                        orderItems.Add(item);
                      
                    }
                }

                UserId = order.UserId;
                OrderItems = orderItems;
                Discount = order.Discount;
                Price = TotalPrice;
                CurrentVoucher = order.CurrentVoucher;
                Delivery = order.Delivery;
            }
            else
            {
                OrderItems = new List<OrderItem>();
            }
        }

        [Key]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string CurrentVoucher { get; set; }
        public bool Delivery { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}