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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForeignLanguageSchoolApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для PastClassesPage.xaml
    /// </summary>
    public partial class PastClassesPage : Page
    {
        ClassesController classesController = new ClassesController();
        GroupsClientsController groupsClientsController = new GroupsClientsController();
        public PastClassesPage()
        {
            InitializeComponent();
            if (App.currentClient != null)
            {
                UserTextblock.Text = App.currentClient.ClientNameAndSurname;
                List<GroupsClients> groupsClientsList = groupsClientsController.GetGroupsClientsByCLientId(App.currentClient.IdClient);
                List<Classes> classesList = new List<Classes>();
                foreach (GroupsClients item in groupsClientsList)
                {
                    List<Classes> classesListNew = classesController.GetPastClassesListByGroupId(item.IdGroup);
                    foreach (Classes item2 in classesListNew)
                    {
                        item2.ClientId = App.currentClient.IdClient;
                        classesList.Add(item2);
                    }
                }
                MainListView.ItemsSource = classesList;
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void DownloadHomeworkButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            WordOtchet wordOtchet = new WordOtchet();
            wordOtchet.OpenHomework(classesController.GetClassById(Convert.ToInt32(button.Uid)));
        }
    }
}
