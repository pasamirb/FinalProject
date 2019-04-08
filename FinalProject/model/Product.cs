using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProducName { get; private set; }
        public string ProducDesc { get; private set; }
        public string ProducType { get; private set; }
        public double ProducPrice { get; private set; }
        public string ProducBrand { get; private set; }
        public string ProducImage { get; private set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int ProductQty { get; set; }

        public Product(int productId, string producName, string producDesc, string producType, double producPrice, string producBrand, string producImage, int userId, int categoryId, int productQty)
        {
            ProductId = productId;
            ProducName = producName;
            ProducDesc = producDesc;
            ProducType = producType;
            ProducPrice = producPrice;
            ProducBrand = producBrand;
            ProducImage = producImage;
            UserId = userId;
            CategoryId = categoryId;
            ProductQty = productQty;
        }

        public Product()
        {
        }
    }
}