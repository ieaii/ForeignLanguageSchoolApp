using ForeignLanguageSchoolLibraryTests.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class CoursesController : MainController
    {
        public Courses GetCourseById(int id)
        {
            return dataBase.context.Courses.FirstOrDefault(courses => courses.IdCourse == id);
        }

        public List<Courses> GetCoursesList()
        {
            return dataBase.context.Courses.ToList();
        }

        public List<string> GetCoursesListString()
        {
            List<string> strings = new List<string>();
            List<Courses> courses = GetCoursesList();
            foreach (Courses item in courses)
            {
                strings.Add(item.CourseName);
            }
            return strings;
        }

        public bool AddCourse(Courses courses)
        {
            try
            {
                dataBase.context.Courses.Add(courses);
                if (dataBase.context.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateCourse(Courses courses)
        {
            try
            {
                dataBase.context.Courses.AddOrUpdate(courses);
                if (dataBase.context.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCourse(Courses courses)
        {
            try
            {
                Courses coursestoDelete = GetCourseById(courses.IdCourse);
                dataBase.context.Courses.Remove(coursestoDelete);
                if (dataBase.context.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
