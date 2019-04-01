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
    public partial class WebForm1 : System.Web.UI.Page
    {
        ProductDetailTableAdapter adpProductDetails = new ProductDetailTableAdapter();
        FinalProjectDataset.ProductDetailDataTable tblProductDetails = new FinalProjectDataset.ProductDetailDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            adpProductDetails.Fill(tblProductDetails);
            lvProducts.DataSource = tblProductDetails;
            lvProducts.DataBind();

            //Master.txt

            User user = (User)Session["user"];
            Response.Write("<strong>" + user.FirstName + "</strong>");
        }
    }
}