using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGroceryStore.Models
{
    public partial class Productoffersdetail
    {
        public string Productname { get; set; }
        public string Brandname { get; set; }
        public int? Discount { get; set; }
        public string Productspecialoffer { get; set; }

        public virtual Productstockdetail Productstockdetail { get; set; }
    }
}
