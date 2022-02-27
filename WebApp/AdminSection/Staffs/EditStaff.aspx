<%@ Page Title="Edit Official | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="EditStaff.aspx.cs" Inherits="WebApp.AdminSection.Staffs.EditStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit Official</h2>
    <hr />
    <div class="row">
        <div class="col">
            <div class="form-group">
                <label>First Name:</label>
                <asp:TextBox ID="txtFirstName" runat="server" required CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtFirstName" runat="server" ErrorMessage="Only Alphabets allowed" ValidationExpression="^[a-zA-Z\s]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>Last Name:</label>
                <asp:TextBox ID="txtLastName" runat="server" required CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtLastName" runat="server" ErrorMessage="Only Alphabets allowed" ValidationExpression="^[a-zA-Z\s]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>EmailId:</label>
                <asp:TextBox ID="txtEmail" TextMode="Email" required runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Phone Number:</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" required CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtPhoneNumber" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="^[0-9]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>Emergency Contact Number:</label>
                <asp:TextBox ID="txtEmergencyContactNumber" required runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtEmergencyContactNumber" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="^[0-9]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>Home Address:</label>
                <asp:TextBox ID="txtHomeAddress" runat="server" required CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Work Address:</label>
                <asp:TextBox ID="txtWorkAddress" runat="server" required CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Staff Type:</label>
                <asp:DropDownList ID="ddlStaffType" runat="server" CssClass="form-control" DataSourceID="objStaffType" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                <asp:ObjectDataSource ID="objStaffType" runat="server" SelectMethod="GetAll" TypeName="BusinessLogic.StaffBL"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col">
            <asp:Button ID="btnEdit" OnClick="btnEdit_Click" runat="server" CssClass="btn btn-success" Text="Save Staff" />
        </div>
    </div>
</asp:Content>
