using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;

namespace DataAccess
{
    public class StaffTypeDA
    {
        public static List<StaffType> GetAll()
        {
            using (var context = new InvoiceModel())
            {
                return context.StaffTypes.ToList();
            }
        }
    }
}
