using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolLibrary
{
    public class CoursesInfoCheck
    {
        public bool CheckNameInfo(string nameInfo)
        {
            string namePatterm = @"^[А-Яа-я0-9\s]{1,50}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }

        public bool CheckDescriptionInfoInfo(string nameInfo)
        {
            string namePatterm = @"^[А-Яа-я0-9\s\.\,\-]{1,3000}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }
    }
}
