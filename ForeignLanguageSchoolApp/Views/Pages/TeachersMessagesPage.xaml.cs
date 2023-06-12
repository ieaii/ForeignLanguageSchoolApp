using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolApp.Models;
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
    /// Логика взаимодействия для TeachersMessagesPage.xaml
    /// </summary>
    public partial class TeachersMessagesPage : Page
    {
        MessagesController messagesController = new MessagesController();
        public TeachersMessagesPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
            MainListView.ItemsSource = messagesController.GetMessagesListByTeacherId(App.currentUser.IdUser);
        }

        private void BackButtonClickClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
