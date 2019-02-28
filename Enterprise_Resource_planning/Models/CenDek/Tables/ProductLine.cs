namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductLine")]
    public partial class ProductLine
    {
        public int ProductLineID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
