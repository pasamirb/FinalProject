using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.service;
using FinalProject.model;

using System.Web.Security;

namespace FinalProject
{ 
    public partial class LoginWebPage : System.Web.UI.Page
    {
        UserTableAdapter adpUser = new UserTableAdapter();
        FinalProjectDataset.UserDataTable table = new FinalProjectDataset.UserDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            User user = userService.GetUserByUserNameAndUserPassword(email, password);
            string returnUrl = null;
            if (user != null)
            {
                FormsAuthentication.Initialize();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    user.Email,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    cbRememberMe.Checked,
                    "userRole",
                    FormsAuthentication.FormsCookiePath);
                // 5 arg = for remember me check box

                string hashedTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket);

                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);

                //string returnUrl = Request.QueryString.Get("ReturnUrl");
                returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null)       // directly accessing via login page
                {
                    if(user.IsCompany)
                        returnUrl = "~/MyProducts.aspx";
                    else
                        returnUrl = "~/Default.aspx";
                }
                Session["user"] = user;
            }
            else
            {
                lblMessage.Text = "Login Failed. Please try again";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            Response.Redirect(returnUrl);
        }
    }
}