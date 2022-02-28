using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Table = iText.Layout.Element.Table;

namespace WebApp.ClientSection.Orders
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                btnPay.NavigateUrl = btnPay.NavigateUrl + "?orderId=" + orderId;
                var orderDetails = OrderDetailsBL.GetOrderDetailsForOrder(orderId);

                grdProducts.DataSource = orderDetails;
                grdProducts.DataBind();

                var orderXStatus = OrderXStatusBL.GetStatusForOrder(orderId);
                grdStatus.DataSource = orderXStatus;
                grdStatus.DataBind();
            }
        }

        protected void btnDownloadInvoice_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                String.Format("attachment;filename={0}.pdf", "Order Invoice"));
            Response.Write(CreatePDF());
            Response.Flush();
            Response.End();
        }

        private Document CreatePDF()
        {
            // Create the PDF document specifying page size and margins
            PdfWriter writer = new PdfWriter(Response.OutputStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Order Invoice")
           .SetTextAlignment(TextAlignment.CENTER)
           .SetFontSize(20);

            document.Add(header);

            document.Add(new Paragraph("Order Id: " + Request.QueryString["orderId"]).SetTextAlignment(TextAlignment.CENTER));

            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            document.Add(GetOrderDetails());

            Paragraph subheader1 = new Paragraph("Products in the Order")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);
            document.Add(subheader1);
            document.Add(TableRender(grdProducts));

            Paragraph subheader2 = new Paragraph("Status Change for the Order")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);
            document.Add(subheader2);
            document.Add(TableRender(grdStatus));

            document.Close();
            return document;
        }

        private iText.Layout.Element.Table GetOrderDetails()
        {
            int columnsCount = 2;
            // Create the PDF Table specifying the number of columns
            Table pdfTable = new Table(columnsCount);

            var order = OrderBL.GetDetails(Convert.ToInt32(Request.QueryString["orderId"]));


            //
            Cell pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Order Date: "));
            pdfTable.AddCell(pdfHeaderCell);
            Cell pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(order.OrderDate.ToString("MMMM dd, yyyy")));
            pdfTable.AddCell(pdfCell);

            //
            pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Client Name: "));
            pdfTable.AddCell(pdfHeaderCell);
            pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(order.Client.BusinessName));
            pdfTable.AddCell(pdfCell);

            //
            pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Client Email: "));
            pdfTable.AddCell(pdfHeaderCell);
            pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(order.Client.BusinessEmailId));
            pdfTable.AddCell(pdfCell);

            //
            pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Total Amount: "));
            pdfTable.AddCell(pdfHeaderCell);
            pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(order.TotalAmount.ToString()));
            pdfTable.AddCell(pdfCell);

            return pdfTable.SetHorizontalAlignment(HorizontalAlignment.CENTER);
        }

        private iText.Layout.Element.Table TableRender(GridView grd)
        {
            int columnsCount = grd.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns
            Table pdfTable = new Table(columnsCount);

            // Loop thru each cell in GrdiView header row
            foreach (TableCell gridViewHeaderCell in grd.HeaderRow.Cells)
            {
                Cell pdfCell = new Cell()
                    .SetBackgroundColor(new DeviceRgb(System.Drawing.Color.Blue))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(gridViewHeaderCell.Text));

                pdfTable.AddCell(pdfCell);
            }

            int rowCount = 1;
            // Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in grd.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    int counter = 1;
                    // Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Cell pdfCell = new Cell()
                            .SetTextAlignment(TextAlignment.CENTER);

                        // Generate Sno
                        if (counter == 1)
                        {
                            pdfCell.Add(new Paragraph(rowCount.ToString()));
                        }
                        if (grd == grdProducts && counter == 2)
                        {
                            var image = gridViewCell.FindControl("imgPhoto") as System.Web.UI.WebControls.Image;

                            if (!String.IsNullOrEmpty(image.ImageUrl))
                            {
                                ImageData data = ImageDataFactory.Create(Server.MapPath(image.ImageUrl));
                                iText.Layout.Element.Image img = new iText.Layout.Element.Image(data);
                                pdfCell.Add(img.SetHeight(100));
                            }
                        }
                        else
                        {
                            pdfCell.Add(new Paragraph(gridViewCell.Text));
                        }
                        pdfTable.AddCell(pdfCell);
                        counter++;
                    }
                    rowCount++;
                }
            }
            return pdfTable.SetHorizontalAlignment(HorizontalAlignment.CENTER);
        }
    }
}