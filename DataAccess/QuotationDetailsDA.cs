using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using System.Data.Entity;

namespace DataAccess
{
    public class QuotationDetailsDA
    {
        public static bool Add(List<QuotationDetails> details)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                context.QuotationDetails.AddRange(details);
                i = context.SaveChanges();
                return i > 0;
            }
        }

        public static List<QuotationDetails> GetAllDetailsForQuotation(int quotationId)
        {
            using (var context = new InvoiceModel())
            {
                return context.QuotationDetails.Include(i => i.ProductLine).Where(i => i.QuotationId == quotationId).ToList();
            }
        }
    }
}
