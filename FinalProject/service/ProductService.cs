/* 
* FileName: ProductService.cs
* Principal Author:  Smit Patel
* Summary: Service Class for Product entity
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject.service
{
    /// <summary> Service class for Product Entity.</summary>
    public class ProductService
    {
        /// <summary> Store the Product Table Adapter object. </summary>
        ProductTableAdapter adpProduct = new ProductTableAdapter();

        /// <summary> Store the Product Datatable object. </summary>
        FinalProjectDataset.ProductDataTable tblProduct = new FinalProjectDataset.ProductDataTable();

        /// <summary>
        /// Get Product based on Product Id
        /// </summary>
        /// <param name="inputProductId">product id</param>
        /// <returns>Product Object</returns>
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