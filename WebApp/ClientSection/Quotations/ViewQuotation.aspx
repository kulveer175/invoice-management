<%@ Page Title="" Language="C#" MasterPageFile="~/ClientSectionLayout.Master" AutoEventWireup="true" CodeBehind="ViewQuotation.aspx.cs" Inherits="WebApp.ClientSection.Quotations.ViewQuotation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Quotation Details</h2>
    <hr />
    <asp:Label ID="lblQuotationId" runat="server" CssClass="h3"></asp:Label>
    <div class="row mt-3">
        <div class="col">
            <asp:Button ID="btnDownloadQuotation" OnClick="btnDownloadQuotation_Click" runat="server" CssClass="btn btn-outline-primary" Text="Download Quotation" />
            <asp:Button ID="btnPlaceOrder" runat="server" OnClick="btnPlaceOrder_Click" CssClass="btn btn-outline-success" Text="Place Order" />
        </div>
    </div>
    <div class="row mt-3">
        <div class="col">
            <asp:DetailsView ID="dvQuotation" runat="server" CssClass="table table-bordered table-striped" AutoGenerateRows="False" DataSourceID="objQuotation">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="DateOfRequest" HeaderText="DateOfRequest" DataFormatString="{0:MMM dd, yyyy}" SortExpression="DateOfRequest" />
                    <asp:BoundField DataField="Client.BusinessName" HeaderText="Client Name" SortExpression="ClientId" />
                    <asp:BoundField DataField="Client.BusinessEmailId" HeaderText="Client Email" SortExpression="ClientId" />
                    <asp:BoundField DataField="TotalPrice" DataFormatString="${0}" HeaderText="TotalPrice" SortExpression="TotalPrice" />
                </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="objQuotation" runat="server" SelectMethod="GetDetails" TypeName="BusinessLogic.QuotationBL">
                <SelectParameters>
                    <asp:QueryStringParameter Name="quotationId" QueryStringField="quotationId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <h3>All Products in the quotation</h3>
            <hr />
            <asp:GridView ID="grdQutationDetails" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataSourceID="objQuotationDetails">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="imgPhoto" runat="server" Height="100" ImageUrl='<%# Eval("ProductLine.PhotoUrl") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductLine.Name" HeaderText="Product" SortExpression="ProductId" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="TotalProductPrice" DataFormatString="${0}" HeaderText="TotalProductPrice" SortExpression="TotalProductPrice" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="objQuotationDetails" runat="server" SelectMethod="GetAllDetailsForQuotation" TypeName="BusinessLogic.QuotationDetailsBL">
                <SelectParameters>
                    <asp:QueryStringParameter Name="quotationId" QueryStringField="quotationId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
