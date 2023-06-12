using ForeignLanguageSchoolLibraryTests.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class GendersController : MainController
    {
        public List<Genders> GetGendersList()
        {
            return dataBase.context.Genders.ToList();
        }

        public List<string> GetGendersListString()
        {
            List<string> strings = new List<string>();
            List<Genders> genders = GetGendersList();
            foreach (Genders item in genders)
            {
                strings.Add(item.GenderName);
            }
            return strings;
        }
    }
}
