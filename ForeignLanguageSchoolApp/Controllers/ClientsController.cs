using ForeignLanguageSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class ClientsController : MainController
    {
        public Clients GetClientByLoginAndPassword(string password, string login)
        {
            return dataBase.context.Clients.FirstOrDefault(user => user.ClientPassword == password && user.ClientLogin == login);
        }

        public Clients GetClientByLogin(string login)
        {
            return dataBase.context.Clients.FirstOrDefault(user => user.ClientLogin == login);
        }

        public Clients GetClientById(int id)
        {
            return dataBase.context.Clients.FirstOrDefault(user => user.IdClient == id);
        }

        public List<Clients> GetClientsList()
        {
            return dataBase.context.Clients.ToList();
        }

        public bool AddClient(Clients clients)
        {
            try
            {
                dataBase.context.Clients.Add(clients);
                if (dataBase.context.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
