using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Enterprise_Resource_planning.Models.CenDek.Tables;

namespace DataAccess.Models.Mapping
{
    public class PartInventoryMap : EntityTypeConfiguration<PartInventory>
    {
        public PartInventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.PartInventoryID);

            // Properties
            this.Property(t => t.PartInventoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PartID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("PartInventory");
            this.Property(t => t.PartInventoryID).HasColumnName("PartInventoryID");
            this.Property(t => t.PartID).HasColumnName("PartID");


        }
    }
}
