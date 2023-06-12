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
    /// Логика взаимодействия для AddClassPage.xaml
    /// </summary>
    public partial class AddClassPage : Page
    {
        ClassInfoCheck classInfoCheck = new ClassInfoCheck();
        Classes currentClasses = null;
        ClassesController classesController = new ClassesController();
        GroupsController groupsController = new GroupsController();
        public AddClassPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
        }

        public AddClassPage(Classes classes)
        {
            currentClasses = classes;
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
            DatePicker.SelectedDate = currentClasses.ClassDate;
            TimeTextBox.Text = currentClasses.ClassTime.Hours + ":" + currentClasses.ClassTime.Minutes;
        }

        public bool ValidateFields()
        {
            if (DatePicker.SelectedDate == null)
            {
                MessageBox.Show("Вы неправильно ввели дату", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (DatePicker.SelectedDate < DateTime.Now.Date)
            {
                MessageBox.Show("Вы неправильно ввели дату", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!classInfoCheck.CheckTimeInfo(TimeTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели время", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (ConvertStringToTimeSpan(TimeTextBox.Text) < DateTime.Now.TimeOfDay && DatePicker.SelectedDate <= DateTime.Now)
            {
                MessageBox.Show("Вы неправильно ввели время", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public TimeSpan ConvertStringToTimeSpan(string time)
        {
            return new TimeSpan(Convert.ToInt32(time.Split(':')[0]), Convert.ToInt32(time.Split(':')[1]), 0);
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }
            if (currentClasses == null)
            {
                Classes classes = new Classes()
                {
                    IdGroup = groupsController.GetGroupByUserId(App.currentUser.IdUser).IdGroup,
                    ClassDate = (DateTime)DatePicker.SelectedDate,
                    ClassTime = ConvertStringToTimeSpan(TimeTextBox.Text),
                };
                if (!classesController.AddClasses(classes))
                {
                    MessageBox.Show("Не удалось добавить занятие", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Занятие успешно добавлено", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
            else
            {
                currentClasses.ClassDate = (DateTime)DatePicker.SelectedDate;
                currentClasses.ClassTime = ConvertStringToTimeSpan(TimeTextBox.Text);
                classesController.UpdateClasses(currentClasses);
                
                MessageBox.Show("Занятие успешно обновлено", "Успешно обновлено", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
        }
    }
}
