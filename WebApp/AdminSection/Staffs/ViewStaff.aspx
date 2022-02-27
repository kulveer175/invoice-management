<%@ Page Title="View Staff | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="ViewStaff.aspx.cs" Inherits="WebApp.AdminSection.Staffs.ViewStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View Staff</h2>
    <hr />
    <div class="row">
        <div class="col">
            <asp:DetailsView ID="dvOfficial" runat="server" AutoGenerateRows="false" CssClass="table table-bordered table-striped" DataSourceID="dvDetails">
                <Fields>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="EmergencyContactNumber" HeaderText="Emergency Contact Number" SortExpression="EmergencyContactNumber" />
                    <asp:BoundField DataField="HomeAddress" HeaderText="Home Address" SortExpression="HomeAddress" />
                    <asp:BoundField DataField="WorkAddress" HeaderText="Work Address" SortExpression="WorkAddress" />
                    <asp:BoundField DataField="StaffType.Name" HeaderText="Staff Type" SortExpression="StaffTypeId" />
                </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="dvDetails" runat="server" SelectMethod="GetDetails" TypeName="BusinessLogic.StaffBL">
                <SelectParameters>
                    <asp:QueryStringParameter Name="id" QueryStringField="staffId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
