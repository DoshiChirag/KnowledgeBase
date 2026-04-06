using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public int NumberOfComputers { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}