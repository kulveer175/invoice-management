using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;

namespace DataAccess
{
    public class ProductLineDA
    {
        public static bool Add(ProductLine product)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                context.ProductLines.Add(product);
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static bool Update(ProductLine product)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                var InDb = context.ProductLines.Find(product.Id);
                InDb.Name = product.Name;
                InDb.Price = product.Price;
                InDb.QuantityInStock = product.QuantityInStock;
                InDb.PhotoUrl = product.PhotoUrl;
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static bool Delete(ProductLine product)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                var InDb = context.ProductLines.Find(product.Id);
                context.ProductLines.Remove(InDb);
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static ProductLine GetDetails(int id)
        {
            using (var context = new InvoiceModel())
            {
                return context.ProductLines.Find(id);
            }
        }

        public static List<ProductLine> GetAll()
        {
            using (var context = new InvoiceModel())
            {
                return context.ProductLines.ToList();
            }
        }
    }
}
