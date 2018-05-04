using System.Linq;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Services
{
    public class DeliveryService
    {

        public bool GetDelivery(Order order)
        {
            return order.Delivery;
        }

        public Order SetDelivery(Order order, bool deliveryType)
        {
            order.Delivery = deliveryType;
            return order;
        }

    }
}