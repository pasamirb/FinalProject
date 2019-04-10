<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="FinalProject.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">Add Products</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card shadow col-md-12">
        <div class="card-body">
            <div class="form-group row">
                <asp:Label ID="lblProductName" CssClass="col-sm-2 col-form-label" runat="server" Text="Product Name:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtProductName" type="text" runat="server" CssClass="form-control" placeholder="Enter Product name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtProductName" CssClass="text-danger" ControlToValidate="txtProductName" Text="Required Field!" runat="server" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblProductDesc" CssClass="col-sm-2 col-form-label" runat="server" Text="Product Description:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPtoductDesc" type="text" TextMode="MultiLine" Columns="50" Rows="5" runat="server" CssClass="form-control" placeholder="Enter Product Decription"></asp:TextBox>                    
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblQty" CssClass="col-sm-2 col-form-label" runat="server" Text="Product Quantity:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtProductQty" type="number" runat="server" CssClass="form-control" placeholder="Enter Product Quantity" Text="1"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblProductType" CssClass="col-sm-2 col-form-label" runat="server" Text="Product Type:"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlProductType" CssClass="form-control" runat="server">
                        <asp:ListItem Selected="True">Available</asp:ListItem>
                        <asp:ListItem>Sold</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblProductPrice" CssClass="col-sm-2 col-form-label" runat="server" Text="Product Price:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtProductPrice" runat="server" CssClass="form-control" placeholder="Enter Product Price" TextMode="SingleLine" ValidationGroup="^[0-9]+(\.[0-9][0-9]?)?$"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtProductPrice" ControlToValidate="txtProductPrice" CssClass="text-danger" Text="Required Field!" runat="server" Display="Dynamic" />
                    <asp:RegularExpressionValidator id="revProductPrice" runat="server" ControlToValidate="txtProductPrice" CssClass="text-danger" ErrorMessage="Enter a valid price" ValidationExpression="^\d+\.?\d*$" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblProductBrand" CssClass="col-sm-2 col-form-label" runat="server" Text="Product Brand:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtProductBrand" type="text" runat="server" CssClass="form-control" placeholder="Enter Product Brand"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblProductImage" CssClass="col-sm-2 col-form-label" runat="server" Text="Product Image:"></asp:Label>
                <div class="col-sm-10">
                    <asp:FileUpload ID="flProductImage" runat="server" CssClass="form-control-file" />  
                    <asp:RegularExpressionValidator ID="revProductImage" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.png)$"
                    ControlToValidate="flProductImage" runat="server" CssClass="text-danger" ErrorMessage="Please select a valid image file."
                    Display="Dynamic" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblProductCategory" CssClass="col-sm-2 col-form-label" runat="server" Text="Product Category:"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlProductCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddlProductCategory" ControlToValidate="ddlProductCategory" InitialValue="Select Category" Text="Required Field!" runat="server" Display="Dynamic" />
                </div>
            </div>
            <asp:Button ID="btnAddProduct" CssClass="btn btn-primary" runat="server" OnClick="btnAddProduct_Click" />
        </div>
    </div>
</asp:Content>
