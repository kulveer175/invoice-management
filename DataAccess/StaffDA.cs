using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using System.Data.Entity;

namespace DataAccess
{
    public class StaffDA
    {
        public static bool Add(Staff official)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                context.Staffs.Add(official);
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static bool Update(Staff official)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                var InDb = context.Staffs.Include(o => o.StaffType).FirstOrDefault(o => o.Id == official.Id);

                InDb.FirstName = official.FirstName;
                InDb.LastName = official.LastName;
                InDb.EmailId = official.EmailId;
                InDb.PhoneNumber = official.PhoneNumber;
                InDb.EmergencyContactNumber = official.EmergencyContactNumber;
                InDb.HomeAddress = official.HomeAddress;
                InDb.WorkAddress = official.WorkAddress;
                InDb.StaffTypeId = official.StaffTypeId;
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static bool Delete(Staff official)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                var InDb = context.Staffs.Find(official.Id);
                context.Staffs.Remove(InDb);
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static Staff GetDetails(int id)
        {
            using (var context = new InvoiceModel())
            {
                return context.Staffs.Include(o => o.StaffType).FirstOrDefault(o => o.Id == id);
            }
        }

        public static List<Staff> GetAll()
        {
            using (var context = new InvoiceModel())
            {
                return context.Staffs.Include(o => o.StaffType).ToList();
            }
        }
    }
}
