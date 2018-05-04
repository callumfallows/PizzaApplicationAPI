using System.Data.Entity;
using System.Linq;
using PizzaAPI.Interfaces;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Models.Entities;
using PizzaAPI.Models.ViewModels;
using PizzaAPI.Repositories;

namespace PizzaAPI.Models
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _dbContext;

        #region Repositories

        public IRepository<Pizza> PizzaRepository => new GenericRepository<Pizza>(_dbContext);
        public IRepository<Topping> ToppingRepository => new GenericRepository<Topping>(_dbContext);
        public IRepository<Order> OrderRepository => new GenericRepository<Order>(_dbContext);
        public IRepository<OrderItem> CartRepository => new GenericRepository<OrderItem>(_dbContext);

        #endregion

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }


        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added: entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
