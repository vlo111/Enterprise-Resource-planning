namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShippingAddress")]
    public partial class ShippingAddress
    {
        public int ShippingAddressID { get; set; }

        public int CustomerID { get; set; }

        public int CustomerContactID { get; set; }

        public DateTime LastUsed { get; set; }

        [Required]
        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(500)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(150)]
        public string City { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; }

        public string Comments { get; set; }
    }
}
