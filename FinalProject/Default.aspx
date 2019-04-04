<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalProject.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">Explore Products</h1>
    <a href="AddProduct.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-plus fa-sm text-white-50"></i> Add product</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Content Column -->

    <asp:ListView ID="lvProducts" runat="server">
        <ItemTemplate>
            <div class="col-lg-4 mb-4">
                <!-- Illustrations -->
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary"><%# Eval("ProductName")  %> </h6>
                    </div>
                    <div class="card-body">
                        <div class="text-center" style="margin: -1.25rem;">
                            <img class="img-fluid" style="" src="content/img/laptop.jpg" alt="">
                        </div>
                        <p style="margin-top: 2.5rem"><%# Eval("ProductDesc")  %> </p>
                        <a class="btn btn-primary float-right" target="_blank" rel="nofollow" href="ProductDetails.aspx?ProductId=<%# Eval("ProductId")  %> ">Enquiry &rarr;</a>
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

