using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineGroceryStore.AdminDetailsModel
{
    public partial class Admindetail
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPhoneno { get; set; }
    }
}
