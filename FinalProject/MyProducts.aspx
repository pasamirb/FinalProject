<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="MyProducts.aspx.cs" Inherits="FinalProject.MyProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">My Products</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ListView ID="lvProducts" OnItemCommand="lvProducts_OnItemCommand" runat="server">
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
                        
                        <a id="btnUpdateProduct" href="Product.aspx?ProductId=<%#Eval("ProductId") %>" class="btn btn-primary float-right mr-2">Update</a>
                        <asp:LinkButton ID="btnDelete" CommandName="Delete" CssClass="btn btn-danger float-right mr-2" runat="server">Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
