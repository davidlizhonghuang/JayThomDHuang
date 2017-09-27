using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebJayThomDhuang.Infrastructure
{
    public abstract class RepositoryBase<T> where T:class
    {
        private TeaEntities dataContext;

        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected TeaEntities DbContext
        {
            get
            {
                return dataContext ?? (dataContext = DbFactory.init());
            }
        }

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>(); 
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        
    }
}