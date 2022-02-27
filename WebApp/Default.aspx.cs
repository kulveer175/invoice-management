using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Membership.GetUser("admin@gmail.com") == null)
            {
                Roles.CreateRole("Admin");
                Roles.CreateRole("Client");
                MembershipCreateStatus status;
                Membership.CreateUser("admin@gmail.com", "Password123!", "admin@gmail.com", "What is the your name?", "ABC", true, out status);
                Roles.AddUserToRole("admin@gmail.com", "Admin");
            }
        }

        protected void LoginControl_LoggedIn(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(LoginControl.UserName, "Admin"))
            {
                LoginControl.DestinationPageUrl = "~/AdminSection/";
            }
            else if (Roles.IsUserInRole(LoginControl.UserName, "Client"))
            {
                LoginControl.DestinationPageUrl = "~/ClientSection/";
            }
        }
    }
}