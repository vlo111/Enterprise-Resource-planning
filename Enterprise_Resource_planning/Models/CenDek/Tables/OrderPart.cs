namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderPart")]
    public partial class OrderPart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderPart()
        {
            CustOrders = new HashSet<CustOrder>();
        }

        public int OrderPartID { get; set; }

        public int PartID { get; set; }

        public double Quantity { get; set; }

        public int PriceID { get; set; }

        public int? ProductLineID { get; set; }

        public int? GroupUrgencyID { get; set; }

        [StringLength(10)]
        public string ColourID { get; set; }

        public string Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustOrder> CustOrders { get; set; }
    }
}
