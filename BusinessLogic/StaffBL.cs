using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using DataAccess;

namespace BusinessLogic
{
    public class StaffBL
    {
        public static bool Add(Staff official)
        {
            return StaffDA.Add(official);
        }

        public static bool Update(Staff official)
        {
            return StaffDA.Update(official);
        }

        public static bool Delete(Staff official)
        {
            return StaffDA.Delete(official);
        }

        public static Staff GetDetails(int id)
        {
            return StaffDA.GetDetails(id);
        }

        public static List<Staff> GetAll()
        {
            return StaffDA.GetAll();
        }
    }
}
