using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprise_Resource_planning.Models.CenDek.Tables
{
    public class ListPTable
    {
        public int PartID { get; set; }
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string PartPrimary { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string First { get; set; }
        public decimal CostValue { get; set; }
        public decimal SellValue { get; set; }
        public DateTime ValidStart { get; set; }
        public DateTime ValidEnd { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}