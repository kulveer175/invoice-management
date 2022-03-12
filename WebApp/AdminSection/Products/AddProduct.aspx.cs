using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessModel;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace WebApp.AdminSection.Products
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(imgProductPhoto.ImageUrl))
            {
                Response.Write("<script>alert('No Image Uploaded.');</script>");
                return;
            }
            ProductLine product = new ProductLine
            {
                Name = txtName.Text,
                Price = Convert.ToDouble(txtPrice.Text),
                QuantityInStock = Convert.ToInt32(txtQuantityInStock.Text),
                PhotoUrl = imgProductPhoto.ImageUrl
            };
            if (ProductLineBL.Add(product))
            {
                pnlSucess.Visible = true;
            }
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (fuPhotoUrl.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fuPhotoUrl.FileName);

                Guid g = Guid.NewGuid();

                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=invoicemanagementstorage;AccountKey=Nn+5JclBDuuEFHpiPEIeDLH398lpbFdDcgIgrWb53rh74icwHXTxVCzs98NKPi0NysBh/ZYWx7+7+AStyntfaQ==;EndpointSuffix=core.windows.net");
                var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

                var cloudBlobContainer = cloudBlobClient.GetContainerReference("productimages");
                cloudBlobContainer.CreateIfNotExists();
                cloudBlobContainer.SetPermissions(new BlobContainerPermissions
                { 
                    PublicAccess = BlobContainerPublicAccessType.Blob 
                });

                var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(String.Format("{0}{1}",g.ToString(),extension));
                cloudBlockBlob.UploadFromStream(fuPhotoUrl.FileContent);

                string finalPath = "https://invoicemanagementstorage.blob.core.windows.net/productimages/"+ String.Format("{0}{1}", g.ToString(), extension);

                imgProductPhoto.ImageUrl = finalPath;
            }
        }
    }
}