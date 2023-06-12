using ForeignLanguageSchoolLibraryTests.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class ClassesClientsController : MainController
    {
        public ClassesClients GetClassClientByClassAndClientId(int classId, int clientId)
        {
            return dataBase.context.ClassesClients.FirstOrDefault(cls => cls.ClassId == classId && cls.ClientId == clientId);
        }
        public ClassesClients GetClassClientById(int id)
        {
            return dataBase.context.ClassesClients.FirstOrDefault(cls => cls.IdClassClient == id);
        }

        public List<ClassesClients> GetClassClientByClassId(int id)
        {
            return dataBase.context.ClassesClients.Where(cls => cls.ClassId == id).ToList();
        }

        public bool AddClassesClients(ClassesClients classesClients)
        {
            try
            {
                dataBase.context.ClassesClients.Add(classesClients);
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

        public bool DeleteClassesClients(ClassesClients classesClients)
        {
            try
            {
                ClassesClients classtoDelete = GetClassClientById(classesClients.IdClassClient);
                dataBase.context.ClassesClients.Remove(classtoDelete);
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
