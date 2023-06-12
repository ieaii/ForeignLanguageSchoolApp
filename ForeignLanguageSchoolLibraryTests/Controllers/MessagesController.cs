using ForeignLanguageSchoolLibraryTests.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageSchoolApp.Controllers
{
    public class MessagesController : MainController
    {

        public List<Messages> GetMessagesListByTeacherId(int id)
        {
            return dataBase.context.Messages.Where(message => message.UserId == id).ToList();
        }

        public Messages GetMessageById(int id)
        {
            return dataBase.context.Messages.FirstOrDefault(message => message.IdMessage == id);
        }

        public bool DeleteMessage(Messages message)
        {
            Messages messageToDelete = GetMessageById(message.IdMessage);
            dataBase.context.Messages.Remove(messageToDelete);
            try
            {
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
        public bool AddNewMessage(Messages message)
        {
            dataBase.context.Messages.Add(message);
            try
            {
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
