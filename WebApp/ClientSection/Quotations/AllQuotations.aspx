<%@ Page Title="All Quotations | Invoice Mangement" Language="C#" MasterPageFile="~/ClientSectionLayout.Master" AutoEventWireup="true" CodeBehind="AllQuotations.aspx.cs" Inherits="WebApp.ClientSection.Quotations.AllQuotations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Quotations</h2>
    <hr />
    <asp:HiddenField ID="hlClientId" runat="server" />
    <div class="row mt-3">
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
                    <asp:ControlParameter ControlID="hlClientId" Name="clientId" PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
