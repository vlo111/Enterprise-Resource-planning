using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Enterprise_Resource_planning.Models.CenDek.Tables;

namespace DataAccess.Models.Mapping
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            // Primary Key
            this.HasKey(t => t.TagID);

            // Properties
            this.Property(t => t.TagName)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Tag");
            this.Property(t => t.TagID).HasColumnName("TagID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.TagName).HasColumnName("TagName");
            this.Property(t => t.ShipmentID).HasColumnName("ShipmentID");

        }
    }
}
