namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileTmp")]
    public partial class FileTmp
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public byte[] Contents { get; set; }

        public string Emp { get; set; }

        public string Doc { get; set; }
    }
}
