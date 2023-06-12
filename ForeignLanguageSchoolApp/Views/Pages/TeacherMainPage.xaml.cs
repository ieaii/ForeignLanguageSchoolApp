using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolApp.Models;
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
    /// Логика взаимодействия для TeacherMainPage.xaml
    /// </summary>
    public partial class TeacherMainPage : Page
    {
        GroupsController groupsController = new GroupsController();
        Groups currentGroups = new Groups();
        WordOtchet wordOtchet = new WordOtchet();
        public TeacherMainPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
            currentGroups = groupsController.GetGroupByUserId(App.currentUser.IdUser);
        }

        private void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            App.currentClient = null;
            App.currentUser = null;
            this.NavigationService.Navigate(new AuthPage());
        }

        private void MessagesButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TeachersMessagesPage());
        }



        private void ClassesPageClick(object sender, RoutedEventArgs e)
        {
            if (currentGroups == null)
            {
                MessageBox.Show("Вы не прикреплены к группе", "Группы нет", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            this.NavigationService.Navigate(new TeacherClassesPage());
        }


        private void SpisocButtonClick(object sender, RoutedEventArgs e)
        {
            wordOtchet.StudentsOtchet(currentGroups);
        }
    }
}
