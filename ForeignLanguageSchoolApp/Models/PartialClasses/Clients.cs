using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Models
{
    public partial class Clients
    {
        public string ClientNameAndSurname
        {
            get
            {
                return ClientSurname + " " + ClientName;
            }
        }

        public bool IsChecked = false;
    }
}
