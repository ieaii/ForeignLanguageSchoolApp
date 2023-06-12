using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolLibrary
{
    public class ClientsInfoCheck
    {
        public bool CheckFIOInfo(string nameInfo)
        {
            string namePatterm = @"^[А-Я][а-я]{1,20}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }

        public bool CheckPhoneInfo(string nameInfo)
        {
            string namePatterm = @"^7[0-9]{10}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }

        public bool CheckLoginInfo(string login)
        {
            string loginPatterm = @"^[a-zA-Z0-9]{3,10}$";
            return Regex.IsMatch(login, loginPatterm);
        }
        
        public bool CheckPasswordInfo(string password)
        {
            string passwordPatterm = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,20}$";
            return Regex.IsMatch(password, passwordPatterm);
        }

        public bool CheckEmailInfo(string email)
        {
            string emailPatterm = @"^[a-zA-Z0-9\#\.]{1,10}\@[a-zA-Z]{1,6}\.[a-zA-Z]{1,4}$";
            return Regex.IsMatch(email, emailPatterm);
        }

    }
}
