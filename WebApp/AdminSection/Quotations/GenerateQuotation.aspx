<%@ Page Title="Generate Quotation | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="GenerateQuotation.aspx.cs" Inherits="WebApp.AdminSection.Quotations.GenerateQuotation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Generate Quotation</h3>
    <hr />
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row my-3">
        <div class="col-4">
            <div class="form-group">
                <label>Select Client: </label>
                <asp:DropDownList ID="ddlClients" runat="server" CssClass="form-control" DataSourceID="objClients" DataTextField="BusinessName" DataValueField="Id"></asp:DropDownList>
                <asp:ObjectDataSource ID="objClients" runat="server" SelectMethod="GetAll" TypeName="BusinessLogic.ClientBL"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                <label>Select Product: </label>
                                <asp:DropDownList ID="ddlProducts" required runat="server" OnDataBound="ddlProducts_DataBound" CssClass="form-control" DataSourceID="objProducts" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                <asp:ObjectDataSource ID="objProducts" runat="server" SelectMethod="GetAll" TypeName="BusinessLogic.ProductLineBL"></asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label>Quantity: </label>
                                <asp:TextBox ID="txtQuantity" runat="server" Text="0" required CssClass="form-control" TextMode="Number" placeholder="Quantity of Product"></asp:TextBox>
                                <asp:RangeValidator Display="Dynamic" ValidationGroup="Validate" MinimumValue="2" Type="Integer" MaximumValue="100" runat="server" ControlToValidate="txtQuantity" ErrorMessage="The quantity needs to be more than 2 and less than 100" Font-Bold="true" ForeColor="Red"></asp:RangeValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Button ID="btnAdd" runat="server" ValidationGroup="Validate" OnClick="btnAdd_Click" CssClass="btn btn-outline-success" Text="Add" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-6">
                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" OnRowDeleting="grdDetails_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="ProductPrice" DataFormatString="${0}" HeaderText="Product Per Unit Price" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="TotalProductPrice" DataFormatString="${0}" HeaderText="Total Product Price" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-link" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div class="alert alert-info">
                                <p>Add products from above.</p>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="row">
        <div class="col">
            <asp:Button ID="btnAddQuotation" formnovalidate runat="server" OnClick="btnAddQuotation_Click" CssClass="btn btn-success" Text="Submit" />
        </div>
    </div>
</asp:Content>
