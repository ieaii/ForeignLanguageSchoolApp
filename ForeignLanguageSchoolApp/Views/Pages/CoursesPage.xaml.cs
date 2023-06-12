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
    /// Логика взаимодействия для CoursesPage.xaml
    /// </summary>
    public partial class CoursesPage : Page
    {
        CoursesController coursesController = new CoursesController();
        GroupsController groupsController = new GroupsController();
        public CoursesPage()
        {
            InitializeComponent();
            if (App.currentUser != null)
            {
                UserTextblock.Text = App.currentUser.UserSurnameAndName;
            }
            
        }

        public void UpdateList()
        {
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = coursesController.GetCoursesList();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddCoursePage());
        }

        private void RedactButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.NavigationService.Navigate(new AddCoursePage(coursesController.GetCourseById(Convert.ToInt32(button.Uid))));
        }
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            var result = MessageBox.Show("вы действительно хотите удалить данный курс?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Courses courses = coursesController.GetCourseById(Convert.ToInt32(button.Uid));
                
                Groups groups = groupsController.GetGroupByCourseId(courses.IdCourse);
                if (groups != null)
                {
                    groups.CourseId = null;
                    if (!groupsController.UpdateGroup(groups))
                    {
                        MessageBox.Show("Не получилось обновить группу", "Ошибка обновления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                if (!coursesController.DeleteCourse(courses))
                {
                    MessageBox.Show("Не получилось удалить курс", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Курс удален", "Успешно удалено", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateList();
            }
        }
    }
}
