using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGroceryStore.Models
{
    public partial class Productstockdetail
    {
        public string Productname { get; set; }
        public string Brandname { get; set; }
        public int? Productprice { get; set; }
        public int? Noofitemsavailable { get; set; }
        public byte[] Productimage { get; set; }
        public string Productcategory { get; set; }

        public virtual Branddetail BrandnameNavigation { get; set; }
    }
}
