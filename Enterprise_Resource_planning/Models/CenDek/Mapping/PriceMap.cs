using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Enterprise_Resource_planning.Models.CenDek.Tables;

namespace DataAccess.Models.Mapping
{
    public class PriceMap : EntityTypeConfiguration<Price>
    {
        public PriceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Price");
            this.Property(t => t.ID).HasColumnName("PriceID");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.ValidStart).HasColumnName("ValidStart");
            this.Property(t => t.ValidEnd).HasColumnName("ValidEnd");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CostValue).HasColumnName("CostValue");
            this.Property(t => t.CostCurrencyID).HasColumnName("CostCurrencyID");
            this.Property(t => t.SellValue).HasColumnName("SellValue");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");

        }
    }
}
