namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        public int TagID { get; set; }

        public int OrderID { get; set; }

        [Required]
        public string TagName { get; set; }

        public int? ShipmentID { get; set; }
    }
}
