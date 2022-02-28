using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using DataAccess;

namespace BusinessLogic
{
    public class OrderBL
    {
        public static Order GetDetails(int id)
        {
            return OrderDA.GetDetails(id);
        }

        public static List<Order> GetOrdersForClient(int clientId)
        {
            return OrderDA.GetOrdersForClient(clientId);
        }
    }
}
