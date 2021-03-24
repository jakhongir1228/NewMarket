using NewMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMarket.Web.ViewModels
{
    public class CategorySearchViewModel
    {
        public List<Category> Categories { get; set; }

        public string SearchTerm { get; set; }

    }    
    public class NewCategoryViewModels
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool isFeatured { get; set; }
        public int CategoryID { get; set; }
    }
    public class EditCategoryViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool isFeatured { get; set; }
        public int CategoryID { get; set; }
    }
}