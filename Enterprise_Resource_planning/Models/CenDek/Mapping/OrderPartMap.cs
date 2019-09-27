using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Enterprise_Resource_planning.Models.CenDek.Tables;

namespace DataAccess.Models.Mapping
{
    public class OrderPartMap : EntityTypeConfiguration<OrderPart>
    {
        public OrderPartMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderPartID);

            // Properties
            this.Property(t => t.ColourID)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("OrderPart");
            this.Property(t => t.OrderPartID).HasColumnName("OrderPartID");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.PriceID).HasColumnName("PriceID");
            this.Property(t => t.GroupUrgencyID).HasColumnName("GroupUrgencyID");
            this.Property(t => t.ColourID).HasColumnName("ColourID");
            this.Property(t => t.Comments).HasColumnName("Comments");

        }
    }
}
