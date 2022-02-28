using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using System.Data.Entity;

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

        public static Order GetDetails(int id)
        {
            using (var context = new InvoiceModel())
            {
                return context.Orders.Include(o => o.Client).FirstOrDefault(o => o.Id == id);
            }
        }

        public static List<Order> GetOrdersForClient(int clientId)
        {
            using (var context = new InvoiceModel())
            {
                return context.Orders.Where(o => o.ClientId == clientId).ToList();
            }
        }
    }
}
