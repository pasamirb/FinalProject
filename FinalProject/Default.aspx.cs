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
        MessageProductUserTableAdapter adpMessageProductUser = new MessageProductUserTableAdapter();
        FinalProjectDataset.MessageProductUserDataTable tblMessageProductUser = new FinalProjectDataset.MessageProductUserDataTable();

        MessageTableAdapter adpMessage = new MessageTableAdapter();
        
        FinalProjectDataset.ProductDetailDataTable tblProductDetails = new FinalProjectDataset.ProductDetailDataTable();
        protected string CategoryName = null;
        User user;
        string searchQuery;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Master.txt
            user = (User)Session["user"];

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
            string[] keyArray = { "ProductId" };
            lvProducts.DataKeyNames = keyArray;
            //lvProducts.Data
        }

        protected void lvProducts_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (String.Equals(e.CommandName, "Enquiry"))
            {
                // Verify that the employee ID is not already in the list. If not, add the
                // employee to the list.
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                //tblProductDetails[dataItem.DataItemIndex];
                int ProductId =
                  int.Parse(lvProducts.DataKeys[dataItem.DisplayIndex].Value.ToString());
                int ProductUserId = int.Parse(e.CommandArgument.ToString());
                tblMessageProductUser = adpMessageProductUser.GetMessages(ProductUserId,ProductId);
                if(tblMessageProductUser.Count > 0)
                {
                    Response.Redirect("~/Messages.aspx");
                }
                else
                {
                    adpMessage.Insert("Hey, I am interesterd in this product. I s it still available?", user.UserId, ProductUserId, ProductId);            
                }
                System.Diagnostics.Debug.WriteLine("Parameter" + param);
            }
        }


    }
}