namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Price")]
    public partial class Price
    {
        public Price()
        {
            Currency = new Currency();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? PartID { get; set; }

        public DateTime ValidStart { get; set; }

        public DateTime ValidEnd { get; set; }

        public DateTime DateCreated { get; set; }

        [Column(TypeName = "money")]
        public decimal CostValue { get; set; }

        public int CostCurrencyID { get; set; }

        [Column(TypeName = "money")]
        public decimal SellValue { get; set; }

        public int CurrencyID { get; set; }

        public int EmployeeID { get; set; }

        public int? CustomerID { get; set; }

        public bool? EmailCustomer { get; set; }

        public virtual Currency Currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Part> Parts { get; set; }

    }
}
