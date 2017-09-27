using System.Data.Entity;
using WebJayThomDhuang.Models;

namespace WebJayThomDhuang
{
    public class TeaEntities:DbContext
    {
        public TeaEntities():base("TeaEntities")
        {

        }
        public DbSet<Tea> Teas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public virtual void Commit() {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TeaConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }

        public System.Data.Entity.DbSet<WebJayThomDhuang.ViewModels.TeaViewModel> TeaViewModels { get; set; }

        public System.Data.Entity.DbSet<WebJayThomDhuang.ViewModels.CategoryViewModel> CategoryViewModels { get; set; }
    }
}