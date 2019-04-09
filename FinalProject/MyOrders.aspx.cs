/* 
* FileName: MyOrders.aspx.cs
* Principal Author:  Samir Patel
* Summary: MyOrders Page class
*/
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
    /// <summary>
    /// MyOrders page class
    /// </summary>
    public partial class MyOrders : System.Web.UI.Page
    {
        /// <summary>
        /// store the MyOrders Table Adapter object
        /// </summary>
        MyOrdersTableAdapter adpOrders = new MyOrdersTableAdapter();
        /// <summary> Store the MyOrders Data Table object.</summary>
        FinalProjectDataset.MyOrdersDataTable tblOrders = new FinalProjectDataset.MyOrdersDataTable();
        /// <summary> Store the  User object.</summary>
        User user;

        /// <summary> method called when page loads. </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary> stores user object from session </summary>
            user = (User)Session["user"];
            if (user.UserId == 0)
                Response.Redirect("~/Login.aspx");
            else
                if (user.IsCompany) { 
                    Response.Redirect("~/MyProducts.aspx");
                }

            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// Method contains data bind logic for listview
        /// </summary>
        private void BindData()
        {
            tblOrders = adpOrders.GetMyProducts(user.UserId);
            lvProducts.DataSource = tblOrders;
            lvProducts.DataBind();
        }
    }
}