using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessModel;

namespace WebApp.AdminSection.Quotations
{
    public partial class GenerateQuotation : System.Web.UI.Page
    {
        private static readonly string ViewStateKey = "Products"; protected void ddlProducts_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            var product = ProductLineBL.GetDetails(Convert.ToInt32(ddlProducts.SelectedValue));

            if (ViewState[ViewStateKey] == null)
            {
                dt.Columns.Add("ProductId");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("ProductPrice");
                dt.Columns.Add("TotalProductPrice");

                dr = dt.NewRow();
                dr["ProductId"] = product.Id;
                dr["ProductName"] = product.Name;
                dr["ProductPrice"] = product.Price;
                dr["Quantity"] = txtQuantity.Text;
                double total = Convert.ToInt32(txtQuantity.Text) * product.Price;
                dr["TotalProductPrice"] = total;
            }
            else
            {
                dt = (DataTable)ViewState[ViewStateKey];
                dr = dt.NewRow();
                dr = dt.NewRow();
                dr["ProductId"] = product.Id;
                dr["ProductName"] = product.Name;
                dr["ProductPrice"] = product.Price;
                dr["Quantity"] = txtQuantity.Text;
                double total = Convert.ToInt32(txtQuantity.Text) * product.Price;
                dr["TotalProductPrice"] = total;
            }
            dt.Rows.Add(dr);
            ViewState[ViewStateKey] = dt;
            grdDetails.DataSource = ViewState[ViewStateKey] as DataTable;
            grdDetails.DataBind();
            ddlProducts.SelectedValue = "0";
            txtQuantity.Text = "0";
        }

        protected void btnAddQuotation_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState[ViewStateKey] as DataTable;
            var client = ClientBL.GetDetails(Convert.ToInt32(ddlClients.SelectedValue));
            var quotation = new Quotation
            {
                DateOfRequest = DateTime.Now,
                ClientId = client.Id
            };
            var details = new List<QuotationDetails>();
            double total = 0;
            foreach (DataRow row in dt.Rows)
            {
                var detail = new QuotationDetails
                {
                    ProductLineId = Convert.ToInt32(row["ProductId"]),
                    TotalProductPrice = Convert.ToDouble(row["TotalProductPrice"]),
                    Quantity = Convert.ToInt32(row["Quantity"])
                };
                total += detail.TotalProductPrice;
                details.Add(detail);
            }
            quotation.TotalPrice = total;

            int quotationId = BusinessLogic.QuotationBL.Add(quotation, details);
            if (quotationId > 0)
            {
                dt = new DataTable();
                ViewState[ViewStateKey] = dt;
                grdDetails.DataSource = ViewState[ViewStateKey] as DataTable;
                grdDetails.DataBind();
                Response.Write("<script>alert('Quotation Generated');window.location.href='./ViewQuotation.aspx?quotationId=" + quotationId + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('Error in Generating Quotation');</script>");
            }
        }

        protected void grdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = (DataTable)ViewState[ViewStateKey];
            dt.Rows[index].Delete();
            ViewState[ViewStateKey] = dt;
            grdDetails.DataSource = ViewState[ViewStateKey] as DataTable;
            grdDetails.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grdDetails.DataBind();
            }
        }
    }
}