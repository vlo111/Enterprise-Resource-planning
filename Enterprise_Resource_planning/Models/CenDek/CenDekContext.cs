using Enterprise_Resource_planning.Models.CenDek.Configurations;
using Enterprise_Resource_planning.Models.CenDek.Tables;
using System.Data.Entity;
namespace Enterprise_Resource_planning.Models.CenDek
{
    public class CenDekContext : DbContext
    {
        public CenDekContext() : base("name=CenDekProgram")
        {
            Database.SetInitializer<CenDekContext>(null);
        }

        public virtual DbSet<AltPart> AltParts { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<ContactInfo> ContactInfoes { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCarrier> CustomerCarriers { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        public virtual DbSet<CustOrder> CustOrders { get; set; }
        public virtual DbSet<CustOrderFile> CustOrderFiles { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FileTmp> FileTmps { get; set; }
        public virtual DbSet<GroupUrgency> GroupUrgencies { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MeasUnit> MeasUnits { get; set; }
        public virtual DbSet<OrderPart> OrderParts { get; set; }
        public virtual DbSet<OrderPartFile> OrderPartFiles { get; set; }
        public virtual DbSet<OrderPartTag> OrderPartTags { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<PartDependency> PartDependencies { get; set; }
        public virtual DbSet<PartFile> PartFiles { get; set; }
        public virtual DbSet<PartInventory> PartInventories { get; set; }
        public virtual DbSet<PartStatu> PartStatus { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ProductLine> ProductLines { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagFile> TagFiles { get; set; }
        public virtual DbSet<WeightMeasurement> WeightMeasurements { get; set; }
        public virtual DbSet<ContactInfoType> ContactInfoTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add
            CenDekConfigurations.CenDekConfigurationsInsert(modelBuilder);
        }

    }
}