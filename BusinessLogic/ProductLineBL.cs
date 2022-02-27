using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using DataAccess;

namespace BusinessLogic
{
    public class ProductLineBL
    {
        public static bool Add(ProductLine product)
        {
            return ProductLineDA.Add(product);
        }

        public static bool Update(ProductLine product)
        {
            return ProductLineDA.Update(product);
        }

        public static bool Delete(ProductLine product)
        {
            return ProductLineDA.Delete(product);
        }

        public static ProductLine GetDetails(int id)
        {
            return ProductLineDA.GetDetails(id);
        }

        public static List<ProductLine> GetAll()
        {
            return ProductLineDA.GetAll();
        }
    }
}
