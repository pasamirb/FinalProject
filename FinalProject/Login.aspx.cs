/* 
* FileName: Login.aspx.cs
* Principal Author:  Smit Patel
* Secondary Author:  Samir Patel
* Summary: Login Page class
*/
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
    /// <summary> Login Page Class.</summary>
    public partial class LoginWebPage : System.Web.UI.Page
    {
        /// <summary>
        /// userservice object of UserService class
        /// </summary>
        UserService userService = new UserService();

        /// <summary> called page loads </summary>
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        /// <summary> method called when login button is clicked </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            User user = userService.GetUserByUserNameAndUserPassword(email, password);
            if(user == null)
            {
                
            }
            string returnUrl = null;
            if (user != null)
            {
                //FormsAuthentication.Initialize();
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                //    1,
                //    user.Email,
                //    DateTime.Now,
                //    DateTime.Now.AddMinutes(30),
                //    cbRememberMe.Checked,
                //    "userRole",
                //    FormsAuthentication.FormsCookiePath);
                //// 5 arg = for remember me check box

                //string hashedTicket = FormsAuthentication.Encrypt(ticket);

                //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket);

                //if (ticket.IsPersistent)
                //{
                //    cookie.Expires = ticket.Expiration;
                //}
                //Response.Cookies.Add(cookie);

                ////string returnUrl = Request.QueryString.Get("ReturnUrl");
                //returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null)       // directly accessing via login page
                {
                    if(user.IsCompany)
                        returnUrl = "~/MyProducts.aspx";
                    else
                        returnUrl = "~/Default.aspx";
                }
                Session["user"] = user;
                Response.Redirect(returnUrl);
            }
            else
            {
                user = userService.GetUserByEmail(email);
                if (user != null)
                {
                    lblMessage.Text = "Password is wrong!";
                }
                else
                {
                    lblMessage.Text = "User not exist!";
                }
                lblMessage.Visible = true;
            }
            
        }
    }
}