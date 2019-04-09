/* 
* FileName: Register.aspx.cs
* Principal Author:  Smit Patel
* Secondary Author:  Samir Patel
* Summary: Register Page class
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject
{
    /// <summary> Register Page Class.</summary>
    public partial class RegisterForm : System.Web.UI.Page
    {
        /// <summary> Store the User Table Adapter object.</summary>
        UserTableAdapter adpUser = new UserTableAdapter();

        /// <summary> Store the User object.</summary>
        User user;

        /// <summary> Method of Page Load. </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if (user.UserId != 0 )
                if(!user.IsCompany)
                    Response.Redirect("~/Default.aspx");
                else
                    Response.Redirect("~/MyProducts.aspx");
        }

        /// <summary>
        /// Method called when Register button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string username = txtEmail.Text;
            string password = txtPassword.Text;
            try { 
                int result = adpUser.RegisterUser(firstName,lastName,username,password,email);
                if(result>0)
                    Response.Redirect("~/Login.aspx");
            }
            catch (Exception except)
            {
                Console.WriteLine("Hello World.");
                Console.WriteLine(except.StackTrace.ToString());
                Console.WriteLine("Message : " + except.Message);
                Debug.WriteLine(except.StackTrace.ToString());
                //Debug.WriteLine(except.InnerException.StackTrace.ToString());
                Debug.WriteLine("Message : " + except.Message);
                if (except.Message.Contains("UQ__User__C9F284569F661914"))
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Email alreday registered.";
                }
            }
        }
    }
}