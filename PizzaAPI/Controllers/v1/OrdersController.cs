using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.ViewModels;
using PizzaAPI.Repositories;
using PizzaAPI.Services;

namespace PizzaAPI.Controllers.v1
{
    public class OrdersController : ApiController
    {

        private OrderRepository OrderRepository { get; }
        private OrderService OrderService { get; }

        public OrdersController()
        {
            OrderRepository = new OrderRepository();
            OrderService = new OrderService(OrderRepository);
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/Orders")]
        [ResponseType(typeof(List<Order>))]
        public IHttpActionResult GetOrders()
        {
            var userId = RequestContext.Principal.Identity.GetUserId();
            var orders = OrderService.GetAllOrdersByUserId(userId);
            var vm = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                vm.Add(new OrderViewModel(order));
            }
            return Ok(vm);
        }

        [Authorize]
        [HttpPost]
        [Route("api/v1/SubmitOrder")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult SubmitOrder(CartViewModel cartViewModel)
        {
            var orderRepo = new OrderRepository();
            var orderService = new OrderService(orderRepo);
            var order = new Order(cartViewModel.Order);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            orderService.AddNewOrder(order);
            return Ok(new OrderViewModel(order));
        }
     }
}
