﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="MyProducts.aspx.cs" Inherits="FinalProject.MyProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">My Products</h1>
    <a href="Product.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-plus fa-sm text-white-50"></i> Add product</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ListView ID="lvProducts" OnItemCommand="lvProducts_OnItemCommand" runat="server">
        <EmptyDataTemplate>
            <div class="col-md-12 text-center">There are no products.</div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="col-lg-4 mb-4">
                <!-- Illustrations -->
                <div class="card shadow mb-4">
                    <img class="card-img-top" src="uploads/<%# Eval("ProductImage").ToString()  %>">
                    <%# Eval("ProductType").ToString().ToUpper().Equals("SOLD") ? "<img class='img-sold' src='content/img/sold_ribbon.png'>" : ""%>
                    <div class="card-body">
                        <h6 class="card-title font-weight-bold text-primary"><%# Eval("ProductName")  %> </h6>
                        <p> <%# Eval("ProductDesc")  %> </p>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item"><span class="text-primary">Sold By :</span> <%# Eval("UserCompany").ToString().Length != 0 ? Eval("UserCompany") : Eval("UserFirstName") + " " + Eval("UserLastName")   %></li>
                        <li class="list-group-item"><span class="text-primary">Category :</span> <%# Eval("CategoryName")  %></li>
                        <li class="list-group-item"><span class="text-primary">Qty :</span> <%# Eval("ProductQty")  %></li>
                        <li class="list-group-item"><span class="text-primary">Brand :</span> <%# Eval("ProductBrand").ToString().Length != 0 ? Eval("ProductBrand") : "Unknown" %></li>
                    </ul>
                    <div class="card-body" >
                        <asp:LinkButton ID="btnUpdateProduct" CommandName="UpdateProduct" runat="server" CssClass="btn btn-primary float-right mr-2">Update</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" CommandName="DeleteProduct" CssClass="btn btn-danger float-right mr-2" runat="server">Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
