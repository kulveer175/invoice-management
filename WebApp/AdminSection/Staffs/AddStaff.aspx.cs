using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessModel;
using System.Web.Security;

namespace WebApp.AdminSection.Staffs
{
    public partial class AddStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                EmailId = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                EmergencyContactNumber = txtEmergencyContactNumber.Text,
                HomeAddress = txtHomeAddress.Text,
                WorkAddress = txtWorkAddress.Text,
                StaffTypeId = Convert.ToInt32(ddlStaffType.SelectedValue)
            };
            if (StaffBL.Add(staff))
            {
                if (Membership.GetUser(staff.EmailId) == null)
                {
                    MembershipCreateStatus status;
                    Membership.CreateUser(staff.EmailId, "Password123!", staff.EmailId, "What is the your name?", "ABC", true, out status);
                    Roles.AddUserToRole(staff.EmailId, ddlStaffType.SelectedItem.Text);
                }
                Response.Write("<script>alert('Staff Details Added');window.location.href='./AllStaffs.aspx';</script>");
            }
        }
    }
}