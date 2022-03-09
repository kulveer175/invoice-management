<%@ Page Title="View Orders For Client | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="ViewOrdersForClient.aspx.cs" Inherits="WebApp.AdminSection.Orders.ViewOrdersForClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Orders</h2>
    <hr />
    <h4>
        <asp:Label ID="lblCompany" Font-Bold="true" runat="server"></asp:Label></h4>
    <div class="row">
        <div class="col">
            <asp:GridView ID="grdAllClients" runat="server" CssClass="table table-bordered mt-3" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="objDataSource">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Order Id" SortExpression="Id" />
                    <asp:BoundField DataField="TotalAmount" DataFormatString="${0}" HeaderText="TotalAmount" SortExpression="TotalAmount" />
                    <asp:HyperLinkField Text="View" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="OrderDetails.aspx?orderId={0}" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="alert alert-info">
                        <p>No data to show.</p>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="objDataSource" runat="server" SelectMethod="GetOrdersForClient" TypeName="BusinessLogic.OrderBL">
                <SelectParameters>
                    <asp:QueryStringParameter Name="clientId" QueryStringField="clientId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
