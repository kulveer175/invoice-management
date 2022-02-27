using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessModel;
using BusinessLogic;
using System.Web.Security;

namespace WebApp.AdminSection.Clients
{
    public partial class AddClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            Client client = new Client
            {
                BusinessName = txtName.Text,
                BusinessEmailId = txtBusinessEmailId.Text,
                Address = txtCompanyAddress.Text,
                BusinessPhoneNumber = txtPhoneNumber.Text,
                CPFirstName = txtFirstName.Text,
                CPLastName = txtLastName.Text,
            };
            int id = ClientBL.Add(client);
            if (id > 0)
            {
                pnlSucess.Visible = true;
                if (Membership.GetUser(client.BusinessEmailId) == null)
                {
                    MembershipCreateStatus status;
                    Membership.CreateUser(client.BusinessEmailId, "Password123!", client.BusinessEmailId, "What is the your name?", "ABC", true, out status);
                    Roles.AddUserToRole(client.BusinessEmailId, "Client");
                }
                Response.Write("<script>alert('Client Details Added');window.location.href='./ViewClient.aspx?Id=" + id + "';</script>");
            }
        }
    }
}