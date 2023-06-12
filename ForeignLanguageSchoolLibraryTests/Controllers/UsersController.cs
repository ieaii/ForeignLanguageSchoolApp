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
    public class UsersController : MainController
    {

        public Users GetUserByLoginAndPassword(string password, string login)
        {
            return dataBase.context.Users.FirstOrDefault(user => user.UserPassword == password && user.UserLogin == login);
        }

        public Users GetUserByLogin(string login)
        {
            return dataBase.context.Users.FirstOrDefault(user => user.UserLogin == login);
        }

        public List<Users> GetTeachersList()
        {
            return dataBase.context.Users.Where(user => user.UserTypeId == 3).ToList(); 
        }

        public Users GetUserById(int id)
        {
            return dataBase.context.Users.FirstOrDefault(user => user.IdUser == id);
        }

      

        public bool AddUser(Users users)
        {
            try
            {
                dataBase.context.Users.Add(users);
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

        public bool UpdateUser(Users users)
        {
            try
            {
                dataBase.context.Users.AddOrUpdate(users);
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

        public bool DeleteUser(Users users)
        {
            try
            {
                Users userstoDelete = GetUserById(users.IdUser);
                dataBase.context.Users.Remove(userstoDelete);
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

        public Users GetLastAddedUser()
        {
            return dataBase.context.Users.ToList().Last();
        }

        public List<Users> GetUsersList()
        {
            return dataBase.context.Users.ToList();
        }

    }
}
