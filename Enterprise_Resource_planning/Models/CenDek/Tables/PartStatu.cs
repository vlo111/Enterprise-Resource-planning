namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PartStatu
    {
        [Key]
        public int PartStatusID { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
