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
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        UsersController usersController = new UsersController();
        MessagesController messagesController = new MessagesController();
        public MessagePage()
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
            TeacherComboBox.ItemsSource = usersController.GetTeachersListString();
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            if (TeacherComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали учителя", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageTextBox.Text == null || MessageTextBox.Text == "" || MessageTextBox.Text == " ")
            {
                MessageBox.Show("Вы не ввели сообщение", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Messages messages = new Messages()
            {
                MessageMessage = MessageTextBox.Text,
                ClientId = App.currentClient.IdClient,
                UserId = usersController.GetTeachersList()[TeacherComboBox.SelectedIndex].IdUser
            };
            if (!messagesController.AddNewMessage(messages))
            {
                MessageBox.Show("Не получилось отправить сообщение", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Сообщение успешно отправлено", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
            this.NavigationService.GoBack();
        }
    }
}
