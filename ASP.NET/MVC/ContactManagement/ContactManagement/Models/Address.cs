using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode{ get; set; }
        public string Zip { get; set; }

        //public virtual Contact Contact { get; set; }

    }
}