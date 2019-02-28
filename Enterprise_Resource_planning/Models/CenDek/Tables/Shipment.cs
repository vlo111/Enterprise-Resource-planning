namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipment")]
    public partial class Shipment
    {
        public int ShipmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string SpecialInstructions { get; set; }

        public DateTime? ShipmentDate { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(10)]
        public string ShippingTimeFrameID { get; set; }

        public int ShippingAddressID { get; set; }

        public int? CarrierID { get; set; }
    }
}
