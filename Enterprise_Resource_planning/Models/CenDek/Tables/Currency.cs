namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Currency")]
    public partial class Currency
    {
        public Currency()
        {
            this.Prices = new List<Price>();
        }
        public int CurrencyID { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        [Required]
        public string CurrencyName { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
