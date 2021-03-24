using NewMarket.Entities;
using NewMarket.Services;
using NewMarket.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewMarket.Web.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search, int? pageNo)
        {          
            ProductSearchViewModel model = new ProductSearchViewModel();

            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            model.Products = ProductsService.Instance.GetProducts(model.PageNo);

            if (string.IsNullOrEmpty(search) == false)
            {
                model.SearchTerm = search;
                model.Products = model.Products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
                // products = products.Where(p => p.Name.Contains(search)).ToList();
            }
            return PartialView(model);

            //pageNo = pageNo.HasValue ? pageNo : 1;

            //var products = ProductsService.Instance.GetProducts(pageNo.Value);
            //if (string.IsNullOrEmpty(search) == false)
            //{
            //    products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            //    // products = products.Where(p => p.Name.Contains(search)).ToList();
            //}
            //return PartialView(products);

        }

        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();
            model.AvailableCategories = CategoriesServices.Instance.GetCategories();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Category = CategoriesServices.Instance.GetCategory(model.CategoryID);
            newProduct.ImageURL = model.ImageURL;

            ProductsService.Instance.SaveProduct(newProduct); 

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();

            var product = ProductsService.Instance.GetProduct(ID);
            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            //model.CategoryID = product.Category != null ? product.Category.ID : 0;
            model.ImageURL = product.ImageURL;

            model.AvailableCategories = CategoriesServices.Instance.GetCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existringProduct = ProductsService.Instance.GetProduct(model.ID);
            existringProduct.Name = model.Name;
            existringProduct.Description = model.Description;
            existringProduct.Price = model.Price;
            existringProduct.Category = CategoriesServices.Instance.GetCategory(model.CategoryID);
            existringProduct.ImageURL = model.ImageURL;

            ProductsService.Instance.UpdateProduct(existringProduct);

            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsService.Instance.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            ProductViewModel model = new ProductViewModel();
            model.Product = ProductsService.Instance.GetProduct(ID);
            return View(model);
        }
    }
}