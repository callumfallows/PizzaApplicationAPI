using System;
using System.Collections.Generic;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Entities
{
    public interface IOrderItem
    {
        Order Order { get; set; }
        Pizza Pizza { get; set; }
        List<Topping> AdditionalToppings { get; set; }
        string UserId { get; set; }
        decimal Price { get; set; }
    }
}
