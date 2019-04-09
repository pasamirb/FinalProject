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

        ProductTableAdapter adpProduct = new ProductTableAdapter();

        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if (user.UserId == 0)
                Response.Redirect("~/Login.aspx");

            BindData();
            //}
        }

        private void BindData()
        {

            tblProductDetails = adpProductDetails.GetOwnProducts(user.UserId);
            lvProducts.DataSource = tblProductDetails;
            lvProducts.DataBind();

            string[] keyArray = { "ProductId" };
            lvProducts.DataKeyNames = keyArray;
        }

        protected void lvProducts_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (user.UserId != 0)
            {
                if (String.Equals(e.CommandName, "DeleteProduct"))
                {
                    // Verify that the employee ID is not already in the list. If not, add the
                    // employee to the list.
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                    //tblProductDetails[dataItem.DataItemIndex];
                    int ProductId =
                      int.Parse(lvProducts.DataKeys[dataItem.DisplayIndex].Value.ToString());
                    //int ProductUserId = int.Parse(e.CommandArgument.ToString());

                    //adpMessage.Insert("Hey, I am interesterd in this product. Is it still available?", user.UserId, ProductUserId, ProductId);
                    adpProduct.UpdateProductType("Deleted", ProductId);
                    //System.Diagnostics.Debug.WriteLine("Parameter" + param);
                }
                
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}