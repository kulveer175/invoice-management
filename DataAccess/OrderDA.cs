using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;

namespace DataAccess
{
    public class OrderDA
    {
        public static int Add(Order order)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                context.Orders.Add(order);
                i = context.SaveChanges();

                return order.Id;
            }
        }
    }
}
