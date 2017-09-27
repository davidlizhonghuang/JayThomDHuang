namespace WebJayThomDhuang.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TeaEntities dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
         }
        public void Commit()
        {
            DbContext.Commit();
        }
        public TeaEntities DbContext
        {
            get
            {
                return dbContext ?? (dbContext = dbFactory.init());
            }
        }
    }
}