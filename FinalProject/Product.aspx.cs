/* 
* FileName: Product.aspx.cs
* Principal Author:  Smit Patel
* Summary: Product Page class
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;
using System.Drawing;
using System.IO;
using FinalProject.service;

namespace FinalProject
{
    /// <summary> Add Product Page Class.</summary>
    public partial class AddProduct : System.Web.UI.Page
    {
        /// <summary> Store the User object.</summary>
        User user = null;

        /// <summary> Store the Product object.</summary>
        protected Product product = null;

        /// <summary> Store the Product Table Adapter object.</summary>
        ProductTableAdapter adpProduct = new ProductTableAdapter();
        
        /// <summary> Store the Product Datatable object.</summary>
        FinalProjectDataset.ProductDataTable tblProduct = new FinalProjectDataset.ProductDataTable();

        /// <summary> Store the Category Table Adapter object.</summary>
        CategoryTableAdapter adpCategory = new CategoryTableAdapter();
        
        /// <summary> Store the Category Datatable object.</summary>
        FinalProjectDataset.CategoryDataTable tblCategory = new FinalProjectDataset.CategoryDataTable();

        /// <summary> Method of Page Load. </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            if(user.UserId == 0)
            {
                Response.Redirect("~/Login.aspx");
            }
            /// <summary> Store the Query Parameter Value.</summary>
            string queryParameter = Request.QueryString["ProductId"];

            if (queryParameter != null)
            {
                int ProductId = int.Parse(queryParameter);
                ProductService service = new ProductService();
                product = service.GetproductByProductId(ProductId);
                if (product != null)
                {
                    Response.Redirect("~/MyProducts.aspx");
                }
            }
            if (!Page.IsPostBack)
            {
                BindData(queryParameter);
            }

        }

        /// <summary>
        /// Binding data to page component
        /// </summary>
        /// <param name="queryParameter">search Query Parameter</param>
        private void BindData(string queryParameter)
        {
            tblCategory = adpCategory.GetCategory();
            ddlProductCategory.DataSource = tblCategory;
            ddlProductCategory.DataTextField = tblCategory.CategoryNameColumn.ToString();
            ddlProductCategory.DataValueField = tblCategory.CategoryIdColumn.ToString();
            ddlProductCategory.DataBind();
            ddlProductCategory.Items.Insert(0, "Select Category");
            btnAddProduct.Text = "Add Product";

            if (product != null)
            {
                txtProductName.Text = product.ProductName;
                txtPtoductDesc.Text = product.ProductDesc;
                txtProductPrice.Text = product.ProductPrice.ToString();
                txtProductBrand.Text = product.ProductBrand;
                txtProductQty.Text = product.ProductQty.ToString();
                ddlProductCategory.SelectedValue = product.CategoryId.ToString();
                ddlProductType.SelectedValue = product.ProductType.ToString();
                btnAddProduct.Text = "Update Product";
            }
        }

        /// <summary>
        /// Method called when AddProduct button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            string productDesc = txtPtoductDesc.Text;
            int productQty = int.Parse(txtProductQty.Text);
            string productType = ddlProductType.SelectedValue;
            decimal productPrice = decimal.Parse(txtProductPrice.Text);
            string productBrand = txtProductBrand.Text;
            string productImage = flProductImage.FileName;
            int userId = user.UserId;
            int categoryId = int.Parse(ddlProductCategory.SelectedValue);

            bool result = false;
            if (product != null && Request.QueryString["ProductId"] != null)
            {
                productImage = product.ProductImage;
                result = true;
            }
            else
            {
                result = uploadFile();
            }

            if ( !flProductImage.HasFile || result)
            {
                int rowInserted;
                if (product != null && Request.QueryString["ProductId"] != null)
                { 
                    rowInserted = adpProduct.Update(
                        productName, productDesc, productType, productPrice, productBrand, productImage, userId, categoryId, productQty, product.ProductId);
                }
                else
                {
                    rowInserted = adpProduct.Insert(productName, productDesc, productType, productPrice, productBrand, productImage, userId, categoryId, productQty);
                }
                if (rowInserted > 0)
                {
                    Response.Redirect("~/MyProducts.aspx");
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// Validate file for upload
        /// </summary>
        /// <returns></returns>
        private bool uploadFile()
        {
            bool result = false;
            if (flProductImage.HasFile)
            {
                string fileName = flProductImage.FileName;
                string fileExtenstion = Path.GetExtension(fileName);

                // check for the file extenstion
                if (fileExtenstion.ToLower() == ".jpg")
                {
                    // get file size, in bytes
                    int fileSize = flProductImage.PostedFile.ContentLength;

                    // if file size less than or equal to 2MB
                    if (fileSize <= 2097152)
                    {
                        // save file in Uploads folder
                        string productImage = Server.MapPath("~/Uploads/") + fileName;
                        flProductImage.SaveAs(productImage);

                        //lblMessage.Text = "File successfully uploaded";
                        //lblMessage.ForeColor = Color.Green;
                        result = true;
                    }
                    else
                    {
                        //lblMessage.Text = "File size exceeds the limit of 2MB";
                        //lblMessage.ForeColor = Color.Red;
                    }
                }
                else
                {
                    //lblMessage.Text = "Only PDF files are allowed";
                    //lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                //lblMessage.Text = "Please select a file";
                //lblMessage.ForeColor = Color.Red;
            }
            return result;
        }

    }
}