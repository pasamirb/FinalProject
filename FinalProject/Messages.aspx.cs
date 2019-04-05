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
    public partial class WebForm2 : System.Web.UI.Page
    {
        ContactsTableAdapter adpContacts = new ContactsTableAdapter();
        FinalProjectDataset.ContactsDataTable tblContacts = new FinalProjectDataset.ContactsDataTable();
        public User user = null;
        MessageService messageService = new MessageService();
        int MessageFromId, MessageToId, ProductId;
        FinalProjectDataset.ContactsRow selectedContact;
        MessageTableAdapter adpMessage = new MessageTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            //if (user.UserId == 0)
            //    Response.Redirect("~/Login.aspx");
            //selectedContact = new FinalProjectDataset.ContactsRow(null);
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            tblContacts = adpContacts.GetContactsAsBuyer(user.UserId);
            lvContacts.DataSource = tblContacts;
            lvContacts.DataBind();
            Cache["tbl"] = tblContacts;
        }

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
        protected void UsersListView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            lvContacts.SelectedIndex = e.NewSelectedIndex;
        }

        protected void UsersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("test " + lvContacts.SelectedIndex);
            tblContacts = (FinalProjectDataset.ContactsDataTable)Cache["tbl"];
             //tblMessage.ElementAt(lvContacts.SelectedIndex);
            selectedContact = (FinalProjectDataset.ContactsRow)tblContacts.Rows[lvContacts.SelectedIndex];
            //row.MessageFromUserId;
            Cache["MessageFromId"] = selectedContact.MessageFromUserId;
            Cache["MessageToId"] = selectedContact.MessageToUserId;
            Cache["ProductId"] = selectedContact.ProductId;

            List <Message> messages = messageService.GetMessages(selectedContact.UserId, selectedContact.ProductId, user);
            
            lvMessage.DataSource = messages;
            lvMessage.DataBind();

            chatUser.InnerText = selectedContact.UserFirstName + " " + selectedContact.UserLastName;

            System.Diagnostics.Debug.WriteLine("User Product Id " + selectedContact.ProductId);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MessageFromId = int.Parse(Cache["MessageFromId"].ToString());
            MessageToId = int.Parse(Cache["MessageToId"].ToString());
            ProductId = int.Parse(Cache["ProductId"].ToString());


            int ToUserId = MessageFromId != user.UserId ? MessageFromId : MessageToId;
            int insertedRow = adpMessage.Insert(txtMessage.Text, user.UserId, ToUserId, ProductId);
            if (insertedRow > 0)
            {
                System.Diagnostics.Debug.WriteLine("Messege sent successfully.");

                lvMessage.DataSource = messageService.GetMessages(selectedContact.UserId, selectedContact.ProductId, user);
                lvMessage.DataBind();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Messege Failure.");
            }
        }
    }
}