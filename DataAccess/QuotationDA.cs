using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using System.Data.Entity;

namespace DataAccess
{
    public class QuotationDA
    {
        public static int Add(Quotation quotation)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                context.Quotations.Add(quotation);
                i = context.SaveChanges();

                return quotation.Id;
            }
        }

        public static bool UpdateOrderGenerated(int quotationId)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                var InDb = context.Quotations.Find(quotationId);
                InDb.OrderCreated = true;
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static Quotation GetDetails(int quotationId)
        {
            using (var context = new InvoiceModel())
            {
                return context.Quotations.Include(i => i.Client).FirstOrDefault(i => i.Id == quotationId);
            }
        }
        public static List<Quotation> GetAllByClient(int clientId)
        {
            using (var context = new InvoiceModel())
            {
                return context.Quotations.Where(q => q.ClientId == clientId).ToList();
            }
        }
    }
}
