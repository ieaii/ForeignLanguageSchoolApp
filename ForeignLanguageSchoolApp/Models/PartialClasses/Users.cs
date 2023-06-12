using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Models
{
    public partial class Users
    {
        public string UserSurnameAndName { get {
                return UserSurname + " " + UserName;
            } }
    }
}
