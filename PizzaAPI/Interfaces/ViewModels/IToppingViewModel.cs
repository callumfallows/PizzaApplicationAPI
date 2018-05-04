namespace PizzaAPI.Interfaces.ViewModels
{
    public interface IToppingViewModel
    {
        int ToppingId { get; set; }
        string Name { get; set; }
        string Size { get; set; }
        decimal Price { get; set; }
    }
}
