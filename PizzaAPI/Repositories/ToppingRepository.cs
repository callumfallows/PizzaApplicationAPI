using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Models;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly PizzaOrderContext _db = new PizzaOrderContext();

        public List<Topping> GetAllToppings()
        {
            var unitOfWork = new UnitOfWork(_db);
            var toppings = new List<Topping>(unitOfWork.ToppingRepository.Entities);

            return toppings;
        }

        public List<Topping> GetToppingBySize(string size)
        {
            var allToppings = GetAllToppings();
            var toppingsBySize = allToppings.FindAll( x => x.Size == size);

            return toppingsBySize;
        }

        public Topping GetTopping(int id)
        {

            var unitOfWork = new UnitOfWork(_db);
            var topping = unitOfWork.ToppingRepository.Get(id);
            return topping;
        }

        
    }
}