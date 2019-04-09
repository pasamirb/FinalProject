/* 
* FileName: Default.aspx.cs
* Principal Author:  Samir Patel
* Secondary Author:  Smit Patel
* Summary: Default Page class
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
    /// <summary> Default Page Class.</summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary> Store the Product Details Adapter object.</summary>
        ProductDetailTableAdapter adpProductDetails = new ProductDetailTableAdapter();
        /// <summary> Store the  MessageProductUser Adapter object.</summary>
        MessageProductUserTableAdapter adpMessageProductUser = new MessageProductUserTableAdapter();
        /// <summary> Store the  MessageProductUser Table object.</summary>
        FinalProjectDataset.MessageProductUserDataTable tblMessageProductUser = new FinalProjectDataset.MessageProductUserDataTable();
        
        /// <summary> Store the Product Adapter object.</summary>
        ProductTableAdapter adpProduct = new ProductTableAdapter();
        
        /// <summary> Store the Message Adapter object.</summary>
        MessageTableAdapter adpMessage = new MessageTableAdapter();

        /// <summary> Store the  User Adapter object.</summary>
        UserProductTableAdapter adpUserProduct = new UserProductTableAdapter();

        /// <summary> Store the  UserProduct Table object.</summary>
        FinalProjectDataset.UserProductDataTable tblUserProduct = new FinalProjectDataset.UserProductDataTable();

        /// <summary> Store the  ProductDetail Table object.</summary>
        FinalProjectDataset.ProductDetailDataTable tblProductDetails = new FinalProjectDataset.ProductDetailDataTable();

        /// <summary> Store the  Category Name.</summary>
        protected string CategoryName = null;

        /// <summary> Store the  User object.</summary>
        User user;

        /// <summary> Store the  Search Query.</summary>
        string searchQuery;

        /// <summary> Method of Page Load. </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Master.txt
            user = (User)Session["user"];
            
            if (user.IsCompany)
            {
                Response.Redirect("~/MyProducts.aspx");
            }
            
            /// <summary> Store the Query Parameter Value.</summary>
            string v = Request.QueryString["category"];
            searchQuery = ((Site1)Master.Master).TextBoxSearch;
            System.Diagnostics.Debug.WriteLine("Search "+searchQuery);
            if (!IsPostBack)
            {
                BindData(v,searchQuery);
            }
            else
            {
                BindData(v, searchQuery);
            }
        }

        /// <summary> Method to Bind Data into Page components. </summary>
        /// <returns>void.</returns>
        /// <param name="category"> Category Name. </param>
        /// <param name="searchQuery"> Serach Query. </param>
        private void BindData(string category,string searchQuery)
        {
            if (category == null)
            {
                if (searchQuery.Equals(""))
                    adpProductDetails.Fill(tblProductDetails,user.UserId);
                
                else
                    tblProductDetails = adpProductDetails.SearchProducts(user.UserId,searchQuery);
            }
            else
            {
                    tblProductDetails = adpProductDetails.GetProductsByCategoryId(int.Parse(category), user.UserId);
                    CategoryName = tblProductDetails[0].CategoryName;
            }
            lvProducts.DataSource = tblProductDetails;
            lvProducts.DataBind();

            /// <summary> Array to store Product ID.</summary>
            string[] keyArray = { "ProductId" };
            lvProducts.DataKeyNames = keyArray;
            //lvProducts.Data
        }

        /// <summary> Method to for OnClick of ListView Items. </summary>
        /// <returns>void.</returns>
        protected void lvProducts_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (user.UserId != 0) { 
                if (String.Equals(e.CommandName, "Enquiry"))
                {
                    // Verify that the employee ID is not already in the list. If not, add the
                    // employee to the list.
                    /// <summary> Store the ListViewDataItem. </summary>
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                    /// <summary> Store the Product ID. </summary>
                    //tblProductDetails[dataItem.DataItemIndex];
                    int ProductId =
                      int.Parse(lvProducts.DataKeys[dataItem.DisplayIndex].Value.ToString());
                    /// <summary> Store the Product User ID. </summary>
                    int ProductUserId = int.Parse(e.CommandArgument.ToString());
                    tblMessageProductUser = adpMessageProductUser.GetMessages(ProductUserId,ProductId);
                    if(tblMessageProductUser.Count > 0)
                    {
                        Response.Redirect("~/Messages.aspx");
                    }
                    else
                    {
                        adpMessage.Insert("Hey, I am interesterd in this product. Is it still available?", user.UserId, ProductUserId, ProductId);            
                    }
                    //System.Diagnostics.Debug.WriteLine("Parameter" + param);
                } else if(String.Equals(e.CommandName, "Buy"))
                {
                    /// <summary> Store the ListViewDataItem. </summary>
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                    //tblProductDetails[dataItem.DataItemIndex];
                    /// <summary> Store the Product ID. </summary>
                    int ProductId =
                      int.Parse(lvProducts.DataKeys[dataItem.DisplayIndex].Value.ToString());
                    /// <summary> Store the Product User ID. </summary>
                    int ProductUserId = int.Parse(e.CommandArgument.ToString());

                    /// <summary> Store the ROW object. </summary>
                    FinalProjectDataset.ProductDetailRow row = tblProductDetails[dataItem.DisplayIndex];
                    if(string.Equals(row.ProductType, "Available")) {
                    
                        adpUserProduct.Insert(user.UserId, ProductId, 1);
                        if (adpUserProduct.GetTotalQtyByProduct(ProductId) == row.ProductQty)
                        {
                            //row.ProductType = "Sold";
                            adpProduct.UpdateProductType("Sold", row.ProductId);
                            tblProductDetails[dataItem.DisplayIndex].ProductType = "Sold";
                            //Response.Redirect("");
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}