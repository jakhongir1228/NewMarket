using NewMarket.Database;
using NewMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMarket.Services
{
    public class ConfigurationsService
    {
        #region Singleton
        public static ConfigurationsService Instance
        {
            get
            {
                if (instence == null) instence = new ConfigurationsService();

                return instence;
            }
        }
        private static ConfigurationsService instence { get; set; }

        private ConfigurationsService()
        {
        }
        #endregion

        public Config GetConfig(string Key)
        {
            using (var context = new NMContext())
            {
                return context.Configurations.Find(Key);
            }
        }
    }
}
