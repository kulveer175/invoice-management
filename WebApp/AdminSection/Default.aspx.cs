using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace WebApp.AdminSection
{
    public partial class Default : System.Web.UI.Page
    {
        protected string[] clientNames;
        protected double[] totalRevenue;

        protected string[] dates;
        protected double[] dateRevenue;
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = OrderBL.GetClientRevenue();
            int index = 0;
            clientNames = new string[list.Count];
            totalRevenue = new double[list.Count];
            foreach (var key in list.Keys)
            {
                clientNames[index] = key;
                totalRevenue[index] = list[key];
                index++;
            }

            var logs = OrderBL.OrderLogs();
            index = 0;
            dates = new string[logs.Count];
            dateRevenue = new double[logs.Count];
            foreach (var key in logs)
            {
                dates[index] = key.OrderDate.ToString("D");
                dateRevenue[index] = key.TotalAmount;
                index++;
            }

        }
    }
}