<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="FinalProject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">Update User Information</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card shadow col-md-12">
        <div class="card-body">
            <div class="form-group row">
                <asp:Label ID="lblEmail" CssClass="col-sm-2 col-form-label" runat="server" Text="Email ID:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtEmail" type="text" runat="server" CssClass="form-control" placeholder="Enter First name" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblUserFirstName" CssClass="col-sm-2 col-form-label" runat="server" Text="First Name:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUserFirstName" type="text" runat="server" CssClass="form-control" placeholder="Enter First name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblUserLastName" CssClass="col-sm-2 col-form-label" runat="server" Text="Last Name:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUserLastName" type="text" runat="server" CssClass="form-control" placeholder="Enter Last name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblUserName" CssClass="col-sm-2 col-form-label" runat="server" Text="User Name:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUserName" type="text" runat="server" CssClass="form-control" placeholder="Enter User Name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblPassword" CssClass="col-sm-2 col-form-label" runat="server" Text="Password:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPassword" type="text" runat="server" CssClass="form-control" placeholder="Enter User Name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblUserPhone" CssClass="col-sm-2 col-form-label" runat="server" Text="Phone:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUserPhone" type="number" runat="server" CssClass="form-control" placeholder="Enter Phone Number"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblUsrCompany" CssClass="col-sm-2 col-form-label" runat="server" Text="Company Name:"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUserCompany" type="text" runat="server" CssClass="form-control" placeholder="Enter Company Name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblUserProfilePicture" CssClass="col-sm-2 col-form-label" runat="server" Text="Profile Picture:"></asp:Label>
                <div class="col-sm-10">
                    <asp:FileUpload ID="fuUserProfilePicture" runat="server" CssClass="form-control-file" />
                </div>
            </div>
            <div class="col-sm-4">
                <asp:Button ID="btnUpdateUserInfo" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnUpdateUserInfo_Click" />
            </div>
            <div class="col-sm-8">
                <asp:Label ID="lblMessage" runat="server" CssClass ="alert alert-danger d-md-block" Visible="False"></asp:Label>
            </div>
            
        </div>
    </div>
</asp:Content>
