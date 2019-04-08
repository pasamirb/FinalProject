using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        CategoryTableAdapter adpCategory = new CategoryTableAdapter();
        FinalProjectDataset.CategoryDataTable tblCategory = new FinalProjectDataset.CategoryDataTable();
        protected User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if (!IsPostBack)
            {
                tblCategory = adpCategory.GetCategory();
                lvCategories.DataSource = tblCategory;
                lvCategories.DataBind();
            }
        }

        public string TextBoxSearch
        {
            get { return txtSearch.Text; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session["user"] = new User();
            Response.Redirect("Default.aspx");
        }
    }
}