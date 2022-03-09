<%@ Page Title="Order Details | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="WebApp.AdminSection.Orders.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Details</h2>
    <hr />
    <div class="row">
        <div class="col">
            <asp:Panel ID="pnlError" Visible="false" runat="server">
                <div class="row my-3">
                    <div class="col">
                        <div class="alert alert-danger">
                            <p>
                                <asp:Label ID="lblError" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
                <div class="row my-3">
                    <div class="col">
                        <div class="alert alert-success">
                            <p>
                                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <div class="row my-3">
        <div class="col">
            <asp:DetailsView ID="dvOrder" runat="server" CssClass="table table-striped table-bordered" AutoGenerateRows="False" DataSourceID="objOrder">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="OrderDate" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="OrderDate" SortExpression="OrderDate" />
                    <asp:BoundField DataField="Client.BusinessName" HeaderText="Client" SortExpression="ClientId" />
                    <asp:BoundField DataField="TotalAmount" DataFormatString="${0}" HeaderText="TotalAmount" SortExpression="TotalAmount" />
                </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="objOrder" runat="server" SelectMethod="GetDetails" TypeName="BusinessLogic.OrderBL">
                <SelectParameters>
                    <asp:QueryStringParameter Name="id" QueryStringField="orderId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col"></div>
        <div class="col">
            <div class="form-group">
                <label>Add Order Status</label>
                <asp:DropDownList ID="ddlOrderStatus" runat="server" CssClass="form-control" DataSourceID="objOrderStatus" DataTextField="Status" DataValueField="Id"></asp:DropDownList>
                <asp:ObjectDataSource ID="objOrderStatus" runat="server" SelectMethod="GetAll" TypeName="BusinessLogic.OrderStatusBL"></asp:ObjectDataSource>
                <asp:Button ID="btnAddOrderStatus" OnClick="btnAddOrderStatus_Click" Text="Add Order Status" CssClass="btn btn-outline-primary mt-3" runat="server" />
            </div>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col">
            <h5>Products in the Order</h5>
            <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="imgPhoto" runat="server" Height="100" ImageUrl='<%# Eval("ProductLine.PhotoUrl") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductLine.Name" HeaderText="Name Of The Company" SortExpression="Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Name" />
                    <asp:BoundField DataField="TotalProductPrice" DataFormatString="${0}" HeaderText="Total Product Price" SortExpression="Name" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col">
            <h5>Status Change of the Order</h5>
            <asp:GridView ID="grdStatus" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderStatus.Status" HeaderText="Order Status" SortExpression="Name" />
                    <asp:BoundField DataField="DateChanged" HeaderText="Date Changed" DataFormatString="{0:MMM dd, yyyy}" SortExpression="Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
