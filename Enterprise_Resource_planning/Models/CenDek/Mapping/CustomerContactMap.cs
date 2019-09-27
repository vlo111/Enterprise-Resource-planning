using Enterprise_Resource_planning.Models.CenDek.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class CustomerContactMap : EntityTypeConfiguration<CustomerContact>
    {
        public CustomerContactMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID);

            // Properties
            this.Property(t => t.First)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CustomerContact");
            this.Property(t => t.CustomerID).HasColumnName("CustomerContactID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.First).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.Customers)
                .WithMany()
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
