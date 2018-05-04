using System.Collections.Generic;
using System.Linq;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Models;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaOrderContext _db = new PizzaOrderContext();
        public Pizza GetPizza(int id)
        {
            var unitOfWork = new UnitOfWork(_db);
            var pizza = unitOfWork.PizzaRepository.Get(id);
            return pizza;
        }

        public List<Pizza> AllPizzas { get; set; }
        public List<Pizza> GroupedByName { get; set; }
        public List<Pizza> GetAllPizzas()
        {
            var unitOfWork = new UnitOfWork(_db);
            var pizzaList = new List<Pizza>(unitOfWork.PizzaRepository.Entities);
                
            return pizzaList;
        }

        public Pizza GetPizzaBySizeAndName(string pizzaName, string size)
        {
           var pizza =  AllPizzas.Find(x => x.Name == pizzaName && x.Size == size);
           return pizza;
        }
        private List<Pizza> GroupPizzaByName(List<Pizza> allPizzas)
        {
            IEnumerable<Pizza> distinctPizzas = allPizzas.Distinct(Pizza.NameComparer);
            return distinctPizzas.ToList();
        }

        public PizzaRepository()
        {
            AllPizzas = GetAllPizzas();
            GroupedByName = GroupPizzaByName(AllPizzas);
        }
    }
}