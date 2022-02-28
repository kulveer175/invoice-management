using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessModel;

namespace BusinessLogic
{
    public class OrderXStatusBL
    {
        public static bool AddOrderXStatus(OrderXStatus orderXOrderStatus)
        {
            return OrderXStatusDA.AddOrderXStatus(orderXOrderStatus);
        }

        public static List<OrderXStatus> GetStatusForOrder(int orderId)
        {
            return OrderXStatusDA.GetStatusForOrder(orderId);
        }
    }
}
