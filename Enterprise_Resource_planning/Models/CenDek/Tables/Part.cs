namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Part")]
    public partial class Part
    {
        public Part()
        {
            MeasUnit = new MeasUnit();
            Category = new Category();
            this.Files = new List<File>();
            Price = new Price();
            CustomerContact = new CustomerContact();
        }
        public int PartID { get; set; }

        public int? AltPartID { get; set; }

        public int? CustomerID { get; set; }

        public int ProductLineID { get; set; }

        [Required(ErrorMessage = "Required field Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? CategoryID { get; set; }

        public int? ImageID { get; set; }

        public int? PartStatusID { get; set; }

        public bool CustomFlag { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int EmployeeID { get; set; }

        public int? WeightMeasurementID { get; set; }

        public double Weight { get; set; }

        public double? Height { get; set; }

        public double? Width { get; set; }

        public double? Length { get; set; }

        public int? PriceID { get; set; }

        public int? MeasUnitID { get; set; }

        public int? PartInventoryID { get; set; }
        public int? CustomerContactID { get; set; }


        [Required(ErrorMessage = "Required field Primary Name")]
        public string PartPrimary { get; set; }


        public virtual Image Image { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual Category Category { get; set; }
        public virtual MeasUnit MeasUnit { get; set; }
        public virtual CustomerContact CustomerContact { get; set; }
        public virtual Price Price { get; set; }
    }
}
