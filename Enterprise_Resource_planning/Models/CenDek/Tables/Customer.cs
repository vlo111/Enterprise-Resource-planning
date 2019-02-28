namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            CustomerCarriers = new HashSet<CustomerCarrier>();
            CustomerContact = new CustomerContact();
        }

        public int CustomerID { get; set; }

        [Required]
        public string Company { get; set; }

        public string Fax { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public bool GSTExempt { get; set; }

        public bool PSTExempt { get; set; }

        [StringLength(255)]
        public string CenDekDivision { get; set; }

        public bool? CustomerStatus { get; set; }

        [StringLength(255)]
        public string BillingAddress { get; set; }

        [StringLength(255)]
        public string ShippingAddress { get; set; }

        [StringLength(255)]
        public string BillingCity { get; set; }

        [StringLength(255)]
        public string BillingProv { get; set; }

        [StringLength(255)]
        public string BillingPostalCode { get; set; }

        [StringLength(255)]
        public string ShippingCity { get; set; }

        [StringLength(255)]
        public string ShippingProv { get; set; }

        [StringLength(255)]
        public string ShippingPostalCode { get; set; }

        [StringLength(255)]
        public string AreaCode { get; set; }

        [StringLength(255)]
        public string BusinessPhone { get; set; }

        [StringLength(255)]
        public string Cell { get; set; }

        [StringLength(255)]
        public string EmailAddress { get; set; }

        public double? Discount { get; set; }

        [StringLength(255)]
        public string SalesPerson { get; set; }

        [StringLength(255)]
        public string PSTExemptionNum { get; set; }

        [StringLength(255)]
        public string HST13 { get; set; }

        [StringLength(255)]
        public string HST15 { get; set; }

        [StringLength(255)]
        public string USAResellerPermitNum { get; set; }

        [StringLength(255)]
        public string USAIRSNum { get; set; }

        [StringLength(255)]
        public string PaymentMethod { get; set; }

        [StringLength(255)]
        public string Currency { get; set; }

        [Column(TypeName = "money")]
        public decimal? CreditTerms { get; set; }

        [StringLength(255)]
        public string DaysBeforeDue { get; set; }

        [StringLength(255)]
        public string SendStatement { get; set; }

        [StringLength(255)]
        public string ShippingMethod { get; set; }

        [StringLength(255)]
        public string ShippingComments { get; set; }

        [StringLength(255)]
        public string CarrierOne { get; set; }

        [StringLength(255)]
        public string CarrierOneAccNum { get; set; }

        [StringLength(255)]
        public string CarrierTwo { get; set; }

        [StringLength(255)]
        public string CarrierTwoAccNum { get; set; }

        [StringLength(255)]
        public string CarrierThree { get; set; }

        [StringLength(255)]
        public string CarrierThreeAccNum { get; set; }

        [StringLength(255)]
        public string ShipCharges { get; set; }

        public double? Packaging { get; set; }

        [StringLength(255)]
        public string GeneralComments { get; set; }

        [StringLength(255)]
        public string GeneralComments1 { get; set; }

        public virtual CustomerContact CustomerContact { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCarrier> CustomerCarriers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Part> Parts { get; set; }
    }
}
