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

        public static Dictionary<String, double> GetClientRevenue()
        {
            Dictionary<String, double> report = new Dictionary<string, double>();

            var list = OrderDA.GetAll();
            foreach (var item in list)
            {
                if (report.ContainsKey(item.Client.BusinessName))
                {
                    report[item.Client.BusinessName] += item.TotalAmount;
                }
                else
                {
                    report.Add(item.Client.BusinessName, item.TotalAmount);
                }
            }

            return report;
        }

        public static List<Order> OrderLogs()
        {
            return OrderDA.OrderLogs();
        }
    }
}
