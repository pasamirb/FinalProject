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
        protected string CategoryName = null;
        string searchQuery;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Master.txt
            User user = (User)Session["user"];

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
                    adpProductDetails.Fill(tblProductDetails);
                else
                    tblProductDetails = adpProductDetails.SearchProducts(searchQuery);
            }
            else
            {
                    tblProductDetails = adpProductDetails.GetProductsByCategoryId(int.Parse(category));
                    CategoryName = tblProductDetails[0].CategoryName;
            }
            lvProducts.DataSource = tblProductDetails;
            lvProducts.DataBind();
            string[] keyArray = { "ProductId", "UserId" };
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
                string param =
                  lvProducts.DataKeys[dataItem.DisplayIndex].Value.ToString();

                System.Diagnostics.Debug.WriteLine("Parameter" + param);
            }
        }


    }
}