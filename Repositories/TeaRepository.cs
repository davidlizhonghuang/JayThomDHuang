using WebJayThomDhuang.Infrastructure;
using WebJayThomDhuang.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebJayThomDhuang.Repositories
{
    public class TeaRepository : RepositoryBase<Tea>,ITeaRepository
    {
 
        public TeaRepository(IDbFactory dbFactory):base(dbFactory)
        {
 
        }

        public void Delete(Expression<Antlr.Runtime.Misc.Func<Tea, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Tea Get(Expression<Antlr.Runtime.Misc.Func<Tea, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tea> GetMany(Expression<Antlr.Runtime.Misc.Func<Tea, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
    public interface ITeaRepository:IRepository<Tea>
    {

    }
}