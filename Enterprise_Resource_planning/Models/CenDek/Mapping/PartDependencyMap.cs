using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Enterprise_Resource_planning.Models.CenDek.Tables;

namespace DataAccess.Models.Mapping
{
    public class PartDependencyMap : EntityTypeConfiguration<PartDependency>
    {
        public PartDependencyMap()
        {
            // Primary Key
            this.HasKey(t => t.PartDependencyID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PartDependency");
            this.Property(t => t.PartDependencyID).HasColumnName("PartDependencyID");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.DependendPart).HasColumnName("DependendPart");
            this.Property(t => t.Required).HasColumnName("Required");
            this.Property(t => t.Number).HasColumnName("Number");

        }
    }
}
