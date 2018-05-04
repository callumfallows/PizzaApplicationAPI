using System;
using System.Collections.Generic;
using PizzaAPI.Interfaces.Entities;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Interfaces.Services;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Services
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _cartRepository;
        public List<OrderItem> Cart { get; set; }
        public CartService(ICartRepository repo)
        {
            _cartRepository = repo;
            Cart = GetCart();
        }
        public List<OrderItem> GetCart()
        {
            var cart = _cartRepository.GetAll();
            return cart;
        }
        private static decimal CalculateToppingCost(IEnumerable<Topping> additionalToppings)
        {
            decimal _total_cost = 0;
            foreach (var topping in additionalToppings)
            {
                _total_cost += topping.Price;
            }
            
            return _total_cost;
        }
        public Order ResetCart()
        {
            return new Order();
        }
        public void AddNewItem(Pizza pizza, List<Topping> additionalToppings, Order order)
        {
            OrderItem orderItem = new OrderItem();
            List<OrderItem> existingItems = order.OrderItems;
            orderItem.Price = pizza.Price;
            orderItem.Price += CalculateToppingCost(additionalToppings);
            orderItem.Pizza = pizza;
            orderItem.AdditionalToppings = additionalToppings;
            existingItems.Add(orderItem);
            order.OrderItems = existingItems;
        }
        public void Remove(OrderItem orderItem, IOrder order)
        {
            var itemToRemove = order.OrderItems.Find(item => item.OrderItemId == orderItem.OrderItemId);
            order.OrderItems.Remove(itemToRemove);
        }
        public void Submit(string userId, IOrder cart)
        {
            throw new NotImplementedException();
        }
    }


}