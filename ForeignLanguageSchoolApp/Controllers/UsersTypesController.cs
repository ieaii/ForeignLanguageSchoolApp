using ForeignLanguageSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class UsersTypesController : MainController
    {
        public List<UsersTypes> GetUsersTypesList()
        {
            return dataBase.context.UsersTypes.ToList();
        }

        public List<string> GetUsersTypesListString()
        {
            List<string> strings = new List<string>();
            List<UsersTypes> usersTypes = GetUsersTypesList();
            foreach (UsersTypes item in usersTypes)
            {
                strings.Add(item.UserTypeName);
            }
            return strings;
        }
    }
}
