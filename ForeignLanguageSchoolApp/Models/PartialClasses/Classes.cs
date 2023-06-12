using ForeignLanguageSchoolApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Models
{
    public partial class Classes
    {
        CoursesController coursesController = new CoursesController();
        UsersController usersController = new UsersController();
        GroupsController groupsController = new GroupsController();
        public string TeacherName
        {
            get
            {
                
                if (groupsController.GetGroupById(IdGroup).UserId == null)
                {
                    return "Учитель не прикреплен";
                }
                return usersController.GetUserById((int)groupsController.GetGroupById(IdGroup).UserId).UserSurnameAndName;
            }
        }

        public string CourseName
        {
            get
            {
                if (groupsController.GetGroupById(IdGroup).CourseId == null)
                {
                    return "Курс не прикреплен";
                }
                return coursesController.GetCourseById((int)groupsController.GetGroupById(IdGroup).CourseId).CourseName;
            }
        }

        public string DateAndTimeString
        {
            get
            {
                return ClassDate.ToString("d") + " " + ClassTime.ToString(@"hh\:mm");
            }
        }

        public string WasClientOnClassString
        {
            get
            {
                ClassesClientsController classesClientsController = new ClassesClientsController();
                
                ClassesClients classesClients = classesClientsController.GetClassClientByClassAndClientId(IdClass, ClientId);
                if (classesClients == null)
                {
                    return "Посещение не отмечено";
                }
                if (classesClients.IsClientWasOnClass == null)
                {
                    return "Посещение не отмечено";
                }
                if (classesClients.IsClientWasOnClass == 1)
                {
                    return "Вы были на занятии";
                }
                return "Вас не было на занятии";
            }
        }

        public int ClientId;  
    }
}
