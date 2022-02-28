using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using System.Data.Entity;

namespace DataAccess
{
    public class OrderDetailsDA
    {
        public static bool Add(List<OrderDetails> details)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                context.OrderDetails.AddRange(details);
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static List<OrderDetails> GetOrderDetailsForOrder(int orderId)
        {
            using (var context = new InvoiceModel())
            {
                return context.OrderDetails.Include(o => o.ProductLine).Where(o => o.OrderId == orderId).ToList();
            }
        }
    }
}
