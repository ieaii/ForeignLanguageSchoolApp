using ForeignLanguageSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class GroupsClientsController : MainController
    {
        public List<GroupsClients> GetGroupsClientsByCLientId(int id)
        {
            return dataBase.context.GroupsClients.Where(gc => gc.IdClient == id).ToList();
        }

        public List<GroupsClients> GetGroupsClientsByGroupId(int id)
        {
            return dataBase.context.GroupsClients.Where(gc => gc.IdGroup == id).ToList();
        }

        public bool AddGroupsClients(GroupsClients groupsClients)
        {
            try
            {
                dataBase.context.GroupsClients.Add(groupsClients);
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
