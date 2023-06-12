using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolLibrary
{
    public class GroupInfoCheck
    {
        public bool CheckNameInfo(string nameInfo)
        {
            string namePatterm = @"^[А-Яа-яA-Za-z0-9\s\-]{1,20}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }
    }
}
