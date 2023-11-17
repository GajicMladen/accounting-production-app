using Microsoft.EntityFrameworkCore;
using tehnohem_api.DB;
using tehnohem_api.Repositories.Interface;

namespace tehnohem_api.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PostgresqlContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public Repository(PostgresqlContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

    }
}
