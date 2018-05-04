using System.Data.Entity;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Models.Entities
{
    public class PizzaOrderContext : ApplicationDbContext
    {
        //Database Schema
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}