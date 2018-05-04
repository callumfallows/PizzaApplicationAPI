using System.Data.Entity;
using System.Linq;
using PizzaAPI.Interfaces.Repositories;
using PizzaAPI.Models.ViewModels;

namespace PizzaAPI.Repositories
{
   
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbSet<T> DbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => DbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
        
    }
}
