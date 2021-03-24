using NewMarket.Services;
using NewMarket.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewMarket.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

           // model.FeaturedCategories = categoryService.GetFeaturedCategories();
            model.FeaturedCategories = CategoriesServices.Instance.GetFeaturedCategories();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}