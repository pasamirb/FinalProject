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
    public partial class MyOrders : System.Web.UI.Page
    {
        MyOrdersTableAdapter adpOrders = new MyOrdersTableAdapter();
        FinalProjectDataset.MyOrdersDataTable tblOrders = new FinalProjectDataset.MyOrdersDataTable();
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
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

        private void BindData()
        {

            tblOrders = adpOrders.GetMyProducts(user.UserId);
            lvProducts.DataSource = tblOrders;
            lvProducts.DataBind();
        }
    }
}