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
    /// Логика взаимодействия для TeacherClassesPage.xaml
    /// </summary>
    public partial class TeacherClassesPage : Page
    {
        ClassesController classesController = new ClassesController();
        GroupsController groupsController = new GroupsController();
        Groups currentGroups = null;
        public TeacherClassesPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
            currentGroups = groupsController.GetGroupByUserId(App.currentUser.IdUser);
        }

        public void UpdateList()
        {
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = classesController.GetClassesListByGroupId(currentGroups.IdGroup);
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddClassPage());
        }

        private void OpenClassPageClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.NavigationService.Navigate(new ClassInfoPage(classesController.GetClassById(Convert.ToInt32(button.Uid))));
        }
    }
}
