using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataApplication.Models
{
    public class JoinedOrder
    {
        [Key()]
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public decimal? Freight { get; set; }
        public int? ShipVia { get; set; }
    }
}