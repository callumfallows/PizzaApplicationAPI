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
    public class PizzaRepoistoryTestAllPizzas
    {
        private List<PizzaViewModel> _pizzaViewModel;
        private List<Pizza> _pizza;

        [OneTimeSetUp]
        public void WhenGettingAllPizzaTypes()
        {
            var repo = new Mock<IPizzaRepository>();
            _pizza = new List<Pizza>
            {
                new Pizza {Name = "Pizza"},
                new Pizza {Name = "Pizza"}
            };

            repo.Setup(x => x.GetAllPizzas())
                .Returns(_pizza);

            var subject = new PizzaService(repo.Object);
            _pizzaViewModel = subject.GetAllPizzas();
        }
        
        [Test]
        public void ThenAllPizzasAreRetrieved()
        {
            Assert.That(_pizzaViewModel.Count(), Is.EqualTo(2));
        }

    }
    public class PizzaRepoistoryTestSinglePizza
    {
        private PizzaViewModel _pizzaViewModel;
        private Pizza _pizza;

        [OneTimeSetUp]
        public void WhenGettingASinglePizza()
        {
            var repo = new Mock<IPizzaRepository>();
            _pizza =  new Pizza {Name = "Pizza", Id= 1};

            repo.Setup(x => x.GetPizza(1))
                .Returns(_pizza);

            var subject = new PizzaService(repo.Object);
            _pizzaViewModel = subject.GetPizza(1);
        }

        [Test]
        public void ThenTheCorrectPizzaIsRetrieved()
        {
            Assert.AreEqual(_pizzaViewModel.Id, _pizza.Id);
        }

    }

}
