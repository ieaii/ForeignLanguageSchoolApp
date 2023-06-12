using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolLibrary
{
    public class ClassInfoCheck
    {
        public bool CheckTimeInfo(string timeInfo)
        {
            if (Regex.IsMatch(timeInfo, @"^[0-2][0-3]\:[0-5][0-9]$"))
            {
                return true;
            }
            else if (Regex.IsMatch(timeInfo, @"^[0-1][0-9]\:[0-5][0-9]$"))
            {
                return true;
            }
            return false;


        }
    }
}
