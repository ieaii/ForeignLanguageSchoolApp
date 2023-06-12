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
    public class ClassesController : MainController
    {
        public List<Classes> GetFutureClassesListByGroupId(int id)
        {
            List<Classes> returnedClasses = new List<Classes>();
            List<Classes> futureClasses = dataBase.context.Classes.Where(classes => classes.IdGroup == id).ToList();
            foreach (Classes item in futureClasses)
            {
                if (item.ClassDate > DateTime.Now.Date)
                {
                    returnedClasses.Add(item);
                    continue;
                }
                if (item.ClassDate == DateTime.Now.Date)
                {
                    if (item.ClassTime > DateTime.Now.TimeOfDay)
                    {
                        returnedClasses.Add(item);
                    }
                }
            }
            return returnedClasses;
            
        }

        public List<Classes> GetPastClassesListByGroupId(int id)
        {
            List<Classes> returnedClasses = new List<Classes>();
            List<Classes> pastClasses = dataBase.context.Classes.Where(classes => classes.IdGroup == id).ToList();
            foreach (Classes item in pastClasses)
            {
                if (item.ClassDate < DateTime.Now.Date)
                {
                    returnedClasses.Add(item);
                    continue;
                }
                if (item.ClassDate == DateTime.Now.Date)
                {
                    if (item.ClassTime <= DateTime.Now.TimeOfDay)
                    {
                        returnedClasses.Add(item);
                    }
                }
            }
                return returnedClasses;
        }

        public List<Classes> GetClassesListByGroupId(int id)
        {
            return dataBase.context.Classes.Where(classes => classes.IdGroup == id).ToList();
        }

        public Classes GetClassById(int id)
        {
            return dataBase.context.Classes.FirstOrDefault(classes => classes.IdClass == id);
        }

        public bool AddClasses(Classes classes)
        {
            try
            {
                dataBase.context.Classes.Add(classes);
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

        public bool UpdateClasses(Classes classes)
        {
            try
            {
                dataBase.context.Classes.AddOrUpdate(classes);
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

        public bool DeleteClasses(Classes classes)
        {
            try
            {
                Classes classtoDelete = GetClassById(classes.IdClass);
                dataBase.context.Classes.Remove(classtoDelete);
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
