using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGroceryStore.Models
{
    public partial class Billdetail
    {
        public int? Custid { get; set; }
        public string Productname { get; set; }
        public string Brandname { get; set; }
        public int? Noofproduct { get; set; }
        public int? Totalbill { get; set; }
        public DateTime? Billdate { get; set; }

        public virtual Customer Cust { get; set; }
    }
}
