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
    /// Логика взаимодействия для AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        Users currentUsers = null;
        ClientsInfoCheck clientsInfoCheck = new ClientsInfoCheck();
        UsersController usersController = new UsersController();
        GroupsController groupsController = new GroupsController();
        public AddTeacherPage()
        {
            InitializeComponent();
            GroupComboBox.ItemsSource = groupsController.GetGroupsListString();
        }

        public AddTeacherPage(Users users)
        {
            currentUsers = users;
            InitializeComponent();
            LoginTextBox.Text = currentUsers.UserLogin;
            PasswordTextBox.Text = currentUsers.UserPassword;
            NameTextBox.Text = currentUsers.UserName;
            PatronymicTextBox.Text = currentUsers.UserPatronymic;
            SurnameTextBox.Text = currentUsers.UserSurname;
        }

        public bool ValidateFields()
        {
            if (!clientsInfoCheck.CheckFIOInfo(SurnameTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели фамилию", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!clientsInfoCheck.CheckFIOInfo(NameTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели имя", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!clientsInfoCheck.CheckFIOInfo(PatronymicTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели отчество", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }         
            if (!clientsInfoCheck.CheckLoginInfo(LoginTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели логин", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!clientsInfoCheck.CheckPasswordInfo(PasswordTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели пароль", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (currentUsers == null)
            {
                if (usersController.GetUserByLogin(LoginTextBox.Text) != null)
                {
                    MessageBox.Show("Пользователь с данным логином уже существует", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                if (currentUsers.UserLogin != LoginTextBox.Text)
                {
                    if (usersController.GetUserByLogin(LoginTextBox.Text) != null)
                    {
                        MessageBox.Show("Пользователь с данным логином уже существует", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }              
            }
            return true;
        }
        private void BackButtonClickClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentUsers == null)
            {
                if (!ValidateFields())
                {
                    return;
                }
                Users users = new Users()
                {
                    UserTypeId = 3,
                    UserLogin = LoginTextBox.Text,
                    UserPassword = PasswordTextBox.Text,
                    UserName = NameTextBox.Text,
                    UserPatronymic = PatronymicTextBox.Text,
                    UserSurname = SurnameTextBox.Text
                };
                if (!usersController.AddUser(users))
                {
                    MessageBox.Show("Не получилось добавить пользователя", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (GroupComboBox.SelectedIndex > -1)
                {
                    Groups groups = groupsController.GetGroupsList()[GroupComboBox.SelectedIndex];
                    if (groups.UserId != null)
                    {
                        var result = MessageBox.Show("К данной группе уже прикреплен учитель, хотите заменить?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            groups.UserId = usersController.GetLastAddedUser().IdUser;
                            if (!groupsController.UpdateGroup(groups))
                            {
                                MessageBox.Show("Не получилось обновить группу", "Ошибка обновления", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                    }       
                }
                MessageBox.Show("Пользователь успешно добавлен", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
            else
            {
                if (!ValidateFields())
                {
                    return;
                }
                currentUsers.UserLogin = LoginTextBox.Text;
                currentUsers.UserPassword = PasswordTextBox.Text;
                currentUsers.UserName = NameTextBox.Text;
                currentUsers.UserPatronymic = PatronymicTextBox.Text;
                currentUsers.UserSurname = SurnameTextBox.Text;
                usersController.UpdateUser(currentUsers);
                if (GroupComboBox.SelectedIndex > -1)
                {
                    Groups groups = groupsController.GetGroupsList()[GroupComboBox.SelectedIndex];
                    if (groups.UserId == currentUsers.IdUser)
                    {
                        MessageBox.Show("Пользователь успешно обновлен", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.NavigationService.GoBack();
                        return;
                    }
                    if (groups.UserId != null)
                    {
                        var result = MessageBox.Show("К данной группе уже прикреплен учитель, хотите заменить?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            groups.UserId = usersController.GetLastAddedUser().IdUser;
                            if (!groupsController.UpdateGroup(groups))
                            {
                                MessageBox.Show("Не получилось обновить группу", "Ошибка обновления", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                    }
                }
                MessageBox.Show("Пользователь успешно обновлен", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
        }
    }
}
