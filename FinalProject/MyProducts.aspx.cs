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
    public partial class MyProducts : System.Web.UI.Page
    {
        ProductDetailTableAdapter adpProductDetails = new ProductDetailTableAdapter();
        FinalProjectDataset.ProductDetailDataTable tblProductDetails = new FinalProjectDataset.ProductDetailDataTable();
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {

            tblProductDetails = adpProductDetails.GetOwnProducts(user.UserId);
            lvProducts.DataSource = tblProductDetails;
            lvProducts.DataBind();
        }
    }
}