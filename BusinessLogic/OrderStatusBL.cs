using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using DataAccess;

namespace BusinessLogic
{
    public class OrderStatusBL
    {
        public static List<OrderStatus> GetAll()
        {
            return OrderStatusDA.GetAll();
        }


        public static OrderStatus GetDetails(int id)
        {
            return OrderStatusDA.GetDetails(id);
        }
    }
}
