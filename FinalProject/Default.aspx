<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">Explore Products</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Content Column -->
    <div class="col-lg-4 mb-4">
        <!-- Illustrations -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Illustrations</h6>
            </div>
            <div class="card-body">
                <div class="text-center" style=" margin: -1.25rem;">
                    <img class="img-fluid" style="" src="content/img/laptop.jpg" alt="">
                </div>
                <p style="margin-top: 2.5rem">Add some quality, svg illustrations to your project courtesy of <a target="_blank" rel="nofollow" href="https://undraw.co/">unDraw</a>, a constantly updated collection of beautiful svg images that you can use completely free and without attribution!</p>
                <a class="btn btn-primary float-right" target="_blank" rel="nofollow" href="https://undraw.co/">Enquiry &rarr;</a>
            </div>
        </div>
    </div>
</asp:Content>
