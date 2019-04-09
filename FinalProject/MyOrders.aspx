<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="FinalProject.MyOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">My Orders</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ListView ID="lvProducts" runat="server">
        <EmptyDataTemplate>
            <div class="col-md-12 text-center">There are no products.</div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="col-lg-4 mb-4">
                <!-- Illustrations -->
                <div class="card shadow mb-4">
                    <img class="card-img-top" src="content/img/laptop.jpg">
                    <%# Eval("ProductType").ToString().ToUpper().Equals("SOLD") ? "<img class='img-sold' src='content/img/sold_ribbon.png'>" : ""%>
                    <div class="card-body">
                        <h6 class="card-title font-weight-bold text-primary"><%# Eval("ProductName")  %> </h6>
                        <p> <%# Eval("ProductDesc")  %> </p>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item"><span class="text-primary">Sold By :</span> <%# Eval("UserCompany").ToString().Length != 0 ? Eval("UserCompany") : Eval("UserFirstName") + " " + Eval("UserLastName")   %></li>
                        <li class="list-group-item"><span class="text-primary">Category :</span> <%# Eval("CategoryName")  %></li>
                        <li class="list-group-item"><span class="text-primary">Qty :</span> <%# Eval("Qty")  %></li>
                        <li class="list-group-item"><span class="text-primary">Brand :</span> <%# Eval("ProductBrand").ToString().Length != 0 ? Eval("ProductBrand") : "Unknown" %></li>
                    </ul>
                    
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
