using ForeignLanguageSchoolApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForeignLanguageSchoolApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerMainPage.xaml
    /// </summary>
    public partial class ManagerMainPage : Page
    {
        public ManagerMainPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
        }

        private void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            App.currentClient = null;
            App.currentUser = null;
            this.NavigationService.Navigate(new AuthPage());
        }

        private void AddClientButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddClientPage());
        }

        private void TeachersButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TeachersPage());
        }


        private void CoursesButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CoursesPage());
        }



        private void OtchetButtonClick(object sender, RoutedEventArgs e)
        {
            ExcelOtchet excelOtchet = new ExcelOtchet();
            excelOtchet.FormOtchet();
        }
    }
}
