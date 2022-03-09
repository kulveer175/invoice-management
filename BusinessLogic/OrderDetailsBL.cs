using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessModel;

namespace BusinessLogic
{
    public class OrderDetailsBL
    {
        public static bool AddOrderXStatus(OrderXStatus orderXOrderStatus)
        {
            return OrderXStatusDA.AddOrderXStatus(orderXOrderStatus);
        }
        public static List<OrderDetails> GetOrderDetailsForOrder(int orderId)
        {
            return OrderDetailsDA.GetOrderDetailsForOrder(orderId);
        }
    }
}
