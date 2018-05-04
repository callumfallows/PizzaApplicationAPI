using System.Linq;
using PizzaAPI.Interfaces.Services;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Services
{
    public class VoucherService : IVoucherService
    {
        public Voucher CalculateTotalDiscount(Order order, Voucher voucher)
        {
            
            var _voucher = voucher;
            var _order = order;

            switch (_voucher.VoucherName)
            {
                case "2FOR1TUE":
                    if (_order.OrderItems.Count(o => o.Pizza.Size == "medium" || o.Pizza.Size == "large") == 2)
                    {
                        decimal lowestCost = _order.OrderItems.Min(o => o.Price);
                        _voucher.Discount = lowestCost;
                    }
                    break;
                case "3FOR2THUR":
                    //TODO SHOULD THIS BE EQUAL TO 3 OR GREATER THAN, CHECK RULES
                    if (_order.OrderItems.Count(o => o.Pizza.Size == "medium") >= 3)
                    {
                        decimal lowestCost = _order.OrderItems.Min(o => o.Price);
                        _voucher.Discount = lowestCost;
                    }
                    break;
                case "FAMFRIDAYCOLL":
                    if (_order.OrderItems.Count(o => o.Pizza.Size == "medium" && o.Pizza.Name != "Create Your Own") ==
                        4 &&
                        !_order.Delivery)
                    {
                        decimal total = _order.OrderItems.Sum(o => o.Price);

                        var discount = total - 30;
                        _voucher.Discount = discount;

                    }
                    break;
                case "2LARGECOLL":
                    if (_order.OrderItems.Count(o => o.Pizza.Size == "large" && o.Pizza.Name != "Create Your Own") == 2 &&
                        !_order.Delivery)
                    {
                        decimal total = _order.OrderItems.Sum(o => o.Price);

                        var discount = total - 25;

                        _voucher.Discount = discount;
                    }
                    break;
                case "2MEDIUMCOLL":
                    if (_order.OrderItems.Count(o => o.Pizza.Size == "medium" && o.Pizza.Name != "Create Your Own") == 2 &&
                        !_order.Delivery)
                    {
                        decimal total = _order.OrderItems.Sum(o => o.Price);

                        var discount = total - 25;
                        _voucher.Discount = discount;
                    }
                    break;
                case "2SMALLCOLL":
                    if (_order.OrderItems.Count(o => o.Pizza.Size == "small" && o.Pizza.Name != "Create Your Own") == 2 &&
                        !_order.Delivery)
                    {
                        decimal total = _order.OrderItems.Sum(o => o.Price);

                        var discount = total - 12;

                        _voucher.Discount = discount;
                    }
                    break;
                default:
                    _voucher.Discount = 0;
                    break;
            }

            return _voucher;
        }

    }
}