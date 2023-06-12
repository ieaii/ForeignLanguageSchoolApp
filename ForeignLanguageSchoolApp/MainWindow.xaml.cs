using ForeignLanguageSchoolApp.Views.Pages;
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

namespace ForeignLanguageSchoolApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPage());
        }

        private void MainFrameNavigated(object sender, NavigationEventArgs e)
        {
            var page = e.Content;
            if (page is TeachersPage)
            {
                TeachersPage currentPage = (TeachersPage)page;
                currentPage.UpdateList();
            }

            if (page is CoursesPage)
            {
                CoursesPage currentPage = (CoursesPage)page;
                currentPage.UpdateList();
            }

            if (page is TeacherClassesPage)
            {
                TeacherClassesPage currentPage = (TeacherClassesPage)page;
                currentPage.UpdateList();
            }
        }
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (App.wordApplication != null)
                {
                    App.wordApplication.Quit();
                }
                if (App.excelApplication != null)
                {
                    App.excelApplication.Quit();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {

            }
        }
    }
}
