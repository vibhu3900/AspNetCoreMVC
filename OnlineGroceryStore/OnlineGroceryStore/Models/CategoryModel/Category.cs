using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGroceryStore.CategoryProduct
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
