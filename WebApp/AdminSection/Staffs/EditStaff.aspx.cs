using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessModel;
using BusinessLogic;

namespace WebApp.AdminSection.Staffs
{
    public partial class EditStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["staffId"];
                if (!String.IsNullOrEmpty(id))
                {
                    var official = StaffBL.GetDetails(Convert.ToInt32(id));
                    txtFirstName.Text = official.FirstName;
                    txtLastName.Text = official.LastName;
                    txtEmail.Text = official.EmailId;
                    txtPhoneNumber.Text = official.PhoneNumber;
                    txtEmergencyContactNumber.Text = official.EmergencyContactNumber;
                    txtHomeAddress.Text = official.HomeAddress;
                    txtWorkAddress.Text = official.WorkAddress;
                    ddlStaffType.SelectedValue = official.StaffTypeId.ToString();
                }
                else
                {
                    Response.Redirect("~/AdminSection/Staffs/AllStaffs.aspx");
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Staff official = new Staff
            {
                Id = Convert.ToInt32(Request.QueryString["officialId"]),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                EmailId = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                EmergencyContactNumber = txtEmergencyContactNumber.Text,
                HomeAddress = txtHomeAddress.Text,
                WorkAddress = txtWorkAddress.Text,
                StaffTypeId = Convert.ToInt32(ddlStaffType.SelectedValue)
            };
            if (StaffBL.Update(official))
            {
                Response.Redirect("~/Admin/Officials/ViewOfficial.aspx?officialId?=" + official.Id);
            }
        }
    }
}