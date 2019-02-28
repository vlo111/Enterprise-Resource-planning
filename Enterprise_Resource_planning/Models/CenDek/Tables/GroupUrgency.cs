namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupUrgency")]
    public partial class GroupUrgency
    {
        public int GroupUrgencyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        public string Description { get; set; }
    }
}
