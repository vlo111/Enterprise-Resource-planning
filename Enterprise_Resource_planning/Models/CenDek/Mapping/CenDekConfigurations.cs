using Enterprise_Resource_planning.Models.CenDek.Tables;
using System.Data.Entity;

namespace Enterprise_Resource_planning.Models.CenDek.Configurations
{
    public class CenDekConfigurations
    {
        internal static void CenDekConfigurationsInsert(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Carrier>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Carrier>()
                .HasMany(e => e.CustomerCarriers)
                .WithRequired(e => e.Carrier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colour>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Colour>()
                .Property(e => e.Hex)
                .IsUnicode(false);

            modelBuilder.Entity<Colour>()
                .Property(e => e.ShopColour)
                .IsUnicode(false);

            modelBuilder.Entity<Currency>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Currency>()
                .Property(e => e.CurrencyName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CreditTerms)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerCarriers)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerCarrier>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<CustOrder>()
                .Property(e => e.PONum)
                .IsUnicode(false);

            modelBuilder.Entity<CustOrder>()
                .Property(e => e.InvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<CustOrder>()
                .Property(e => e.CostTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CustOrder>()
                .Property(e => e.SellTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CustOrder>()
                .Property(e => e.CommentsCentury)
                .IsFixedLength();

            modelBuilder.Entity<CustOrder>()
                .Property(e => e.WorkOrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<CustOrder>()
                .HasMany(e => e.OrderParts)
                .WithMany(e => e.CustOrders)
                .Map(m => m.ToTable("CustOrderPart").MapLeftKey("CustOrderID").MapRightKey("OrderPartID"));

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeLookupID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<File>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<File>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<GroupUrgency>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<GroupUrgency>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Ext)
                .IsUnicode(false);

            modelBuilder.Entity<MeasUnit>()
                .Property(e => e.ShortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<MeasUnit>()
                .Property(e => e.LongDescription)
                .IsUnicode(false);

            modelBuilder.Entity<OrderPart>()
                .Property(e => e.ColourID)
                .IsFixedLength();

            modelBuilder.Entity<OrderPart>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<PartStatu>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Price>()
                .Property(e => e.CostValue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Price>()
                .Property(e => e.SellValue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductLine>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProductLine>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Shipment>()
                .Property(e => e.ShippingTimeFrameID)
                .IsFixedLength();

            modelBuilder.Entity<ShippingAddress>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<WeightMeasurement>()
                .Property(e => e.Name)
                .IsUnicode(false);

        }
    }
}