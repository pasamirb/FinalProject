using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; private set; }
        public string ProductDesc { get; private set; }
        public string ProductType { get; private set; }
        public decimal ProductPrice { get; private set; }
        public string ProductBrand { get; private set; }
        public string ProductImage { get; private set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int ProductQty { get; set; }

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

        public Product()
        {
        }
    }
}