using NewMarket.Entities;
using NewMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewMarket.Web.Controllers
{
    //[Authorize(Roles ="Admin,Manager")]
    public class CategoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }


        public ActionResult CategoryTable(string search)
        {
            var categories = CategoriesServices.Instance.GetCategories();
            
            if (string.IsNullOrEmpty(search) == false)
            {
                categories = categories.Where(c => c.Name != null && c.Name.ToLower().Contains(search.ToLower())).ToList();
                categories = categories.Where(c => c.Name.Contains(search)).ToList();
            }
            return PartialView(categories);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var categories = CategoriesServices.Instance.GetCategories();
            return PartialView(categories);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            /* CategoriesServices categoryService = new CategoriesServices();
             var newCategory = new Category();
             newCategory.Name = category.Name;
             newCategory.Description = category.Description;
             newCategory.ImageURL = category.ImageURL;*/
            CategoriesServices.Instance.SaveCategory(category);

            return RedirectToAction("CategoryTable");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = CategoriesServices.Instance.GetCategory(ID);

            return PartialView(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CategoriesServices.Instance.UpdateCategory(category);
            return RedirectToAction("CategoryTable");
        }
        
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            CategoriesServices.Instance.DeleteCategory(ID);
            return RedirectToAction("Delete");
        }

        
        /*[HttpPost]
        public ActionResult Delete(Category category)
        {
            category = categoryService.GetCategory(category.ID);
            categoryService.DeleteCategory(category.ID);
            return RedirectToAction("Index");
        }*/
    }
}