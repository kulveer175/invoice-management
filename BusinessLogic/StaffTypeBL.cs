using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessModel;

namespace BusinessLogic
{
    public class StaffTypeBL
    {
        public static List<StaffType> GetAll()
        {
            return StaffTypeDA.GetAll();
        }
    }
}
