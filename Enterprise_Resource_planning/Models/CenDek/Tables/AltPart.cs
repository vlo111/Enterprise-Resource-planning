namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AltPart")]
    public partial class AltPart
    {
        public int AltPartID { get; set; }

        public int PartID { get; set; }

        [Required]
        public string PartNo { get; set; }
    }
}
