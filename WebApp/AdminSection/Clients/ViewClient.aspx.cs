using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessModel;
using BusinessLogic;

namespace WebApp.AdminSection.Clients
{
    public partial class ViewClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                var item = ClientBL.GetDetails(Id);
                var source = new List<Client>();
                source.Add(item);

                dvClientDetails.DataSource = source;
                dvClientDetails.DataBind();

                hlAllOrders.NavigateUrl = "~/AdminSection/Orders/ViewOrdersForClient.aspx?clientId=" + Id;
            }
        }
    }
}