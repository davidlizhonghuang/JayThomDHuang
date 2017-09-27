using System;


namespace WebJayThomDhuang.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        TeaEntities init();
    }

    public class DbFactory : IDbFactory, IDisposable
    {
        TeaEntities DbContext;

        public TeaEntities init()
        {
            return DbContext ?? (DbContext = new TeaEntities());
        }

        public void Dispose()
        {
           if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }
    }


}