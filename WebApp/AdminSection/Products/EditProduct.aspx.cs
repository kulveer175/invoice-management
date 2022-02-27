using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessModel;

namespace WebApp.AdminSection.Products
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var product = ProductLineBL.GetDetails(Convert.ToInt32(Request.QueryString["Id"]));
                txtName.Text = product.Name;
                txtPrice.Text = product.Price.ToString();
                txtQuantityInStock.Text = product.QuantityInStock.ToString();
                imgProductPhoto.ImageUrl = product.PhotoUrl;
            }
        }

        protected void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(imgProductPhoto.ImageUrl))
            {
                Response.Write("<script>alert('No Image Uploaded.');</script>");
                return;
            }
            ProductLine product = new ProductLine
            {
                Id = Convert.ToInt32(Request.QueryString["Id"]),
                Name = txtName.Text,
                Price = Convert.ToDouble(txtPrice.Text),
                QuantityInStock = Convert.ToInt32(txtQuantityInStock.Text),
                PhotoUrl = imgProductPhoto.ImageUrl
            };
            if (ProductLineBL.Update(product))
            {
                pnlSucess.Visible = true;
            }
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (fuPhotoUrl.HasFile)
            {
                string relativePath = "~/ProductImages";
                string absolutePath = Server.MapPath(relativePath);

                string extension = System.IO.Path.GetExtension(fuPhotoUrl.FileName);

                Guid g = Guid.NewGuid();

                string pathToSave = String.Format("{0}/{1}{2}", absolutePath, g.ToString(), extension);
                fuPhotoUrl.SaveAs(pathToSave);

                string relativePathOfPhoto = string.Format("{0}/{1}{2}", relativePath, g.ToString(), extension);
                imgProductPhoto.ImageUrl = relativePathOfPhoto;
            }
        }
    }
}