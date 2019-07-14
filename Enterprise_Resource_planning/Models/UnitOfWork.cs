using Enterprise_Resource_planning.Models.CenDek.Tables;
using System;

namespace Enterprise_Resource_planning.Models
{
    public class UnitOfWork : IDisposable
    {

        private CenDek.CenDekContext _context = new CenDek.CenDekContext();
        #region Fields

        private Repository<ProductLine> _productLines;
        private Repository<MeasUnit> _measUnits;
        private Repository<PartStatu> _partStatus;
        private Repository<Currency> _currencies;
        private Repository<CustomerContact> _customerContacts;
        private Repository<Category> _category;
        private Repository<Part> _part;
        private Repository<Price> _price;
        private Repository<Image> _image;
        private Repository<DocumentType> _documentType;
        private Repository<AltPart> _altPart;

        #endregion
        #region Properties
        public Repository<ProductLine> ProductLineRepository => _productLines = new Repository<ProductLine>(_context);
        public Repository<MeasUnit> MeasUnitRepository => _measUnits = new Repository<MeasUnit>(_context);
        public Repository<PartStatu> PartStatuRepository => _partStatus = new Repository<PartStatu>(_context);
        public Repository<Currency> CurrencyRepository => _currencies = new Repository<Currency>(_context);
        public Repository<CustomerContact> CustomerContactRepository => _customerContacts = new Repository<CustomerContact>(_context);
        public Repository<Category> CategoryRepository => _category = new Repository<Category>(_context);
        public Repository<Part> PartRepository => _part = new Repository<Part>(_context);
        public Repository<Price> PriceRepository => _price = new Repository<Price>(_context);
        public Repository<Image> ImageRepository => _image = new Repository<Image>(_context);
        public Repository<DocumentType> DocumentTypeRepository => _documentType = new Repository<DocumentType>(_context);
        public Repository<AltPart> AltPartRepository => _altPart = new Repository<AltPart>(_context);
        #endregion
        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}