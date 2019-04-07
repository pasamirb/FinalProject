﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalProject.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">Explore Products</h1>
    <a href="AddProduct.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-plus fa-sm text-white-50"></i> Add product</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Content Column -->

    <asp:ListView ID="lvProducts" OnItemCommand="lvProducts_OnItemCommand" runat="server">
        <ItemTemplate>
            <div class="col-lg-4 mb-4">
                <!-- Illustrations -->
                <div class="card shadow mb-4">
                    <img class="card-img-top" src="content/img/laptop.jpg">
                    <%--<div class="card-header py-3">
                        
                    </div>
                    --%><div class="card-body">
                        <h6 class="card-title font-weight-bold text-primary"><%# Eval("ProductName")  %> </h6>
                        <%--<div class="text-center" style="margin: -1.25rem;">
                            <img class="img-fluid" style="" src="content/img/laptop.jpg" alt="">
                        </div>
                        --%><p> <%# Eval("ProductDesc")  %> </p>
                        <asp:LinkButton ID="btnEnquiry" CommandName="Enquiry" CommandArgument='<%#Eval("UserId") %>' CssClass="btn btn-primary float-right" runat="server">Enquiry</asp:LinkButton>
                        <asp:LinkButton ID="btnBuyNow" CommandName="Buy" CommandArgument='<%#Eval("UserId") %>' CssClass="btn btn-primary float-right mr-2" runat="server">Buy Now</asp:LinkButton>
                        
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            left: 1px;
            top: 0px;
        }
    </style>
</asp:Content>

