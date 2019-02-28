namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactInfo")]
    public partial class ContactInfo
    {
        public int ContactInfoID { get; set; }

        public int ContactInfoTypeID { get; set; }

        public int CustomerContactID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Contact { get; set; }

        public bool PrimaryContact { get; set; }
    }
}
