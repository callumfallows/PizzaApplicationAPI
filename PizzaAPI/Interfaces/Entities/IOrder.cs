using System;
using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Entities
{
    public interface IOrder
    {
        int OrderId { get; }
        List<OrderItem> OrderItems { get; set; }
        string UserId { get; set; }
        decimal Price { get; set; }
        decimal Discount { get; set; }
        string CurrentVoucher { get; set; }
        bool Delivery { get; set; }
    }
}
