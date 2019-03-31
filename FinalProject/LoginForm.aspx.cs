using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.FinalProjectDatasetTableAdapters;
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
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            
            table = adpUser.GetUserByUserNameAndUserPassword(email, password);
            foreach(TableRow row in table.Rows)
            {
               
            }
            

        }
    }
}