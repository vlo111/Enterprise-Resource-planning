namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartInventory")]
    public partial class PartInventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PartInventoryID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartID { get; set; }
    }
}
