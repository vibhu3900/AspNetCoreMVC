using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGroceryStore.CategoryProduct
{
    public partial class Product
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ProductPrice { get; set; }
        public string NoOfItemsInStock { get; set; }
        public byte[] ProductImage { get; set; }
        public int? CategoryId { get; set; }
        public string ProductDiscription { get; set; }
        public decimal? Discount { get; set; }
    }
}
