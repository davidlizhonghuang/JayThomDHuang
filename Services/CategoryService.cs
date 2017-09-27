using WebJayThomDhuang.Infrastructure;
using WebJayThomDhuang.Models;
using WebJayThomDhuang.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebJayThomDhuang.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
        void SaveCategory();
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categorysRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(
            ICategoryRepository categorysRepository, 
            IUnitOfWork unitOfWork)
        {
            this.categorysRepository = categorysRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetCategories(string name = null)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return categorysRepository.GetAll();
                else
                    return categorysRepository.GetAll().Where(c => c.Name == name);
            }
            catch(Exception ex)
            {
                LogProcess.LogProcess.WriteLog("", "", "category repository.getall() returns exception" + ex.Message, LogProcess.ElogType.SysException);
                return null;
            }
        }

        public Category GetCategory(int id)
        {
            try
            {
                var category = categorysRepository.GetById(id);
                return category;
            }
            catch (Exception ex)
            {
                LogProcess.LogProcess.WriteLog("", "", "getcategory() returns exception" + ex.Message, LogProcess.ElogType.SysException);
                return null;
            }
        }

        public Category GetCategory(string name)
        {
            try
            {
                var category = categorysRepository.GetCategoryByName(name);
                return category;
            }
            catch (Exception ex)
            {
                LogProcess.LogProcess.WriteLog("", "", "getcategory() returns exception" + ex.Message, LogProcess.ElogType.SysException);
                return null;
            }
        }

        public void CreateCategory(Category category)
        {
            try
            {
                categorysRepository.Add(category);
            }
            catch (Exception ex)
            {
                LogProcess.LogProcess.WriteLog("", "", "createcategory() returns exception" + ex.Message, LogProcess.ElogType.SysException);
            }
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
    }
}
