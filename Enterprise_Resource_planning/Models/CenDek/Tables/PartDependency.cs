namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartDependency")]
    public partial class PartDependency
    {
        public int PartDependencyID { get; set; }

        public int PartID { get; set; }

        public int DependendPart { get; set; }

        public bool Required { get; set; }

        public double? Number { get; set; }
    }
}
