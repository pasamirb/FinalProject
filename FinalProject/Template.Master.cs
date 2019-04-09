/* 
* FileName: TemplateMaster.cs
* Principal Author:  Samir Patel
* Summary: Master page class
*/
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
    /// <summary> Master Page Class.</summary>
    public partial class Site1 : System.Web.UI.MasterPage
    {

        /// <summary> Store the Category Table Adapter object.</summary>
        CategoryTableAdapter adpCategory = new CategoryTableAdapter();

        /// <summary> Store the Category Datatable object.</summary>
        FinalProjectDataset.CategoryDataTable tblCategory = new FinalProjectDataset.CategoryDataTable();

        /// <summary> Store the User object.</summary>
        protected User user;

        /// <summary> Method of Page Load. </summary>
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

        /// <summary>
        /// get method of property TextBoxSearch
        /// </summary>
        public string TextBoxSearch
        {
            get { return txtSearch.Text; }
        }

        /// <summary>
        /// Method called when search button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method called when Logout button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session["user"] = new User();
            Response.Redirect("Default.aspx");
        }
    }
}