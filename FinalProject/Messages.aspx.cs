/* 
* FileName: Messages.aspx.cs
* Principal Author:  Samir Patel
* Summary: Messages Page class
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.model;
using FinalProject.FinalProjectDatasetTableAdapters;
using System.Data;
using FinalProject.service;


namespace FinalProject
{
    /// <summary> Messages Page Class.</summary>
    public partial class WebForm2 : System.Web.UI.Page
    {
        /// <summary> Store the Contacts Table Adapter object.</summary>
        ContactsTableAdapter adpContacts = new ContactsTableAdapter();
        
        /// <summary> Store the  Contact Data Table object.</summary>
        FinalProjectDataset.ContactsDataTable tblContacts = new FinalProjectDataset.ContactsDataTable();
        
        /// <summary> Store the  User object.</summary>
        public User user = null;
        
        /// <summary> Store the  MessageService object.</summary>
        MessageService messageService = new MessageService();

        /// <summary> Class level variables to store information.</summary>
        int MessageFromId, MessageToId, ProductId;

        /// <summary> Store the ContactRow object.</summary>
        FinalProjectDataset.ContactsRow selectedContact;

        /// <summary> Store the Message Table Adapter object.</summary>
        MessageTableAdapter adpMessage = new MessageTableAdapter();

        /// <summary> method called when page loads. </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary> stores user object from session </summary>
            user = (User)Session["user"];
            if (user.UserId == 0)
                Response.Redirect("~/Login.aspx");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// Method contains data bind logic for listview
        /// </summary>
        private void BindData()
        {
            if (!user.IsCompany)
            {
                tblContacts = adpContacts.GetContactsAsBuyer(user.UserId);
                lvContacts.DataSource = tblContacts;
                lvContacts.DataBind();
                Cache["tbl"] = tblContacts;
                lvContacts.SelectedIndex = 0;
            }
            else
            {
                tblContacts = adpContacts.GetContactsAsSeller(user.UserId);
                lvContacts.DataSource = tblContacts;
                lvContacts.DataBind();
                Cache["tbl"] = tblContacts;
            }
        }

        /// <summary>
        /// Method called when seller buying products button called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeller_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                tblContacts = adpContacts.GetContactsAsSeller(user.UserId);
                lvContacts.DataSource = tblContacts;
                lvContacts.DataBind();
                Cache["tbl"] = tblContacts;
            }
        }

        /// <summary>
        /// Method called when Selling products button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuyer_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                tblContacts = adpContacts.GetContactsAsBuyer(user.UserId);
                lvContacts.DataSource = tblContacts;
                lvContacts.DataBind();
                Cache["tbl"] = tblContacts;
            }
        }

        /// <summary>
        /// Method called when listview's selected index is changing 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UsersListView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            lvContacts.SelectedIndex = e.NewSelectedIndex;
        }

        /// <summary>
        /// Method called when listview's selected index is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UsersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("test " + lvContacts.SelectedIndex);
            tblContacts = (FinalProjectDataset.ContactsDataTable)Cache["tbl"];
            selectedContact = (FinalProjectDataset.ContactsRow)tblContacts.Rows[lvContacts.SelectedIndex];

            Cache["MessageFromId"] = selectedContact.MessageFromUserId;
            Cache["MessageToId"] = selectedContact.MessageToUserId;
            Cache["ProductId"] = selectedContact.ProductId;

            Cache["SelectedContact"] = selectedContact;

            LoadMessages();
            //List<Message> messages = messageService.GetMessages(selectedContact.UserId, selectedContact.ProductId, user);
            
            //lvMessage.DataSource = messages;
            //lvMessage.DataBind();

            //chatUser.InnerText = selectedContact.UserFirstName + " " + selectedContact.UserLastName;
            //if(!string.IsNullOrEmpty(selectedContact.UserImage))
            //    ToUserImage.Src = "uploads/" + selectedContact.UserImage;
            System.Diagnostics.Debug.WriteLine("User Product Id " + selectedContact.ProductId);
        }
        /// <summary>
        /// Load Messages in Message panel
        /// </summary>
        private void LoadMessages()
        {
            selectedContact = (FinalProjectDataset.ContactsRow)Cache["SelectedContact"];
            List<Message> messages = messageService.GetMessages(selectedContact.UserId, selectedContact.ProductId, user);

            lvMessage.DataSource = messages;
            lvMessage.DataBind();

            chatUser.InnerText = selectedContact.UserFirstName + " " + selectedContact.UserLastName;
            if (!string.IsNullOrEmpty(selectedContact.UserImage))
                ToUserImage.Src = "uploads/" + selectedContact.UserImage;
        }

        /// <summary>
        /// method called when message send button is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            MessageFromId = int.Parse(Cache["MessageFromId"].ToString());
            MessageToId = int.Parse(Cache["MessageToId"].ToString());
            ProductId = int.Parse(Cache["ProductId"].ToString());
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                int ToUserId = MessageFromId != user.UserId ? MessageFromId : MessageToId;
                int insertedRow = adpMessage.Insert(txtMessage.Text, user.UserId, ToUserId, ProductId);
                if (insertedRow > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Messege sent successfully.");
                    txtMessage.Text = "";
                    LoadMessages();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Messege Failure.");
                }
            }
        }
    }
}