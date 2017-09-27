using Autofac;
using Autofac.Integration.Mvc;
using WebJayThomDhuang.Infrastructure;
using WebJayThomDhuang.Mappings;
using WebJayThomDhuang.Repositories;
using WebJayThomDhuang.Service;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Services;

namespace WebJayThomDhuang.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerRequest();
            builder.RegisterType<TeaService>().As<ITeaService>().InstancePerRequest();
            
            // Repositories
            builder.RegisterAssemblyTypes(typeof(TeaRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(WebService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
