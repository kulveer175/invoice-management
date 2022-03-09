using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace WebApp.AdminSection.Orders
{
    public partial class ViewOrdersForClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblCompany.Text = ClientBL.GetDetails(Convert.ToInt32(Request.QueryString["clientId"])).BusinessName;
            }
        }
    }
}