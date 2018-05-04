using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using PizzaAPI.Interfaces.Entities;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Interfaces.Services;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.ViewModels;
using PizzaAPI.Repositories;
using PizzaAPI.Services;

namespace PizzaAPI.Controllers.v1
{
    public class CartController : ApiController
    {
       

        private IPizzaRepository PizzaRepository { get; }
        private ICartRepository CartRepository { get; }
        private IToppingRepository ToppingRepository { get; }
        private IOrderRepository OrderRepository { get; set; }
        private ICartService CartService { get; }
        private IPizzaService PizzaService { get; }
        private IOrderService OrderService { get; set; }
        private IToppingService ToppingService { get; }
        private IVoucherService VoucherService { get; }

        public CartController()
        {
            PizzaRepository = new PizzaRepository();
            CartRepository = new CartRepository();
            ToppingRepository = new ToppingRepository();
            OrderRepository = new OrderRepository();
            CartService = new CartService(CartRepository);
            PizzaService = new PizzaService(PizzaRepository);
            ToppingService = new ToppingService(ToppingRepository);
            OrderService = new OrderService(OrderRepository);
        }
        

        [HttpPost]
        [Route("api/v1/AddToCart")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult AddToCart(CartViewModel cartViewModel)
        {
           
            var cartService = new CartService(CartRepository);
            var toppings = new List<Topping>() { };
            decimal totalPrice = 0;

            var order = new Order(cartViewModel.Order);
            order.UserId = RequestContext.Principal.Identity.GetUserId();
            var pizza = PizzaRepository.GetPizza(cartViewModel.Pizza.Id);

            totalPrice = pizza.Price;

            foreach (var topping in cartViewModel.AdditionalToppings)
            {
                var newTopping = ToppingRepository.GetTopping(topping.Id);
                totalPrice += topping.Price;
                toppings.Add(newTopping);
            }
           
            cartService.AddNewItem(pizza, toppings, order);
            var vm = new OrderViewModel(order);
            return Ok(vm);
        }

        [HttpDelete]
        [Route("api/v1/RemoveFromCart")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult RemoveFromCart(CartViewModel cartViewModel)
        {
            
            Order order = new Order(cartViewModel.Order);
            OrderItem orderItem = cartViewModel.OrderItem;
            CartService.Remove(orderItem, order);
            var vm = new OrderViewModel(order);
            return Ok(vm);
        }

        [HttpDelete]
        [Route("api/v1/ResetCart")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult ResetCart()
        {
            var vm = new OrderViewModel(CartService.ResetCart());
            return Ok(vm);
        }

        [HttpPost]
        [Route("api/v1/AddCoupon")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult AddCoupon(CartViewModel cartViewModel)
        {
           var order = new Order(cartViewModel.Order);
           var voucherDiscount = VoucherService.CalculateTotalDiscount(order, new Voucher(cartViewModel.VoucherCode));
           order.CurrentVoucher = voucherDiscount.VoucherName;
           order.Discount = voucherDiscount.Discount;
            var vm = new OrderViewModel(order);
            return Ok(vm);
        }
        
        [HttpPost]
        [Route("api/v1/ApplyDelivery")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult ApplyDelivery(CartViewModel cartViewModel)
        {
           var order = new Order(cartViewModel.Order);
            order.Delivery = cartViewModel.Delivery;
            var vm = new OrderViewModel(order);
            return Ok(vm);
        }
        
    }
}
