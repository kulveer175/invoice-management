using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessModel;

namespace BusinessLogic
{
    public class QuotationDetailsBL
    {
        public static bool Add(List<QuotationDetails> details)
        {
            return QuotationDetailsDA.Add(details);
        }

        public static List<QuotationDetails> GetAllDetailsForQuotation(int quotationId)
        {
            return QuotationDetailsDA.GetAllDetailsForQuotation(quotationId);
        }
    }
}
