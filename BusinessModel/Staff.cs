using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string HomeAddress { get; set; }
        public string WorkAddress { get; set; }
        public int StaffTypeId { get; set; }
        public StaffType StaffType { get; set; }
    }
}
