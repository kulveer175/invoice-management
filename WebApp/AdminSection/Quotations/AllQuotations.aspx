<%@ Page Title="All Quotations | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="AllQuotations.aspx.cs" Inherits="WebApp.AdminSection.Quotations.AllQuotations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Quotations for Client</h2>
    <hr />
    <div class="row my-3">
        <div class="col">
            <asp:HyperLink runat="server" CssClass="btn btn-outline-primary" NavigateUrl="~/AdminSection/Quotations/GenerateQuotation.aspx" Text="Generate Quotation"></asp:HyperLink>
        </div>
    </div>
    <div class="row my-3">
        <div class="col-4">
            <div class="form-group">
                <label>Select Client: </label>
                <asp:DropDownList ID="ddlClients" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="objClients" DataTextField="BusinessName" DataValueField="Id"></asp:DropDownList>
                <asp:ObjectDataSource ID="objClients" runat="server" SelectMethod="GetAll" TypeName="BusinessLogic.ClientBL"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <asp:GridView ID="grdAllQutations" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataSourceID="objAllQuotations">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="DateOfRequest" HeaderText="DateOfRequest" DataFormatString="{0:MMM dd, yyyy}" SortExpression="DateOfRequest" />
                    <asp:BoundField DataField="TotalPrice" DataFormatString="${0}" HeaderText="TotalPrice" SortExpression="TotalPrice" />
                    <asp:CheckBoxField DataField="OrderCreated" HeaderText="Order Created" SortExpression="TotalPrice" />
                    <asp:HyperLinkField Text="View Quotation" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ViewQuotation.aspx?quotationId={0}" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="alert alert-info">
                        <p>No quotations to show.</p>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="objAllQuotations" runat="server" SelectMethod="GetAllByClient" TypeName="BusinessLogic.QuotationBL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlClients" Name="clientId" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
