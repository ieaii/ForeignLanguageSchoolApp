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
    /// Логика взаимодействия для FutureClassesPage.xaml
    /// </summary>
    public partial class FutureClassesPage : Page
    {
        ClassesController classesController = new ClassesController();
        GroupsClientsController groupsClientsController = new GroupsClientsController();
        public FutureClassesPage()
        {
            InitializeComponent();
            if (App.currentClient != null)
            {
                UserTextblock.Text = App.currentClient.ClientNameAndSurname;
                List<GroupsClients> groupsClientsList = groupsClientsController.GetGroupsClientsByCLientId(App.currentClient.IdClient);
                List<Classes> classesList = new List<Classes>();
                foreach (GroupsClients item in groupsClientsList)
                {
                    List<Classes> classesListNew = classesController.GetFutureClassesListByGroupId(item.IdGroup);
                    foreach (Classes item2 in classesListNew)
                    {
                        classesList.Add(item2);
                    }
                }
                MainListView.ItemsSource = classesList;
            }
           
        }

        private void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
