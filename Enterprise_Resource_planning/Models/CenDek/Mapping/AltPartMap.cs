using Enterprise_Resource_planning.Models.CenDek.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace DataAccess.Models.Mapping
{
    public class AltPartIDMap : EntityTypeConfiguration<AltPart>
    {
        public AltPartIDMap()
        {
            // Primary Key
            this.HasKey(t => t.AltPartID);

            // Properties
            this.Property(t => t.PartNo)
                .IsRequired();
        }
        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}