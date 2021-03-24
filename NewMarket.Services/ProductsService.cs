using NewMarket.Database;
using NewMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NewMarket.Services
{
    public class ProductsService
    {
        #region Singleton
        public static ProductsService Instance
        {
            get
            {
                if (instence == null) instence = new ProductsService();

                return instence;
            }
        }
        private static ProductsService instence { get; set; }

        private ProductsService()
        {
        }
        #endregion
        public Product GetProduct(int ID)
        {
            using (var context = new NMContext())
            {
                return context.Products.Find(ID);
            }
        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new NMContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList(); 
            }
        }

        public List<Product> GetProducts(int pageNo)
        {
            int pageSize = 5;

            using (var context = new NMContext())
            {
               // return context.Products.OrderBy(x=>x.ID).Skip((pageNo-1)* pageSize).Take(pageSize).Include(x=>x.Category).ToList();
                return context.Products.Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetProducts(int pageNo, int pageSize)
        {
            using (var context = new NMContext())
            {
                 return context.Products.OrderByDescending(x=>x.ID).Skip((pageNo-1)* pageSize).Take(pageSize).Include(x=>x.Category).ToList();
               // return context.Products.Include(x => x.Category).ToList();
            }
        }
        public List<Product> GetLatestProducts(int numberOfProducts)
        {
            using (var context = new NMContext())
            {
                return context.Products.OrderByDescending(x=>x.ID).Take(numberOfProducts).Include(x=>x.Category).ToList();
                //return context.Products.Include(x => x.Category).ToList();
            }
        }
        public void SaveProduct(Product product)
        {
            using (var context = new NMContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var context = new NMContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new NMContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var product = context.Products.Find(ID);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
