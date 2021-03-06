<%@ Page Title="View Quotations | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="ViewQuotation.aspx.cs" Inherits="WebApp.AdminSection.Quotations.ViewQuotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Quotation Details</h2>
    <hr />
    <asp:Label ID="lblQuotationId" runat="server" CssClass="h3"></asp:Label>
    <div class="row mt-3">
        <div class="col">
            <asp:Button ID="btnDownloadQuotation" OnClick="btnDownloadQuotation_Click" runat="server" CssClass="btn btn-outline-primary" Text="Download Quotation" />
        </div>
    </div>
    <div class="row mt-3">
        <div class="col">
            <asp:DetailsView ID="dvQuotation" runat="server" CssClass="table table-bordered table-striped" AutoGenerateRows="False" DataSourceID="objQuotation">
                <fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="DateOfRequest" HeaderText="DateOfRequest" DataFormatString="{0:MMM dd, yyyy}" SortExpression="DateOfRequest" />
                    <asp:BoundField DataField="Client.BusinessName" HeaderText="Client Name" SortExpression="ClientId" />
                    <asp:BoundField DataField="Client.BusinessEmailId" HeaderText="Client Email" SortExpression="ClientId" />
                    <asp:BoundField DataField="TotalPrice" DataFormatString="${0}" HeaderText="TotalPrice" SortExpression="TotalPrice" />
                </fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="objQuotation" runat="server" SelectMethod="GetDetails" TypeName="BusinessLogic.QuotationBL">
                <selectparameters>
                    <asp:QueryStringParameter Name="quotationId" QueryStringField="quotationId" Type="Int32" />
                </selectparameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <h3>All Products in the quotation</h3>
            <hr />
            <asp:GridView ID="grdQutationDetails" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataSourceID="objQuotationDetails">
                <columns>
                    <asp:TemplateField HeaderText="S.No">
                        <itemtemplate><%#Container.DataItemIndex+1 %></itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <itemtemplate>
                            <asp:Image ID="imgPhoto" runat="server" Height="100" ImageUrl='<%# Eval("ProductLine.PhotoUrl") %>' />
                        </itemtemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductLine.Name" HeaderText="Product" SortExpression="ProductId" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="TotalProductPrice" DataFormatString="${0}" HeaderText="TotalProductPrice" SortExpression="TotalProductPrice" />
                </columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="objQuotationDetails" runat="server" SelectMethod="GetAllDetailsForQuotation" TypeName="BusinessLogic.QuotationDetailsBL">
                <selectparameters>
                    <asp:QueryStringParameter Name="quotationId" QueryStringField="quotationId" Type="Int32" />
                </selectparameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
