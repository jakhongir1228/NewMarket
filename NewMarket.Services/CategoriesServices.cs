using NewMarket.Database;
using NewMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMarket.Services
{
    public class CategoriesServices
    {
        #region Singleton
        public static CategoriesServices Instance
        {
            get
            {
                if (instence == null) instence = new CategoriesServices();

                return instence;
            }
        }

        private static CategoriesServices instence { get; set; }

        private CategoriesServices()
        {
        }
        #endregion

        public Category GetCategory(int ID)
        {
            using (var context = new NMContext())
            {
                return context.Categories.Find(ID);
            }
        }
        public List<Category> GetCategories()
        {
            using (var context = new NMContext())
            {
                return context.Categories.ToList();
            }
        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new NMContext())
            {
                return context.Categories.Where(x => x.isFeatured && x.ImageURL != null).ToList();//.Where(x => x.isFeatured)
            }
        }

        public void SaveCategory(Category category)
        {
            using (var context = new NMContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new NMContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new NMContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var category = context.Categories.Find(ID);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
