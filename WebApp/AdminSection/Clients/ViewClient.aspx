<%@ Page Title="View Client | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" Inherits="WebApp.AdminSection.Clients.ViewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Client Details</h2>
    <hr />
    <asp:HyperLink ID="hlBackToAllClients" runat="server" NavigateUrl="~/AdminSection/Clients/AllClients.aspx" Text="Back To All Clients"></asp:HyperLink>
    <div class="row">
        <div class="col-5">
            <asp:HyperLink ID="hlAllOrders" runat="server" CssClass="btn btn-outline-info my-3" Text="View All Orders"></asp:HyperLink>
            <asp:DetailsView ID="dvClientDetails" runat="server" AutoGenerateRows="false" CssClass="mt-3 table table-bordered">
                <Fields>
                    <asp:BoundField DataField="BusinessName" HeaderText="Business Name" SortExpression="BusinessName" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="BusinessEmailId" HeaderText="Business Email Id" SortExpression="BusinessEmailId" />
                    <asp:BoundField DataField="BusinessPhoneNumber" HeaderText="Business Phone Number" SortExpression="BusinessPhoneNumber" />
                    <asp:BoundField DataField="CPFirstName" HeaderText="Contact Person First Name" SortExpression="CPFirstName" />
                    <asp:BoundField DataField="CPLastName" HeaderText="Contact Person Last Name" SortExpression="CPLastName" />
                    <asp:BoundField DataField="CPFullName" HeaderText="Contact Person Full Name" ReadOnly="True" SortExpression="CPFullName" />
                </Fields>
            </asp:DetailsView>
        </div>
    </div>
</asp:Content>
