namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderItemID { get; set; }

        public int OrderID { get; set; }

        public int? ProductID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
