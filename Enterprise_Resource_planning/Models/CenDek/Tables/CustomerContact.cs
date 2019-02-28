namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerContact")]
    public partial class CustomerContact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerContact()
        {
            Parts = new HashSet<Part>();
        }
        public int ID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string First { get; set; }

        [Required]
        [StringLength(50)]
        public string Last { get; set; }

        [StringLength(500)]
        public string JobTitle { get; set; }

        public string Notes { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Part> Parts { get; set; }


    }
}
