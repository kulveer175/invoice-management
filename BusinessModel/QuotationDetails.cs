using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class QuotationDetails
    {
        public int Id { get; set; }
        public int QuotationId { get; set; }
        public Quotation Quotation { get; set; }
        public int ProductLineId { get; set; }
        public ProductLine ProductLine { get; set; }
        public int Quantity { get; set; }
        public double TotalProductPrice { get; set; }
    }
}
