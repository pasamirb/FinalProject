using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.model
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public string ProductType { get; private set; }
        public float ProductPrice { get; private set; }
        public string ProductBrand { get; private set; }
        public string ProductImage { get; private set; }
        public int UserId { get; private set;}
        public int CategoryId { get; private set; }



        public Product(int productId, string productName, string productDescription, string productType, float productPrice, string productBrand, string productImage, int userId, int categoryId)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductType = productType;
            ProductPrice = productPrice;
            ProductBrand = productBrand;
            ProductImage = productImage;
            UserId = userId;
            CategoryId = categoryId;
        }
    }

}