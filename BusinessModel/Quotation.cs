using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class Quotation
    {
        public int Id { get; set; }
        public DateTime DateOfRequest { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public double TotalPrice { get; set; }
        public bool OrderCreated { get; set; }
    }
}
