namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerCarrier")]
    public partial class CustomerCarrier
    {
        public int CarrierID { get; set; }

        public int CustomerID { get; set; }

        [StringLength(500)]
        public string Account { get; set; }

        public string Comments { get; set; }

        public int CustomerCarrierID { get; set; }

        public virtual Carrier Carrier { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
