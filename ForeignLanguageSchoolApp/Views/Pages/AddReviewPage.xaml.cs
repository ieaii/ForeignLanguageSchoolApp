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
    /// Логика взаимодействия для AddReviewPage.xaml
    /// </summary>
    public partial class AddReviewPage : Page
    {
        ReviewsController reviewsController = new ReviewsController();
        public AddReviewPage()
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
            List<string> strings = new List<string>() { 
            "1",
           "2",
           "3",
           "4",
           "5"
            };
            RatingComboBox.ItemsSource = strings;
        }

        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            if (RatingComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали оценку", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageTextBox.Text == null || MessageTextBox.Text == "" || MessageTextBox.Text == " ")
            {
                MessageBox.Show("Вы не ввели отзыв", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Reviews reviews = new Reviews()
            {
                ReviewMessage = MessageTextBox.Text,
                ReviewRating = RatingComboBox.SelectedIndex + 1,
                ClientId = App.currentClient.IdClient
            };
            if (!reviewsController.AddNewReview(reviews))
            {
                MessageBox.Show("Не получилось добавить отзыв", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Отзыв успешно отправлен", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
            this.NavigationService.GoBack();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
