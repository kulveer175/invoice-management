<%@ Page Title="All Stafs | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="AllStaffs.aspx.cs" Inherits="WebApp.AdminSection.Staffs.AllStafs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Staff</h2>
    <hr />
    <asp:HyperLink runat="server" CssClass="btn btn-outline-primary" Text="Add New Staff" NavigateUrl="~/AdminSection/Staffs/AddStaff.aspx"></asp:HyperLink>

    <div class="row mt-3">
        <div class="col">
            <asp:GridView ID="grdAllOfficials" DataKeyNames="Id" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataSourceID="objAllOfficials">
                <columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="EmergencyContactNumber" HeaderText="Emergency Contact Number" SortExpression="EmergencyContactNumber" />
                    <asp:BoundField DataField="HomeAddress" HeaderText="Home Address" SortExpression="HomeAddress" />
                    <asp:BoundField DataField="WorkAddress" HeaderText="Work Address" SortExpression="WorkAddress" />
                    <asp:BoundField DataField="StaffType.Name" HeaderText="Staff Type" SortExpression="StaffTypeId" />
                    <asp:HyperLinkField Text="View" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ViewStaff.aspx?staffId={0}" />
                    <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EditStaff.aspx?staffId={0}" />
                    <asp:TemplateField ShowHeader="false">
                        <itemtemplate>
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>
                        </itemtemplate>
                    </asp:TemplateField>
                </columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="objAllOfficials" runat="server" SelectMethod="GetAll" TypeName="BusinessLogic.StaffBL" DataObjectTypeName="BusinessModel.Staff" DeleteMethod="Delete"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
