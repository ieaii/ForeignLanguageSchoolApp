using ForeignLanguageSchoolLibraryTests.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class GroupsController : MainController
    {
        public Groups GetGroupById(int id)
        {
            return dataBase.context.Groups.FirstOrDefault(group => group.IdGroup == id);
        }

        public Groups GetGroupByUserId(int id)
        {
            return dataBase.context.Groups.FirstOrDefault(group => group.UserId == id);
        }

        public Groups GetGroupByCourseId(int id)
        {
            return dataBase.context.Groups.FirstOrDefault(group => group.CourseId == id);
        }

        public List<Groups> GetGroupsList()
        {
            return dataBase.context.Groups.ToList();
        }

        public List<string> GetGroupsListString()
        {
            List<string> strings = new List<string>();
            List<Groups> groups = GetGroupsList();
            foreach (Groups item in groups)
            {
                strings.Add(item.GroupName);
            }
            return strings;
        }

        public bool AddGroup(Groups groups)
        {
            try
            {
                dataBase.context.Groups.Add(groups);
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

        public bool UpdateGroup(Groups groups)
        {
            try
            {
                dataBase.context.Groups.AddOrUpdate(groups);
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

        public Groups GetLastAddedGroup()
        {
            return dataBase.context.Groups.ToList().Last();
        }
    }
}
