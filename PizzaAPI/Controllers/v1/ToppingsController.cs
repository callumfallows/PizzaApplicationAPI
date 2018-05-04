using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using PizzaAPI.Models.Entities;
using PizzaAPI.Repositories;
using PizzaAPI.Services;

namespace PizzaAPI.Controllers.v1
{
    public class ToppingsController : ApiController
    {

        private ToppingRepository ToppingRepository { get; }
        private ToppingService ToppingService { get; }

        public ToppingsController()
        {
            ToppingRepository = new ToppingRepository();
            ToppingService = new ToppingService(ToppingRepository);
        }

        [HttpGet]
        [Route("api/v1/Toppings")]
        [ResponseType(typeof(List<Topping>))]
        public IHttpActionResult GetAllToppings()
        {
            return Ok(ToppingService.GetAllToppings());
        }

        [HttpGet]
        [Route("api/v1/Toppings/{size}")]
        [ResponseType(typeof(List<Topping>))]
        public IHttpActionResult GetToppingBySize(string size)
        {
            return Ok(ToppingService.GetToppingsBySize(size));
        }
    }
}
