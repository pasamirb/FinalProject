using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using FinalProject.FinalProjectDatasetTableAdapters;

namespace FinalProject
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        UserTableAdapter adpUser = new UserTableAdapter();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
                    Response.Redirect("~/loginForm.aspx");
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
                    EmailDuplicateMessage.Visible = true;
                }
            }
        }
    }
}