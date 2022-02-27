<%@ Page Title="Edit Product | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="WebApp.AdminSection.Products.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <h2>Edit Product</h2>
    <hr />
    <asp:Panel ID="pnlSucess" Visible="false" runat="server">
        <div class="row">
            <div class="col">
                <div class="alert alert-info">
                    <p>Product Updated</p>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col">
                    <div class="row">
                        <div class="col-4">
                            <div class="form-group">
                                <label>Product Name: </label>
                                <asp:TextBox ID="txtName" required runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ControlToValidate="txtName" runat="server" ErrorMessage="Only Alphabets allowed" ValidationExpression="^[a-zA-Z\s]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>Price Per Unit: </label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">$</div>
                                    </div>
                                    <asp:TextBox ID="txtPrice" required runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RegularExpressionValidator ControlToValidate="txtPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="^[0-9]*$" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label>Quantity In Stock: </label>
                                <asp:TextBox ID="txtQuantityInStock" TextMode="Number" required runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RangeValidator MinimumValue="1" MaximumValue="Infinite" runat="server" ControlToValidate="txtQuantityInStock" ErrorMessage="Quantity should be atleast 1 or more" ForeColor="Red" Font-Bold="true" Display="Dynamic"></asp:RangeValidator>
                            </div>
                            <div class="form-group">
                                <label>Upload Photo: </label>
                                <asp:FileUpload ID="fuPhotoUrl" runat="server" CssClass="form-control-file" />
                                <asp:Button ID="btnUploadImage" OnClick="btnUploadImage_Click" runat="server" CssClass="btn btn-outline-primary mt-3" Text="Upload Image" />
                            </div>
                        </div>
                        <div class="col-6 text-center">
                            <h6>Image Uploaded: </h6>
                            <div class="row">
                                <div class="col offset-3">
                                    <div class="card" style="width: 18rem; height: 18rem;">
                                        <asp:Image ID="imgProductPhoto" runat="server" CssClass="card-img-top" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadImage" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="row">
        <div class="col">
            <asp:Button ID="btnEditProduct" OnClick="btnEditProduct_Click" runat="server" CssClass="btn btn-success" Text="Save Product" />
        </div>
    </div>
</asp:Content>
