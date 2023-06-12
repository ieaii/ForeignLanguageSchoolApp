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
    /// Логика взаимодействия для AddCoursePage.xaml
    /// </summary>
    public partial class AddCoursePage : Page
    {
        CoursesController coursesController = new CoursesController();
        Courses currentCourses = null;
        CoursesInfoCheck сoursesInfoCheck = new CoursesInfoCheck();
        public AddCoursePage()
        {
            InitializeComponent();
        }

        public AddCoursePage(Courses courses)
        {
            InitializeComponent();
            currentCourses = courses;
            NameTextBox.Text = courses.CourseName;
            DescriptionTextBox.Text = courses.CourseDescription;
        }

        public bool ValidateFields()
        {
            if (!сoursesInfoCheck.CheckNameInfo(NameTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели название", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!сoursesInfoCheck.CheckDescriptionInfoInfo(DescriptionTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели описание", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }
            if (currentCourses == null)
            {
                Courses courses = new Courses()
                {
                    CourseName = NameTextBox.Text,
                    CourseDescription = DescriptionTextBox.Text
                };
                if (!coursesController.AddCourse(courses))
                {
                    MessageBox.Show("Не получилось добавить курс", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Курс успешно добавлен", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
            else
            {
                currentCourses.CourseName = NameTextBox.Text;
                currentCourses.CourseDescription = DescriptionTextBox.Text;
                coursesController.UpdateCourse(currentCourses);
                
                MessageBox.Show("Курс успешно обновлен", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
        }
        private void BackButtonClickClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
