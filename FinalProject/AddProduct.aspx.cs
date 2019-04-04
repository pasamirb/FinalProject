using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject
{
    public partial class AddProduct : System.Web.UI.Page
    {
        User user = null;
        ProductTableAdapter adpProduct = new ProductTableAdapter();
        FinalProjectDataset.ProductDataTable tblProduct = new FinalProjectDataset.ProductDataTable();

        CategoryTableAdapter adpCategory = new CategoryTableAdapter();
        FinalProjectDataset.CategoryDataTable tblCategory = new FinalProjectDataset.CategoryDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["user"];
            tblCategory = adpCategory.GetCategory();
            ddlProductCategory.DataSource = tblCategory;
            ddlProductCategory.DataTextField = tblCategory.CategoryNameColumn.ToString();
            ddlProductCategory.DataValueField = tblCategory.CategoryIdColumn.ToString();
            ddlProductCategory.DataBind();
            ddlProductCategory.Items.Insert(0, "Select Category");
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            string productDesc = txtPtoductDesc.Text;
            string productType = ddlProductType.SelectedValue;
            decimal productPrice = int.Parse(txtProductPrice.Text);
            string productBrand = txtProductBrand.Text;
            string productImage = flProductImage.FileName;
            int userId = user.UserId;
            int categoryId = ddlProductCategory.SelectedIndex;


            int rowInserted = adpProduct.Insert(productName, productDesc, productType, productPrice,  productBrand, productImage, userId, categoryId);
        }

        //private bool uploadFile()
        //{
        //    if (FileUpload1.HasFile)
        //    {
        //        string fileName = FileUpload1.FileName;
        //        string fileExtenstion = Path.GetExtension(fileName);

        //        // check for the file extenstion
        //        if (fileExtenstion.ToLower() == ".pdf")
        //        {
        //            // get file size, in bytes
        //            int fileSize = FileUpload1.PostedFile.ContentLength;

        //            // if file size less than or equal to 2MB
        //            if (fileSize <= 2097152)
        //            {
        //                // save file in Uploads folder
        //                FileUpload1.SaveAs(Server.MapPath("~/Uploads/") + fileName);
        //                lblMessage.Text = "File successfully uploaded";
        //                lblMessage.ForeColor = Color.Green;
        //            }
        //            else
        //            {
        //                lblMessage.Text = "File size exceeds the limit of 2MB";
        //                lblMessage.ForeColor = Color.Red;
        //            }
        //        }
        //        else
        //        {
        //            lblMessage.Text = "Only PDF files are allowed";
        //            lblMessage.ForeColor = Color.Red;
        //        }
        //    }
        //    else
        //    {
        //        lblMessage.Text = "Please select a file";
        //        lblMessage.ForeColor = Color.Red;
        //    }
        //}
    }
}