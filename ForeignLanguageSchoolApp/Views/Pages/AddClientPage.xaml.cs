using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolApp.Models;
using ForeignLanguageSchoolLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        ClientsInfoCheck clientsInfoCheck = new ClientsInfoCheck();
        ClientsController clientsController = new ClientsController();
        GendersController gendersController = new GendersController();
        string filePath = null;
        public AddClientPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
            GenderComboBox.ItemsSource = gendersController.GetGendersListString();
        }

        private void BackButtonClickClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (!clientsInfoCheck.CheckFIOInfo(SurnameTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели фамилию", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!clientsInfoCheck.CheckFIOInfo(NameTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели имя", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!clientsInfoCheck.CheckFIOInfo(PatronymicTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели отчество", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!clientsInfoCheck.CheckEmailInfo(EmailTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели email", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!clientsInfoCheck.CheckPhoneInfo(PhoneTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели телефон", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!clientsInfoCheck.CheckLoginInfo(LoginTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели логин", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!clientsInfoCheck.CheckPasswordInfo(PasswordTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели пароль", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (GenderComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали пол", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (BirthDateDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Вы не выбрали дату", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (BirthDateDatePicker.SelectedDate.Value.Year > DateTime.Now.Year - 5)
            {
                MessageBox.Show("Вы неправильно выбрали дату", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (clientsController.GetClientByLogin(LoginTextBox.Text) != null)
            {
                MessageBox.Show("Клиент с данным логином уже существует", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (filePath == null)
            {
                MessageBox.Show("Вы не загрузили фотографию", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string photoName = "";
            if (filePath.Contains(".png"))
            {
                photoName = LoginTextBox.Text + ".png";
            }
            else
            {
                photoName = LoginTextBox.Text + ".jpg";
            }
            File.Copy(filePath, $"{Directory.GetCurrentDirectory()}\\Images\\{photoName}");
            Clients clients = new Clients() {
                ClientSurname = SurnameTextBox.Text,
                ClientName = NameTextBox.Text,
                ClientPatronymic = PatronymicTextBox.Text,
                ClientEmail = EmailTextBox.Text,
                ClientPhone = PhoneTextBox.Text,
                ClientBirthDate = (DateTime)BirthDateDatePicker.SelectedDate,
                GenderId = gendersController.GetGendersList()[GenderComboBox.SelectedIndex].IdGender,
                ClientPhotoLink = photoName,
                ClientUniqueInfo = InformationTextBox.Text,
                ClientPassword = PasswordTextBox.Text,
                ClientLogin = LoginTextBox.Text
            };
            if (!clientsController.AddClient(clients))
            {
                MessageBox.Show("Не получилось добавить клиента", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Клиент успешно добавлен", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
            this.NavigationService.GoBack();
        }
        private void DownloadPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files (*.png)|*.png|Jpeg files (*.jpg)|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                ClientImage.Source = new BitmapImage(new Uri(filePath));
            }
        }
    }
}
