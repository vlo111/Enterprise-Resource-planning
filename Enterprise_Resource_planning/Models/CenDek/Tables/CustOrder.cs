namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustOrder")]
    public partial class CustOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustOrder()
        {
            OrderParts = new HashSet<OrderPart>();
        }

        public int CustOrderID { get; set; }

        public int Revision { get; set; }

        public int CustomerID { get; set; }

        public string PONum { get; set; }

        [Required]
        public string InvoiceNo { get; set; }

        public DateTime CreatedDate { get; set; }

        public int EmployeeID { get; set; }

        public int? ApproverID { get; set; }

        [Column(TypeName = "money")]
        public decimal? CostTotal { get; set; }

        public int? CostCurrencyID { get; set; }

        [Column(TypeName = "money")]
        public decimal? SellTotal { get; set; }

        public int? SellCurrencyID { get; set; }

        public int GroupUrgencyID { get; set; }

        public double? DiscountAmountPercentage { get; set; }

        [Required]
        [StringLength(10)]
        public string CommentsCentury { get; set; }

        [StringLength(20)]
        public string WorkOrderNo { get; set; }

        public int State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPart> OrderParts { get; set; }
    }
}
