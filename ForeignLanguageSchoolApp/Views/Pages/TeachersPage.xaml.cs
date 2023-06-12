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
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        UsersController usersController = new UsersController();
        MessagesController messagesController = new MessagesController();
        GroupsController groupsController = new GroupsController();
        public TeachersPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
            MainListView.ItemsSource = usersController.GetTeachersList();
        }


        public void UpdateList()
        {
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = usersController.GetTeachersList();
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddTeacherPage());
        }

        private void RedactButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.NavigationService.Navigate(new AddTeacherPage(usersController.GetUserById(Convert.ToInt32(button.Uid))));
        }


        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            var result = MessageBox.Show("вы действительно хотите удалить данный аккаунт?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Users userToDelete = usersController.GetUserById(Convert.ToInt32(button.Uid));
                List<Messages> messages = messagesController.GetMessagesListByTeacherId(userToDelete.IdUser);
                foreach (Messages item in messages)
                {
                    if (!messagesController.DeleteMessage(item))
                    {
                        MessageBox.Show("Не получилось удалить сообщение", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                Groups groups = groupsController.GetGroupByUserId(userToDelete.IdUser);
                if (groups != null)
                {
                    groups.UserId = null;
                    if (!groupsController.UpdateGroup(groups))
                    {
                        MessageBox.Show("Не получилось обновить группу", "Ошибка обновления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                
                if (!usersController.DeleteUser(userToDelete))
                {
                    MessageBox.Show("Не получилось удалить учителя", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Пользователь удален", "Успешно удалено", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateList();
            }
        }
    }
}
