/* 
* FileName: Product.cs
* Principal Author:  Smit Patel
* Summary: Model Class for Product entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.model
{
    /// <summary>  Model class for Product Entity. </summary>
    public class Product
    {
        /// <summary> Store the Product Id. </summary>
        public int ProductId { get; set; }

        /// <summary> Store the Product Name. </summary>
        public string ProductName { get; private set; }

        /// <summary> Store the Product Description. </summary>
        public string ProductDesc { get; private set; }

        /// <summary> Store the Product Type. </summary>
        public string ProductType { get; private set; }

        /// <summary> Store the Product Price. </summary>
        public decimal ProductPrice { get; private set; }

        /// <summary> Store the Product Brand. </summary>
        public string ProductBrand { get; private set; }

        /// <summary> Store the Product Image. </summary>
        public string ProductImage { get; private set; }

        /// <summary> Store the User Id. </summary>
        public int UserId { get; set; }

        /// <summary> Store the Category Id. </summary>
        public int CategoryId { get; set; }

        /// <summary> Store the Product Quantity. </summary>
        public int ProductQty { get; set; }

        /// <summary> Parameterized Constructor. </summary>
        public Product(int productId, string productName, string productDesc, string productType, decimal productPrice, string productBrand, string productImage, int userId, int categoryId, int productQty)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDesc = productDesc;
            ProductType = productType;
            ProductPrice = productPrice;
            ProductBrand = productBrand;
            ProductImage = productImage;
            UserId = userId;
            CategoryId = categoryId;
            ProductQty = productQty;
        }
        
        /// <summary> Default constructor. </summary>
        public Product()
        {
        }
    }
}