using System.Collections.Generic;
using PizzaAPI.Interfaces.Entities;

namespace PizzaAPI.Interfaces.ViewModels
{
    public interface IOrderItemViewModel
    {
        IPizzaViewModel Pizza { get; set; }
        List<IToppingViewModel> AdditionalToppings { get; set; }
        int OrderItemId { get; set; }
        decimal Price { get; set; }
        string UserId { get; set; }

    }
}
