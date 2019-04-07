using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FinalProject.model;
using FinalProject.FinalProjectDatasetTableAdapters;
using System.Drawing;
using System.IO;

namespace FinalProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        User user = null;
        UserTableAdapter adpUser = new UserTableAdapter();
        FinalProjectDataset.UserDataTable tblUser = new FinalProjectDataset.UserDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if (user != null)
            {
                if (!Page.IsPostBack)
                {
                    BindData();
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        private void BindData()
        {
            user = (User)Session["user"];
            txtEmail.Text = user.Email;
            txtUserFirstName.Text = user.FirstName;
            txtUserLastName.Text = user.LastName;
            txtUserName.Text = user.UserName;
            //txtPassword = user.
            txtUserCompany.Text = user.Company;
            txtUserPhone.Text = user.Phone.ToString();
            //fuUserProfilePicture. = user.Image;
        }

        protected void btnUpdateUserInfo_Click(object sender, EventArgs e)
        {
            //txtEmail.Text;
            string firstName = txtUserFirstName.Text;
            string lastName = txtUserLastName.Text;
            string userName = txtUserName.Text;
            string companyName = txtUserCompany.Text;
            int phone = int.Parse(txtUserPhone.Text);
            string userImage = fuUserProfilePicture.FileName;
            string userPassword = "";

            if (uploadFile())
            {
                string userImagePath = Server.MapPath("~/Uploads/") + userImage;
                int updateRows = adpUser.Update(firstName, lastName, userName, userPassword, user.Email, phone, companyName, userImagePath, 1, new DateTime(), user.UserId);
            }
        }

        private bool uploadFile()
        {
            bool result = false;
            if (fuUserProfilePicture.HasFile)
            {
                string fileName = fuUserProfilePicture.FileName;
                string fileExtenstion = Path.GetExtension(fileName);

                // check for the file extenstion
                if (fileExtenstion.ToLower() == ".jpg")
                {
                    // get file size, in bytes
                    int fileSize = fuUserProfilePicture.PostedFile.ContentLength;

                    // if file size less than or equal to 2MB
                    if (fileSize <= 2097152)
                    {
                        // save file in Uploads folder
                        string path = Server.MapPath("~/Uploads/") + fileName;
                        fuUserProfilePicture.SaveAs(path);

                        result = true;
                    }
                    else
                    {
                        //lblMessage.Text = "File size exceeds the limit of 2MB";
                        //lblMessage.ForeColor = Color.Red;
                    }
                }
                else
                {
                    //lblMessage.Text = "Only PDF files are allowed";
                    //lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                //lblMessage.Text = "Please select a file";
                //lblMessage.ForeColor = Color.Red;
            }
            return result;
        }

    }
}