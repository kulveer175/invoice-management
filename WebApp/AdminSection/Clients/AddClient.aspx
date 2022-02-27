<%@ Page Title="Add Client | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="WebApp.AdminSection.Clients.AddClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Client</h2>
    <hr />
    <asp:Panel ID="pnlSucess" Visible="false" runat="server">
        <div class="row">
            <div class="col">
                <div class="alert alert-info">
                    <p>Client Added</p>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="row">
        <div class="col-4">
            <div class="form-group">
                <label>Company Name: </label>
                <asp:TextBox ID="txtName" required runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtName" runat="server" ErrorMessage="Only Alphabets allowed" ValidationExpression="^[a-zA-Z\s]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>Company Address: </label>
                <asp:TextBox ID="txtCompanyAddress" required runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Contact Person First Name: </label>
                <asp:TextBox ID="txtFirstName" required runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtFirstName" runat="server" ErrorMessage="Only Alphabets allowed" ValidationExpression="^[a-zA-Z\s]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>Contact Person Last Name: </label>
                <asp:TextBox ID="txtLastName" required runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtLastName" runat="server" ErrorMessage="Only Alphabets allowed" ValidationExpression="^[a-zA-Z\s]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>Email Id: </label>
                <asp:TextBox TextMode="Email" required ID="txtBusinessEmailId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>PhoneNumber: </label>
                <asp:TextBox ID="txtPhoneNumber" required runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtPhoneNumber" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="^[0-9]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <asp:Button ID="btnAddClient" OnClick="btnAddClient_Click" runat="server" CssClass="btn btn-success" Text="Add Client" />
        </div>
    </div>
</asp:Content>
