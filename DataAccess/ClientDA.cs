using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;

namespace DataAccess
{
    public class ClientDA
    {
        public static int Add(Client client)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                context.Clients.Add(client);
                i = context.SaveChanges();

                return client.Id;
            }
        }

        public static bool Update(Client client)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                var InDb = context.Clients.Find(client.Id);
                InDb.BusinessName = client.BusinessName;
                InDb.Address = client.Address;
                InDb.CPFirstName = client.CPFirstName;
                InDb.CPLastName = client.CPLastName;
                InDb.BusinessEmailId = client.BusinessEmailId;
                InDb.BusinessPhoneNumber = client.BusinessPhoneNumber;
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static bool Delete(Client client)
        {
            using (var context = new InvoiceModel())
            {
                int i = 0;
                var InDb = context.Clients.Find(client.Id);
                context.Clients.Remove(InDb);
                i = context.SaveChanges();

                return i > 0;
            }
        }

        public static Client GetDetails(int id)
        {
            using (var context = new InvoiceModel())
            {
                return context.Clients.Find(id);
            }
        }

        public static Client GetDetailsByEmailId(string emailId)
        {
            using (var context = new InvoiceModel())
            {
                return context.Clients.FirstOrDefault(c => c.BusinessEmailId == emailId);
            }
        }

        public static List<Client> GetAll()
        {
            using (var context = new InvoiceModel())
            {
                return context.Clients.ToList();
            }
        }
    }
}
