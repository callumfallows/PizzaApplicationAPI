using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PizzaAPI.Interfaces;
using PizzaAPI.Interfaces.Entities;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Models;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.Helpers;
using PizzaAPI.Models.ViewModels;
using PizzaAPI.Repositories;
using PizzaAPI.Services;

namespace PizzaAPI.Tests.Repositories
{
    [TestFixture]
    public class ToppingRepoistoryTestAllToppings
    {
        private List<ToppingViewModel> _toppingViewModel;
        private List<Topping> _toppings;

        [OneTimeSetUp]
        public void WhenGettingAllToppings()
        {

            var cheese_s = new Topping { Id = 1, Name = "Cheese", Size = "small", Price = 0.90M };
            var cheese_m = new Topping { Id = 2, Name = "Cheese", Size = "medium", Price = 1.00M };
            var cheese_l = new Topping { Id = 3, Name = "Cheese", Size = "large", Price = 1.15M };
            var ham_s = new Topping { Id = 10, Name = "Ham", Size = "small", Price = 0.90M };
            var ham_m = new Topping { Id = 11, Name = "Ham", Size = "medium", Price = 1.00M };
            var ham_l = new Topping { Id = 12, Name = "Ham", Size = "large", Price = 1.15M };
            var chick_s = new Topping { Id = 13, Name = "Chicken", Size = "small", Price = 0.90M };
            var chick_m = new Topping { Id = 14, Name = "Chicken", Size = "medium", Price = 1.00M };
            var chick_l = new Topping { Id = 15, Name = "Chicken", Size = "large", Price = 1.15M };
            var beef_s = new Topping { Id = 16, Name = "Minced beef", Size = "small", Price = 0.90M };
            var beef_m = new Topping { Id = 17, Name = "Minced beef", Size = "medium", Price = 1.00M };
            var beef_l = new Topping { Id = 18, Name = "Minced beef", Size = "large", Price = 1.15M };
            var onion_s = new Topping { Id = 19, Name = "Onions", Size = "small", Price = 0.90M };
            var onion_m = new Topping { Id = 20, Name = "Onions", Size = "medium", Price = 1.00M };
            var onion_l = new Topping { Id = 21, Name = "Onions", Size = "large", Price = 1.15M };
          

            var repo = new Mock<IToppingRepository>();
            _toppings = new List<Topping>
            {
                cheese_s,
                cheese_m,
                cheese_l,
                onion_s,
                onion_m,
                onion_l,
                beef_s,
                beef_m,
                beef_l,
                chick_s,
                chick_m,
                chick_l,
                ham_s,
                ham_m,
                ham_l
            };

            repo.Setup(x => x.GetAllToppings())
                .Returns(_toppings);

            var subject = new ToppingService(repo.Object);
            _toppingViewModel = subject.GetAllToppings();
        }
        
        [Test]
        public void ThenAllToppingsAreRetrieved()
        {
            Assert.That(_toppingViewModel.Count(), Is.EqualTo(15));
        }

    }

    [TestFixture]
    public class ToppingRepoistoryGetToppingBySize
    {
        private List<ToppingViewModel> _toppingViewModel;
        private List<Topping> _toppings;

        [OneTimeSetUp]
        public void WhenGettingToppingBySize()
        {

            var cheese_s = new Topping { Id = 1, Name = "Cheese", Size = "small", Price = 0.90M };
            var ham_s = new Topping { Id = 10, Name = "Ham", Size = "small", Price = 0.90M };
            var chick_s = new Topping { Id = 13, Name = "Chicken", Size = "small", Price = 0.90M };
            var beef_s = new Topping { Id = 16, Name = "Minced beef", Size = "small", Price = 0.90M };
            var onion_s = new Topping { Id = 19, Name = "Onions", Size = "small", Price = 0.90M };

            var repo = new Mock<IToppingRepository>();
            _toppings = new List<Topping>
            {
                cheese_s,
                onion_s,
                beef_s,
                chick_s,
                ham_s
            };

            repo.Setup(x => x.GetToppingBySize("small"))
                .Returns(_toppings);

            var subject = new ToppingService(repo.Object);
            _toppingViewModel = subject.GetToppingsBySize("small");
        }

        [Test]
        public void ThenAllToppingsOfCorrectSizeAreRetrieved()
        {
            Assert.That(_toppingViewModel.Count(), Is.EqualTo(5));
        }

    }
}
