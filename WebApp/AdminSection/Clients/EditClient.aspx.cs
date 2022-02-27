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
    public partial class EditClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                var user = ClientBL.GetDetails(id);
                txtName.Text = user.BusinessName;
                hfClientId.Value = id.ToString();
                txtBusinessEmailId.Text = user.BusinessEmailId;
                txtFirstName.Text = user.CPFirstName;
                txtLastName.Text = user.CPLastName;
                txtPhoneNumber.Text = user.BusinessPhoneNumber;
                txtCompanyAddress.Text = user.Address;
            }
        }

        protected void btnEditClient_Click(object sender, EventArgs e)
        {
            Client client = new Client
            {
                Id = Convert.ToInt32(Request.QueryString["Id"]),
                BusinessName = txtName.Text,
                BusinessEmailId = txtBusinessEmailId.Text,
                Address = txtCompanyAddress.Text,
                BusinessPhoneNumber = txtPhoneNumber.Text,
                CPFirstName = txtFirstName.Text,
                CPLastName = txtLastName.Text,
            };
            if (ClientBL.Update(client))
            {
                pnlSucess.Visible = true;
            }
        }
    }
}