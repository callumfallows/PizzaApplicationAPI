namespace PizzaAPI.Interfaces.Entities
{
    public interface IPizzaOrderContext
    {
         IPizza Pizzas { get; set; }
         ITopping Toppings { get; set; }
         IOrder Orders { get; set; }
         IOrderItem OrderItems { get; set; }
    }
}
