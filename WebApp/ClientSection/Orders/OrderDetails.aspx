<%@ Page Title="" Language="C#" MasterPageFile="~/ClientSectionLayout.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="WebApp.ClientSection.Orders.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Details</h2>
    <hr />
    <div class="row my-3">
        <div class="col">
            <asp:Button ID="btnDownloadInvoice" OnClick="btnDownloadInvoice_Click" runat="server" CssClass="btn btn-link" Text="Download Invoice (Pdf)" />
            <asp:HyperLink ID="btnPay" NavigateUrl="~/Client/Orders/Payment.aspx" runat="server" CssClass="btn btn-outline-success" Text="Pay for the Order" />
        </div>
    </div>
    <div class="row my-3">
        <div class="col">
            <asp:DetailsView ID="dvOrder" runat="server" CssClass="table table-striped table-bordered" AutoGenerateRows="False" DataSourceID="objOrder">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="OrderDate" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="OrderDate" SortExpression="OrderDate" />
                    <asp:BoundField DataField="Client.BusinessName" HeaderText="Client" SortExpression="ClientId" />
                    <asp:BoundField DataField="TotalAmount" DataFormatString="${0}" HeaderText="TotalAmount" SortExpression="TotalAmount" />
                </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="objOrder" runat="server" SelectMethod="GetDetails" TypeName="BusinessLogic.OrderBL">
                <SelectParameters>
                    <asp:QueryStringParameter Name="id" QueryStringField="orderId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <h5>Products in the Order</h5>
            <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="imgPhoto" runat="server" Height="100" ImageUrl='<%# Eval("ProductLine.PhotoUrl") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductLine.Name" HeaderText="Name Of The Company" SortExpression="Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Name" />
                    <asp:BoundField DataField="TotalProductPrice" DataFormatString="${0}" HeaderText="Total Product Price" SortExpression="Name" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col">
            <h5>Status Change of the Order</h5>
            <asp:GridView ID="grdStatus" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderStatus.Status" HeaderText="Order Status" SortExpression="Name" />
                    <asp:BoundField DataField="DateChanged" HeaderText="Date Changed" DataFormatString="{0:MMM dd, yyyy}" SortExpression="Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
