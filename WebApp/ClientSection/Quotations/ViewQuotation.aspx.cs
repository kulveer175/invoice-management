using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Table = iText.Layout.Element.Table;
using BusinessLogic;

namespace WebApp.ClientSection.Quotations
{
    public partial class ViewQuotation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDownloadQuotation_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                String.Format("attachment;filename={0}.pdf", "Quotation Generated"));
            Response.Write(CreatePDF());
            Response.Flush();
            Response.End();
        }

        private Document CreatePDF()
        {
            PdfWriter writer = new PdfWriter(Response.OutputStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Quotation Generated")
           .SetTextAlignment(TextAlignment.CENTER)
           .SetFontSize(20);

            document.Add(header);

            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            Paragraph subheader1 = new Paragraph("Quotation Details")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);
            document.Add(subheader1);
            document.Add(GetQuotationDetails());

            Paragraph subheader2 = new Paragraph("Quotation Product Details")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(15);
            document.Add(subheader2);
            document.Add(GetQuotationProductDetails());
            document.Close();
            return document;
        }

        private iText.Layout.Element.Table GetQuotationDetails()
        {
            int columnsCount = 2;
            // Create the PDF Table specifying the number of columns
            Table pdfTable = new Table(columnsCount);

            var quotation = QuotationBL.GetDetails(Convert.ToInt32(Request.QueryString["quotationId"]));

            Cell pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Quotation Id: "));
            pdfTable.AddCell(pdfHeaderCell);
            Cell pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(quotation.Id.ToString()));
            pdfTable.AddCell(pdfCell);

            //
            pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Date Of Request: "));
            pdfTable.AddCell(pdfHeaderCell);
            pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(quotation.DateOfRequest.ToString("MMMM dd, yyyy")));
            pdfTable.AddCell(pdfCell);

            //
            pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Client Name: "));
            pdfTable.AddCell(pdfHeaderCell);
            pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(quotation.Client.BusinessName));
            pdfTable.AddCell(pdfCell);

            //
            pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Client Email: "));
            pdfTable.AddCell(pdfHeaderCell);
            pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(quotation.Client.BusinessName));
            pdfTable.AddCell(pdfCell);

            //
            pdfHeaderCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Total Price: "));
            pdfTable.AddCell(pdfHeaderCell);
            pdfCell = new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(quotation.TotalPrice.ToString()));
            pdfTable.AddCell(pdfCell);

            return pdfTable.SetHorizontalAlignment(HorizontalAlignment.CENTER);
        }

        private iText.Layout.Element.Table GetQuotationProductDetails()
        {
            int columnsCount = grdQutationDetails.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns
            Table pdfTable = new Table(columnsCount);

            // Loop thru each cell in GrdiView header row
            foreach (TableCell gridViewHeaderCell in grdQutationDetails.HeaderRow.Cells)
            {
                Cell pdfCell = new Cell()
                    .SetBackgroundColor(new DeviceRgb(System.Drawing.Color.Blue))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(gridViewHeaderCell.Text));

                pdfTable.AddCell(pdfCell);
            }

            int rowCount = 1;
            // Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in grdQutationDetails.Rows)
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
                        if (counter == 2)
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

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            var quotationDetails = QuotationDetailsBL.GetAllDetailsForQuotation(Convert.ToInt32(Request.QueryString["quotationId"]));
            foreach (var item in quotationDetails)
            {
                if (item.Quantity > item.ProductLine.QuantityInStock)
                {
                    Response.Write("<script>alert('Error! Quantity of Item is more than in stock.');</script>");
                    return;
                }
            }
            var orderId = BusinessLogic.QuotationBL.GenerateOrder(Convert.ToInt32(Request.QueryString["quotationId"]));
            if (orderId > 0)
            {
                Response.Write("<script>alert('Order Generated from Quotation');window.location.href='./../Orders/OrderDetails.aspx?orderId=" + orderId + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('Error! Order Not Generated.');</script>");
            }
        }
    }
}