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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForeignLanguageSchoolApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
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


        private void GroupsButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddGroupPage());

        }


        private void OtziviButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AllReviewsPage());

        }



        private void UslugClick(object sender, RoutedEventArgs e)
        {
            WordOtchet wordOtchet = new WordOtchet();
            wordOtchet.OpenDocument();
        }
    }
}
