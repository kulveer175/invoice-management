using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.AdminSection.Staffs
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["staffId"];
                if (String.IsNullOrEmpty(id))
                {
                    Response.Redirect("~/Admin/Officials/AllOfficials.aspx");
                }
            }
        }
    }
}