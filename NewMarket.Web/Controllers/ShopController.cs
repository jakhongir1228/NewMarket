﻿using NewMarket.Services;
using NewMarket.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewMarket.Web.Controllers
{
    public class ShopController : Controller
    {
       // ProductsService productsService = new ProductsService();
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel(); 

            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null)
            {
                //var ProductIDs = CartProductsCookie.Value;
                //var ids = ProductIDs.Split('-');
                //List<int> pIDs = ids.Select(x => int.Parse(x)).ToList();

                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();

                model.CartProducts = ProductsService.Instance.GetProducts(model.CartProductIDs);
            }

            return View(model);
        }
    }
}