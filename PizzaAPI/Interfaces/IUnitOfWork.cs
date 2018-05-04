using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces
{

    public interface IUnitOfWork
    {

        IRepository<Pizza> PizzaRepository { get; }
        IRepository<Topping> ToppingRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<OrderItem> CartRepository { get; }

        ///<summary>
        /// Commits All Changes
        /// </summary>
        /// 
        void Commit();
        ///<summary>
        /// Commits All Changes
        /// </summary>
        /// 
        void RejectChanges();

        void Dispose();


    }

}
