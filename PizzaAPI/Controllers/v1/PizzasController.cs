using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.ViewModels;
using PizzaAPI.Repositories;
using PizzaAPI.Services;

namespace PizzaAPI.Controllers.v1
{
    public class PizzasController : ApiController
    {
        
        [HttpGet]
        [Route("api/v1/Pizzas")]
        [ResponseType(typeof(List<Pizza>))]
        public IHttpActionResult GetAllPizzas()
        {
            var repo = new PizzaRepository();
            var service = new PizzaService(repo);
            var data = new PizzaEndpoint(service.GetAllPizzas(), service.GetCombinedPizzaViewModels());
            return Ok(data);
        }

        [HttpGet]
        [Route("api/v1/Pizza/{id}")]
        [ResponseType(typeof(List<Pizza>))]
        public IHttpActionResult GetPizza(int id)
        {
            var repo = new PizzaRepository();
            var service = new PizzaService(repo);
            var vm = service.GetPizza(id);
            return Ok(vm);
        }


    }
}
