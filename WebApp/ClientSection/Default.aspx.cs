using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessModel;
using BusinessLogic;

namespace WebApp.ClientSection
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int clientId = ClientBL.GetDetailsByEmailId(User.Identity.Name).Id;
                var orders = OrderBL.GetOrdersForClient(clientId);
                grdAllClients.DataSource = orders;
                grdAllClients.DataBind();
            }
        }

        protected void grdAllClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}