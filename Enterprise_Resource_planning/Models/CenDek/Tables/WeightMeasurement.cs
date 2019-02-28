namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeightMeasurement")]
    public partial class WeightMeasurement
    {
        public int WeightMeasurementID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
