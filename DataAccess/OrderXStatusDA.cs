using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using System.Data.Entity;

namespace DataAccess
{
    public class OrderXStatusDA
    {
        public enum OrderStatus
        {
            Intiated = 1,
            PRocessing,
            Shipped,
            Received,
            Delivered,
            Paid
        }

        public static bool AddOrderXStatus(OrderXStatus orderXOrderStatus)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                context.OrderXStatus.Add(orderXOrderStatus);
                i = context.SaveChanges();
                return i > 0;
            }
        }

        public static List<OrderXStatus> GetStatusForOrder(int orderId)
        {
            using (var context = new InvoiceModel())
            {
                return context.OrderXStatus.Include(o => o.OrderStatus).Where(o => o.OrderId == orderId).ToList();
            }
        }
    }
}
