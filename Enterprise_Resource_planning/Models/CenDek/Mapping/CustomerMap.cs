using Enterprise_Resource_planning.Models.CenDek.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID);

            // Properties


            this.Property(t => t.Company)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.Modified).HasColumnName("Modified");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.GSTExempt).HasColumnName("GSTExempt");
            this.Property(t => t.PSTExempt).HasColumnName("PSTExempt");
        }
    }
}
