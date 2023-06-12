using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolApp.Models;
using ForeignLanguageSchoolApp.Utils;
using Microsoft.Vbe.Interop;
using Microsoft.Win32;
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
    /// Логика взаимодействия для ClassInfoPage.xaml
    /// </summary>
    public partial class ClassInfoPage : Page
    {
        ClassesController classesController = new ClassesController();
        ClassesClientsController classesClientsController = new ClassesClientsController();
        ClientsController clientsController = new ClientsController();
        GroupsClientsController GroupsClientsController = new GroupsClientsController();
        GroupsController groupsController = new GroupsController();
        Classes curentClasses = null;
        List<Clients> clients = new List<Clients>();
        WordOtchet wordOtchet = new WordOtchet();

        public ClassInfoPage(Classes classes)
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
            curentClasses = classes;
            TimeAndDate.Text = classes.DateAndTimeString;
            Groups groups = groupsController.GetGroupByUserId(App.currentUser.IdUser);
            List<GroupsClients> groupsClients = GroupsClientsController.GetGroupsClientsByGroupId(groups.IdGroup);
            
            foreach (GroupsClients item in groupsClients)
            {
                clients.Add(clientsController.GetClientById(item.IdClient));
            }
            MainListView.ItemsSource = clients;
        }
        
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


        private void RedactButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddClassPage(curentClasses));
        }

        private void VisitButtonClick(object sender, RoutedEventArgs e)
        {
            if (curentClasses.ClassDate > DateTime.Now)
            {
                MessageBox.Show("Занятие еще не прошло", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (curentClasses.ClassTime > DateTime.Now.TimeOfDay && curentClasses.ClassDate == DateTime.Now.Date)
            {
                MessageBox.Show("Занятие еще не прошло", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (Clients item in clients)
            {
                if (classesClientsController.GetClassClientByClassAndClientId(curentClasses.IdClass, item.IdClient) == null)
                {
                    ClassesClients classesClients = new ClassesClients()
                    {
                        ClassId = curentClasses.IdClass,
                        ClientId = item.IdClient,
                        IsClientWasOnClass = item.IsChecked == true ? (byte)1 : (byte)0
                    };
                    if (!classesClientsController.AddClassesClients(classesClients))
                    {
                        MessageBox.Show("Не получилось отметить занятие", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            MessageBox.Show("Посещение записано", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void ClientCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            clients.FirstOrDefault(client => client.IdClient == Convert.ToInt32(checkBox.Uid)).IsChecked = true;
        }

        private void ClientCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            clients.FirstOrDefault(client => client.IdClient == Convert.ToInt32(checkBox.Uid)).IsChecked = false;
        }



        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("вы действительно хотите удалить данное занятие?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<ClassesClients> classesClients = classesClientsController.GetClassClientByClassId(curentClasses.IdClass);
                foreach (ClassesClients item in classesClients)
                {
                    classesClientsController.DeleteClassesClients(item);
                }
                classesController.DeleteClasses(curentClasses);
                MessageBox.Show("Занятие успешно удалено", "Успешно удалено", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
        }


        private void HomeworkButtonClick(object sender, RoutedEventArgs e)
        {
            if (curentClasses.HomeworkLink != null)
            {
                MessageBox.Show("Домашнее задание уже добавлено", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word files docx (*.docx)|*.docx|Word files doc (*.doc)|*.doc";
            if (openFileDialog.ShowDialog() == true)
            {
                wordOtchet.HomeworkWordAdd(curentClasses, openFileDialog.FileName);
            }
        }
    }
}
