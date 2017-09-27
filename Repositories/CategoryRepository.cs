using WebJayThomDhuang.Infrastructure;
using WebJayThomDhuang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebJayThomDhuang.Repositories
{
    public class CategoryRepository:RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(IDbFactory  dbFactory) :base(dbFactory)
        {

        }

        public void Delete(Expression<Antlr.Runtime.Misc.Func<Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Category Get(Expression<Antlr.Runtime.Misc.Func<Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

        public IEnumerable<Category> GetMany(Expression<Antlr.Runtime.Misc.Func<Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        public override void Update(Category entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }

    }

    public interface ICategoryRepository: IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}