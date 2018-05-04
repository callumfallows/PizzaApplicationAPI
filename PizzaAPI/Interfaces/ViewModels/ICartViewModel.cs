using System.Collections.Generic;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Interfaces.ViewModels
{
    public interface ICartViewModel
    {
        Order Order { get; set; }
        decimal TotalPrice { get; set; }
         string VoucherCode { get; set; }
    }
}
