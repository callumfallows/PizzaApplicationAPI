using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaAPI.Interfaces.Entities;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Services
{
    public interface IVoucherService
    {
        Voucher CalculateTotalDiscount(Order order, Voucher voucher);
    }
}
