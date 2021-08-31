using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGroceryStore.Models
{
    public partial class Customer
    {
        public int Custid { get; set; }
        public string Custname { get; set; }
        public string Custemail { get; set; }
        public string Custcontactno { get; set; }
        public string CustPassword { get; set; }
    }
}
