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
        public static List<OrderDetails> GetOrderDetailsForOrder(int orderId)
        {
            return OrderDetailsDA.GetOrderDetailsForOrder(orderId);
        }
    }
}
