namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Colour")]
    public partial class Colour
    {
        public int ColourID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Hex { get; set; }

        [Required]
        public string ShopColour { get; set; }
    }
}
