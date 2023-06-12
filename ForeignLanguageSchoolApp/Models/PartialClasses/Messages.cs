using ForeignLanguageSchoolApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Models
{
    public partial class Messages
    {
        ClientsController clientsController = new ClientsController();
        public string ClientName
        {
            get
            {               
                return clientsController.GetClientById(ClientId).ClientNameAndSurname;
            }
        }
    }
}
