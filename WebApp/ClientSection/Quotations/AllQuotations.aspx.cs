using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace WebApp.ClientSection.Quotations
{
    public partial class AllQuotations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hlClientId.Value = ClientBL.GetDetailsByEmailId(User.Identity.Name).Id.ToString();
            }
        }
    }
}