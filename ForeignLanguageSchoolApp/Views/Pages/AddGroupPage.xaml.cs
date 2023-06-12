using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolApp.Models;
using ForeignLanguageSchoolLibrary;
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
    /// Логика взаимодействия для AddGroupPage.xaml
    /// </summary>
    public partial class AddGroupPage : Page
    {
        List<Clients> clients = new List<Clients>();
        ClientsController clientsController = new ClientsController();
        GroupsClientsController groupsClients = new GroupsClientsController();
        GroupInfoCheck groupInfo = new GroupInfoCheck();
        CoursesController coursesController = new CoursesController();
        GroupsController groupsController = new GroupsController();

        List<Clients> clientsToAdd = new List<Clients>();
        public AddGroupPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }

            List<Clients> unsortedClients = clientsController.GetClientsList();
            foreach (var item in unsortedClients)
            {
                
                if (groupsClients.GetGroupsClientsByCLientId(item.IdClient).Count() == 0)
                {
                    clients.Add(item);
                }
            }

            MainListView.ItemsSource = clients;
            CourseCombo.ItemsSource = coursesController.GetCoursesListString();
        }



        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ClientCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            clientsToAdd.Add(clients.FirstOrDefault(client => client.IdClient == Convert.ToInt32(checkBox.Uid)));
            

        }

        private void ClientCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            clientsToAdd.Remove(clients.FirstOrDefault(client => client.IdClient == Convert.ToInt32(checkBox.Uid)));
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (!groupInfo.CheckNameInfo(TimeTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели имя группы", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (CourseCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали курс", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (clientsToAdd.Count == 0)
            {
                MessageBox.Show("Вы не добавили ни одного клиента", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Groups groups = new Groups()
            {
                GroupName = TimeTextBox.Text,
                CourseId = coursesController.GetCoursesList()[CourseCombo.SelectedIndex].IdCourse,

            };
            if (!groupsController.AddGroup(groups))
            {
                MessageBox.Show("Не удалось добавить группу", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Groups lastAddedGroup = groupsController.GetLastAddedGroup();
            foreach (Clients item in clientsToAdd)
            {
                GroupsClients groupsClientsNew = new GroupsClients()
                {
                    IdClient = item.IdClient,
                    IdGroup = lastAddedGroup.IdGroup
                };
                if (!groupsClients.AddGroupsClients(groupsClientsNew))
                {
                    MessageBox.Show("Не удалось добавить связь", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            MessageBox.Show("Группа создана", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            this.NavigationService.GoBack();
        }
    }
}
