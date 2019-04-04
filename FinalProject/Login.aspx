<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalProject.LoginWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Login</title>

    <!-- Custom fonts for this template-->
    <link href="~/content/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet"/>

    <!-- Custom styles for this template-->
    <link href="~/content/css/sb-admin-2.min.css" rel="stylesheet"/>
    <link href="~/content/css/style.css" rel="stylesheet"/>
</head>
<body class="bg-gradient-primary">
    <div class="container">

    <!-- Outer Row -->
    <div class="row justify-content-center vertical-align-center" style="min-height:100vh;">

      <div class="col-xl-10 col-lg-12 col-md-9">

    <form id="form1" runat="server">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
              <div class="col-lg-6">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                  </div>
                  
                    <div class="form-group">
                      <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-user" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-user" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblMessage" runat="server" CssClass ="alert alert-danger d-md-block" Visible="False"></asp:Label>
                    </div>
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Login" OnClick="btnLogin_Click"/>
                  <hr/>
                  <div class="text-center">
                    <a class="small" href="#">Forgot Password?</a>
                  </div>
                  <div class="text-center">
                    <a class="small" href="~/Register.aspx">Create an Account!</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
    </form>
          </div>
        </div>
        </div>
    <!-- Bootstrap core JavaScript-->
  <script src="content/vendor/jquery/jquery.min.js"></script>
  <script src="content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="content/vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="content/js/sb-admin-2.min.js"></script>
</body>
</html>
