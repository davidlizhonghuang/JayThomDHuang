using System.Collections.Generic;
using System.Linq;
using WebJayThomDhuang.Models;
using WebJayThomDhuang.Repositories;
using WebJayThomDhuang.Infrastructure;
using System;

namespace WebJayThomDhuang.Service
{
    public interface ITeaService
        {
            IEnumerable<Tea> GetTeas();
            IEnumerable<Tea> GetCategoryTeas(string categoryName, string TeaName = null);
            Tea GetTea(int id);
            void CreateTea(Tea tea);
            void DeleteTea(Tea tea);
            void UpdateTea(Tea tea);
            void Save();
        }

        public class TeaService : ITeaService
        {

            private readonly ITeaRepository teaRepository;
            private readonly ICategoryRepository categoryRepository;
            private readonly IUnitOfWork unitOfWork;
            public TeaService(
                  ITeaRepository teaRepository,
              ICategoryRepository categoryRepository,
              IUnitOfWork unitOfWork
                )
            {
                this.teaRepository = teaRepository;
                this.categoryRepository = categoryRepository;
                this.unitOfWork = unitOfWork;
            }

            public IEnumerable<Tea> GetTeas()
            {
                var teas = teaRepository.GetAll();
                return teas;
            }

            public IEnumerable<Tea> GetCategoryTeas(string categoryName, string gadgetName = null)
            {
            try
            {
                var category = categoryRepository.GetCategoryByName(categoryName);
                return category.Teas.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
            }
            catch (Exception ex)
            {
                LogProcess.LogProcess.WriteLog("", "", "tea service get category teas action returns exception", LogProcess.ElogType.SysException);
                return null;
            }
        }

            public Tea GetTea(int id)
            {
                var tea = teaRepository.GetById(id);
                return tea;
            }

            public void CreateTea(Tea tea)
            {
                teaRepository.Add(tea);
               Save();
            }


        public void DeleteTea(Tea tea)
        {
            teaRepository.Delete(tea);
           Save();
        }

        public void UpdateTea(Tea tea)
        {
            teaRepository.Update(tea);
            Save();
        }


        public void Save()
            {
                unitOfWork.Commit();
            }

        }


    }




