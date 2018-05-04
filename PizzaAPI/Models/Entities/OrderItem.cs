using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaAPI.Interfaces.Entities;

namespace PizzaAPI.Models.Entities
{
    public class OrderItem : IOrderItem
    {

        private static readonly List<bool> UsedCounter = new List<bool>();

        private int GetAvailableIndex()
        {
            for (int i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }

            // Nothing available.
            return -1;
        }

        [Key]
        public int OrderItemId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Pizza Pizza { get; set; }

        public virtual List<Topping> AdditionalToppings { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.Currency)]
        public Decimal Price { get; set; } = 0;


        public OrderItem()
        {
            int nextIndex = GetAvailableIndex();
            if (nextIndex == -1)
            {
                nextIndex = UsedCounter.Count;
                UsedCounter.Add(true);
            }

            OrderItemId = nextIndex;
            AdditionalToppings = new List<Topping>();
        }


        public OrderItem(OrderItem orderItem)
        {
            Pizza = orderItem.Pizza;
            OrderItemId = orderItem.OrderItemId;
            UserId = orderItem.UserId;
        }

        public OrderItem(OrderItem orderItem, Order order)
        {
           
            Order = order;
            Pizza = orderItem.Pizza;
        }

    }
}