using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using DataAccess;

namespace BusinessLogic
{
    public class ClientBL
    {
        public static int Add(Client client)
        {
            return ClientDA.Add(client);
        }

        public static bool Update(Client client)
        {
            return ClientDA.Update(client);
        }

        public static bool Delete(Client client)
        {
            return ClientDA.Delete(client);
        }

        public static Client GetDetails(int id)
        {
            return ClientDA.GetDetails(id);
        }

        public static List<Client> GetAll()
        {
            return ClientDA.GetAll();
        }
    }
}
