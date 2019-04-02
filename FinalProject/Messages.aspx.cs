using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.model;
using FinalProject.FinalProjectDatasetTableAdapters;

namespace FinalProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MessageTableAdapter adpMessage = new MessageTableAdapter();
        FinalProjectDataset.MessageDataTable tblMessage = new FinalProjectDataset.MessageDataTable();
        public User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if (user.UserId == 0)
                Response.Redirect("~/LoginForm.aspx");
            if (!Page.IsPostBack)
            {
                BindData();
            }
            
        }

        private void BindData()
        {
            tblMessage = adpMessage.GetContactsAsBuyer(user.UserId);
            lvContacts.DataSource = tblMessage;
            lvContacts.DataBind();
        }

            protected void btnSeller_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                tblMessage = adpMessage.GetContactsAsSeller(user.UserId);
                lvContacts.DataSource = tblMessage;
                lvContacts.DataBind();
            }
        }

        protected void btnBuyer_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                tblMessage = adpMessage.GetContactsAsBuyer(user.UserId);
                lvContacts.DataSource = tblMessage;
                lvContacts.DataBind();
            }
        }
        protected void UsersListView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            lvContacts.SelectedIndex = e.NewSelectedIndex;
        }

        protected void UsersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("test " + lvContacts.SelectedIndex);
        }
        
    }
}