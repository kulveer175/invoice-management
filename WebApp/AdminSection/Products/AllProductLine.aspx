<%@ Page Title="All Product Line | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="AllProductLine.aspx.cs" Inherits="WebApp.AdminSection.Products.AllProductLine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Products</h2>
    <hr />
    <asp:HyperLink ID="hlAddNewProduct" NavigateUrl="~/AdminSection/Products/AddProduct.aspx"  runat="server" CssClass="btn btn-outline-info" Text="Add New Product" />
    <asp:GridView ID="grdAllClients" DataKeyNames="Id" runat="server" CssClass="table table-bordered mt-3" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="objDataSource">
        <Columns>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="imgPhoto" runat="server" Height="100" ImageUrl='<%# Eval("PhotoUrl") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name Of The Company" SortExpression="Name" />
            <asp:BoundField DataField="Price" DataFormatString="${0}" HeaderText="Price Per Unit" SortExpression="Price" />
            <asp:BoundField DataField="QuantityInStock" HeaderText="Quantity In Stock" SortExpression="QuantityInStock" />
            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EditProduct.aspx?Id={0}" />
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div class="alert alert-info">
                <p>No data to show.</p>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="objDataSource" runat="server" SelectMethod="GetAll" TypeName="BusinessLogic.ProductLineBL" DataObjectTypeName="ShriTrade.Models.Product" DeleteMethod="Delete"></asp:ObjectDataSource>
</asp:Content>
