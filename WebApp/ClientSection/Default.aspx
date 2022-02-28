<%@ Page Title="Client Home | Invoice Management" Language="C#" MasterPageFile="~/ClientSectionLayout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.ClientSection.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>All Orders</h2>
    <hr />
    <h4>
        <asp:Label ID="lblCompany" Font-Bold="true" runat="server"></asp:Label></h4>
    <div class="row">
        <div class="col">
            <asp:GridView ID="grdAllClients" OnRowDataBound="grdAllClients_RowDataBound" runat="server" CssClass="table table-bordered mt-3" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Order Id" SortExpression="Id" />
                    <asp:BoundField DataField="OrderDate" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="OrderDate" SortExpression="OrderDate" />
                    <asp:BoundField DataField="TotalAmount" DataFormatString="${0}" HeaderText="TotalAmount" SortExpression="TotalAmount" />
                    <asp:HyperLinkField Text="View" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Orders/OrderDetails.aspx?orderId={0}" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="alert alert-info">
                        <p>No data to show.</p>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.11.1/css/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/2.0.0/css/buttons.bootstrap4.min.css" />
    
    <script src="https://cdn.datatables.net/1.11.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.11.1/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.0.0/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.0.0/js/buttons.bootstrap4.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.0.0/js/buttons.html5.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#<%= grdAllClients.ClientID%>').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'csv', 'excel'
                ]
            });
        });
    </script>
</asp:Content>
