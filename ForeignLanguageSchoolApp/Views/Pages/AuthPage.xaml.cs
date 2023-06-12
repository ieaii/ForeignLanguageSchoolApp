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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        UsersController usersController = new UsersController();
        ClientsController clientsController = new ClientsController();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthButtonClick(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == null || LoginTextBox.Text == "" || LoginTextBox.Text == " " || PasswordPasswordBox.Password == null || PasswordPasswordBox.Password == "" || PasswordPasswordBox.Password == " ")
            {
                MessageBox.Show("Вы ничего не ввели", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Clients clients = clientsController.GetClientByLoginAndPassword(PasswordPasswordBox.Password, LoginTextBox.Text);
            if (clients != null)
            {
                App.currentClient = clients;
                this.NavigationService.Navigate(new MainPage());
                return;
            }
            Users users = usersController.GetUserByLoginAndPassword(PasswordPasswordBox.Password, LoginTextBox.Text);
            if (users != null)
            {
                App.currentUser = users;
                if (users.UserTypeId == 2)
                {
                    this.NavigationService.Navigate(new ManagerMainPage());
                }
                if (users.UserTypeId == 3)
                {
                    this.NavigationService.Navigate(new TeacherMainPage());
                }
                if (users.UserTypeId == 1)
                {
                    this.NavigationService.Navigate(new AdminMainPage());
                }
                return;
            }
            MessageBox.Show("Пользователь не найден", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Warning);
            
        }
    }
}
