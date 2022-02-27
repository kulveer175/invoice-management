<%@ Page Title="All Clients | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="AllClients.aspx.cs" Inherits="WebApp.AdminSection.Clients.AllClients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Clients</h2>
    <hr />
    <asp:HyperLink ID="hlAddNewClient" NavigateUrl="~/AdminSection/Clients/AddClient.aspx"  runat="server" CssClass="btn btn-outline-info" Text="Add New Client" />
    <asp:GridView ID="grdAllClients" DataKeyNames="Id" runat="server" CssClass="table table-bordered mt-3" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="objDataSource">
        <Columns>
            <asp:BoundField DataField="BusinessName" HeaderText="Business Name" SortExpression="BusinessName" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="BusinessEmailId" HeaderText="Business Email Id" SortExpression="BusinessEmailId" />
            <asp:BoundField DataField="BusinessPhoneNumber" HeaderText="Business Phone Number" SortExpression="BusinessPhoneNumber" />
            <asp:BoundField DataField="CPFullName" HeaderText="Contact Person Full Name" ReadOnly="True" SortExpression="CPFullName" />
            <asp:HyperLinkField Text="View" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ViewClient.aspx?Id={0}" />
            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EditClient.aspx?Id={0}" />
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
    <asp:ObjectDataSource ID="objDataSource" runat="server" SelectMethod="GetAll" TypeName="BusinessLogic.ClientBL" DataObjectTypeName="BusinessModel.Client" DeleteMethod="Delete"></asp:ObjectDataSource>
</asp:Content>
