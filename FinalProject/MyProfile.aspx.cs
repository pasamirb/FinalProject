/* 
* FileName: MyProfile.aspx.cs
* Principal Author:  Smit Patel
* Secondary Author : Samir Patel
* Summary: MyProfile Page class
*/
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
using FinalProject.service;

namespace FinalProject
{
    /// <summary> MyProfile Page Class.</summary>
    public partial class WebForm4 : System.Web.UI.Page
    {
        /// <summary> Store the User object.</summary>
        User user = null;
        
        /// <summary> Store the User Table Adapter object.</summary>
        UserTableAdapter adpUser = new UserTableAdapter();
        
        /// <summary> Store the User Data Table object.</summary>
        FinalProjectDataset.UserDataTable tblUser = new FinalProjectDataset.UserDataTable();
        
        /// <summary> Store the UserService object.</summary>
        UserService userService = new UserService();
        
        /// <summary> Method of Page Load. </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if (user.UserId == 0)
                Response.Redirect("~/Login.aspx");
            
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// Method to Bind Data into Page components.
        /// </summary>
        private void BindData()
        {
            user = (User)Session["user"];
            txtEmail.Text = user.Email;
            txtUserFirstName.Text = user.FirstName;
            txtUserLastName.Text = user.LastName;
            txtUserName.Text = user.UserName;
            txtPassword.Text = user.Password;
            txtUserCompany.Text = user.Company;
            txtUserPhone.Text = user.Phone.ToString();
            //fuUserProfilePicture.FileName. = user.Image;
        }

        /// <summary>
        /// On UpdateUserInfo button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateUserInfo_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string firstName = txtUserFirstName.Text;
            string lastName = txtUserLastName.Text;
            string userName = txtUserName.Text;
            string companyName = txtUserCompany.Text;
            int phone = int.Parse(txtUserPhone.Text);
            string userImage = fuUserProfilePicture.FileName;
            string userPassword = txtPassword.Text; 

            if (uploadFile())
            {
                string userImagePath = userImage;
                DateTime dateTime = DateTime.Now;

                int updateRows = adpUser.Update(firstName, lastName, userName, userPassword, email, phone, companyName, userImagePath, 1, dateTime, user.UserId);

                if(updateRows > 0)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Update Failed. Please try again";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        /// <summary>
        /// Validate file for upload
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// On DeleteAccount button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            userService.DeleteUserAccount(user.UserId);
            Session.Clear();
            Session["user"] = new User();
            Response.Redirect("~/Default.aspx");
        }

        }
}