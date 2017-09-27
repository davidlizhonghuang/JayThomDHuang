using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebJayThomDhuang.Models;
using WebJayThomDhuang.Service;
using WebJayThomDhuang.ViewModels;

namespace WebJayThomDhuang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;

        private readonly ITeaService teaService;

        public HomeController(ICategoryService categoryService, ITeaService teaService)
        {
            this.categoryService = categoryService;
            this.teaService = teaService;

        }

        public ActionResult Category(string category = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            IEnumerable<CategoryViewModel> viewModelCategory;

            IEnumerable<Category> categories;

            categories = categoryService.GetCategories(category).ToList();

            viewModelCategory = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return View(viewModelCategory);

        }

        public ActionResult TeaList()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            IEnumerable<TeaViewModel> teaviewmodel;

            IEnumerable<Tea> teas;

            teas = teaService.GetTeas().ToList();

            teaviewmodel = Mapper.Map<IEnumerable<Tea>, IEnumerable<TeaViewModel>>(teas);

            return View(teaviewmodel);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateTea(Tea model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            teaService.CreateTea(model);
            ViewBag.Mesg = "a new tea is created";
            return Redirect("Create");
        }

        public ActionResult Edit(int ID)
        {
            var viewmodel = teaService.GetTea(ID);
            var tea = Mapper.Map<Tea, TeaViewModel>(viewmodel);
            return View(tea);
        }

        public ActionResult EditTea(Tea model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            teaService.UpdateTea(model);

            return Redirect("TeaList");

        }

        public ActionResult Delete(int ID)
        {
            var viewmodel = teaService.GetTea(ID);
            var tea = Mapper.Map<Tea, TeaViewModel>(viewmodel);
            return View(tea);
        }

        public ActionResult DeleteTea(int ID)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var model = teaService.GetTea(ID);
            teaService.DeleteTea(model);
            ViewBag.Mesg = "delete is done";
            return Redirect("TeaList");
        }

        public ActionResult Details(int ID)
        {
            var model = teaService.GetTea(ID);
            var tea = Mapper.Map<Tea, TeaViewModel>(model);
            return View(tea);
        }
    }
}