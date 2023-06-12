using ForeignLanguageSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ForeignLanguageSchoolApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Users currentUser = null;
        public static Clients currentClient = null;
        public static Microsoft.Office.Interop.Word.Application wordApplication = null;
        public static Microsoft.Office.Interop.Excel.Application excelApplication = null;

    }
}
