using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class Client
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string BusinessEmailId { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string CPFirstName { get; set; }
        public string CPLastName { get; set; }
        public string CPFullName
        {
            get
            {
                return this.CPFirstName + " " + CPLastName;
            }
        }
    }
}
