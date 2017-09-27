using AutoMapper;
using WebJayThomDhuang.ViewModels;
using WebJayThomDhuang.Models;
 
namespace WebJayThomDhuang.Mappings
{
    public class AutoMapperConfiguration
    {
            public static void Configure()
            {
             Mapper.Initialize(cfg => 
             {
                cfg.CreateMap<Category, CategoryViewModel>();
                 cfg.CreateMap<Tea, TeaViewModel>();
            });
        }
        
    }

  
}