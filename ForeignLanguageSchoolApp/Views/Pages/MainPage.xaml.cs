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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.currentClient != null)
            {
                UserTextblock.Text = App.currentClient.ClientNameAndSurname;
            }
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


        private void MessageButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MessagePage());
        }

        private void ReviewPageClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddReviewPage());

        }

        private void FutureClassesClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FutureClassesPage());
        }



        private void PastClassesClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PastClassesPage());
        }
    }
}
