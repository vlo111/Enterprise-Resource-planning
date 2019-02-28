namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Carrier")]
    public partial class Carrier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Carrier()
        {
            CustomerCarriers = new HashSet<CustomerCarrier>();
        }

        public int CarrierID { get; set; }

        [StringLength(50)]
        public string CarrierName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(500)]
        public string Address2 { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string PostalCode { get; set; }

        public string Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCarrier> CustomerCarriers { get; set; }
    }
}
