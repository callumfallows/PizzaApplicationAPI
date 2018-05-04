using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Interfaces.ViewModels;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.Helpers;
using PizzaAPI.Models.ViewModels;
using PizzaAPI.Services;

namespace PizzaAPI.Tests.Models.ViewModels
{
    class PizzaViewModelTest
    {

        [TestFixture]
        public class GivenAPizzaIsNotCustomAndHasToppings
        {
            private List<PizzaViewModel> _pizzaViewModel;
            private List<Pizza> _pizzas;
            private Pizza _pizza;
            private List<Topping> _toppingSmall;
            private List<Topping> _toppingLarge;
            private List<Topping> _toppingMedium;

            [OneTimeSetUp]
            public void WhenGettingAllPizzaTypes()
            {


                //setup
                var cheese_s = new Topping { Id = 1, Name = "Cheese", Size = "small", Price = 0.90M };
                var cheese_m = new Topping { Id = 2, Name = "Cheese", Size = "medium", Price = 1.00M };
                var cheese_l = new Topping { Id = 3, Name = "Cheese", Size = "large", Price = 1.15M };
                var tom_s = new Topping { Id = 4, Name = "Tomato sauce", Size = "small", Price = 0.90M };
                var tom_m = new Topping { Id = 5, Name = "Tomato sauce", Size = "medium", Price = 1.00M };
                var tom_l = new Topping { Id = 6, Name = "Tomato sauce", Size = "large", Price = 1.15M };
                var pepp_s = new Topping { Id = 7, Name = "Pepperoni", Size = "small", Price = 0.90M };
                var pepp_m = new Topping { Id = 8, Name = "Pepperoni", Size = "medium", Price = 1.00M };
                var pepp_l = new Topping { Id = 9, Name = "Pepperoni", Size = "large", Price = 1.15M };

                _toppingSmall = new List<Topping>()
                {
                    cheese_s,
                    tom_s,
                    pepp_s
                };
                _toppingMedium = new List<Topping>()
                {
                    cheese_m,
                    tom_m,
                    pepp_m
                };
                _toppingLarge = new List<Topping>()
                {
                    cheese_l,
                    tom_l,
                    pepp_l
                };
                _pizzas = new List<Pizza>
                {
                    new Pizza {Name = "Pizza", Id = 1, Toppings = _toppingSmall},
                    new Pizza {Name = "Pizza", Id = 2, Toppings = _toppingSmall}
                };

                var repo = new Mock<IPizzaRepository>();
                repo.Setup(x => x.GetAllPizzas())
                    .Returns(_pizzas);
                
                var subject = new PizzaService(repo.Object);
                _pizza = _pizzas[0];
                _pizzaViewModel = subject.GetAllPizzas();
            }

            [Test]
            public void ThenPizzaViewModelPizzaIdIsSetCorrectly()
            {
                Assert.AreEqual(_pizzaViewModel[0].Id, _pizza.Id);
            }

            [Test]
            public void ThenPizzaViewModelPriceIsSetCorrectly()
            {
                Assert.AreEqual(_pizzaViewModel[0].Price, _pizza.Price);
            }

            [Test]
            public void ThenPizzaViewModelNameIsSetCorrectly()
            {
                Assert.AreEqual(_pizzaViewModel[0].Name, _pizza.Name);
            }

            [Test]
            public void ThenPizzaViewModelSizeeIsSetCorrectly()
            {
                Assert.AreEqual(_pizzaViewModel[0].Size, _pizza.Size);
            }

            [Test]
            public void ThenAllPizzaToppingsAreApplied()
            {
                Assert.AreEqual(_pizza.Toppings.Count, _pizzaViewModel[0].Toppings.Count);
            }
        }

        [TestFixture]
        public class GivenASinglePizzaIsNotCustomAndHasToppings
        {
            private PizzaViewModel _pizzaViewModel;

            [OneTimeSetUp]
            public void WhenGettingASinglePizza()
            {
                var repo = new Mock<IPizzaRepository>();
                repo.Setup(x => x.GetPizza(1))
                    .Returns(new Pizza { Name = "Pizza", Id = 1 });


                var subject = new PizzaService(repo.Object);
                _pizzaViewModel = subject.GetPizza(1);
            }

            [Test]
            public void ThenTheIdShouldBeEqualToTheRequest()
            {
                Assert.That(_pizzaViewModel.Id, Is.EqualTo(1));
            }

        }
    }

}
