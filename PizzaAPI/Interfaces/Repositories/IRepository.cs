using System.Linq;
using PizzaAPI.Models.Entities;

namespace PizzaAPI.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        void Remove(T entity);
        void Add(T entity);
        T Get(int id);
    }
}
