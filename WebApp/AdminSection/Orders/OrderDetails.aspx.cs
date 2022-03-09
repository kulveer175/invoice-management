using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessModel;

namespace WebApp.AdminSection.Orders
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        private static List<OrderXStatus> orderXStatus;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                var orderDetails = OrderDetailsBL.GetOrderDetailsForOrder(orderId);

                grdProducts.DataSource = orderDetails;
                grdProducts.DataBind();

                BindOrderStatusGridView(orderId);
            }
        }

        private void BindOrderStatusGridView(int orderId)
        {
            orderXStatus = OrderXStatusBL.GetStatusForOrder(orderId);
            grdStatus.DataSource = orderXStatus;
            grdStatus.DataBind();
        }

        protected void btnAddOrderStatus_Click(object sender, EventArgs e)
        {
            pnlSuccess.Visible = false;
            pnlError.Visible = false;
            var isFound = false;
            int selectedId = Convert.ToInt32(ddlOrderStatus.SelectedValue);
            foreach (var status in orderXStatus)
            {
                if (status.OrderStatusId == selectedId)
                {
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                pnlError.Visible = true;
                lblError.Text = "Status already added.";
            }
            else
            {
                var oxs = new OrderXStatus
                {
                    DateChanged = DateTime.Now,
                    OrderId = Convert.ToInt32(Convert.ToInt32(Request.QueryString["orderId"])),
                    OrderStatusId = selectedId,
                };

                if (OrderXStatusBL.AddOrderXStatus(oxs))
                {
                    BindOrderStatusGridView(oxs.OrderId);
                    pnlSuccess.Visible = true;
                    lblSuccess.Text = "Status Added successfully.";
                }
                else
                {
                    pnlError.Visible = true;
                    lblError.Text = "Error in addind status.";
                }
            }
        }
    }
}