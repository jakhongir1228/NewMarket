using NewMarket.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewMarket.Database
{
    public class NMContext: DbContext, IDisposable
    {
        public NMContext():base("NewMarket")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Config> Configurations { get; set; }
    }
}
