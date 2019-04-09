/* 
* FileName: MyProducts.aspx.cs
* Principal Author:  Samir Patel
* Summary: MyProducts Page class
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
    /// MyProducts page class
    /// </summary>
    public partial class MyProducts : System.Web.UI.Page
    {
        /// <summary> Store the Product Details Adapter object.</summary>
        ProductDetailTableAdapter adpProductDetails = new ProductDetailTableAdapter();
        
        /// <summary> Store the Product Details Data Table object.</summary>
        FinalProjectDataset.ProductDetailDataTable tblProductDetails = new FinalProjectDataset.ProductDetailDataTable();

        /// <summary> Store the Product Adapter object.</summary>
        ProductTableAdapter adpProduct = new ProductTableAdapter();

        /// <summary> Store the  User object.</summary>
        User user;

        /// <summary> Method of Page Load. </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if (user.UserId == 0)
                Response.Redirect("~/Login.aspx");

            BindData();
            //}
        }

        /// <summary>
        /// Method to Bind Data into Page components.
        /// </summary>
        private void BindData()
        {
            tblProductDetails = adpProductDetails.GetOwnProducts(user.UserId);
            lvProducts.DataSource = tblProductDetails;
            lvProducts.DataBind();

            string[] keyArray = { "ProductId" };
            lvProducts.DataKeyNames = keyArray;
        }

        /// <summary>
        /// Method called when listview's item's button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lvProducts_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (user.UserId != 0)
            {
                if (String.Equals(e.CommandName, "DeleteProduct"))
                {
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                    int ProductId =
                      int.Parse(lvProducts.DataKeys[dataItem.DisplayIndex].Value.ToString());

                    adpProduct.UpdateProductType("Deleted", ProductId);
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}