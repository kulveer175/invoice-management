using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;

namespace DataAccess
{
    public class OrderStatusDA
    {
        public static List<OrderStatus> GetAll()
        {
            using (var context = new InvoiceModel())
            {
                return context.OrderStatus.ToList();
            }
        }


        public static OrderStatus GetDetails(int id)
        {
            using (var context = new InvoiceModel())
            {
                return context.OrderStatus.Find(id);
            }
        }
    }
}
