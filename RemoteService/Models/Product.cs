using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteService.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public static class ProductData
        {
            public static List<Product> Products = new List<Product>()
            {
                new Product {ProductID = 1, ProductName = "Caphe", Quantity = 10, UnitPrice = 20 },
                new Product {ProductID = 2, ProductName = "Cola", Quantity = 20, UnitPrice = 30 }
            };
        }
    }
}