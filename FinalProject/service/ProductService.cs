using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject.service
{
    public class ProductService
    {
        ProductTableAdapter adpProduct = new ProductTableAdapter();
        FinalProjectDataset.ProductDataTable tblProduct = new FinalProjectDataset.ProductDataTable();
        public Product GetproductByProductId(int inputProductId)
        {
            Product product = null;

            tblProduct = adpProduct.GetProductByProductId(inputProductId);
            if (tblProduct.Count > 0)
            {
                var row = tblProduct[0];
                int productId = row.ProductId;
                string productName = row.ProductName;
                string productDesc = row.ProductDesc;
                string productType = row.ProductType;
                decimal productPrice = row.ProductPrice;
                string productBrand = row.ProductBrand;
                string productImage = row.ProductImage;
                int userId = row.UserId;
                int categoryId = row.CategoryId;
                int productQty = row.ProductQty;

                product = new Product(productId, productName, productDesc, productType, productPrice, productBrand, productImage, userId, categoryId, productQty);
            }
                return product;
        }
    }
}