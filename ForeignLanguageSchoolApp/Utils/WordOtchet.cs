using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolApp.Models;
using Microsoft.Office.Interop.Word;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Word = Microsoft.Office.Interop.Word;

namespace ForeignLanguageSchoolApp.Utils
{
    public class WordOtchet
    {
        ClassesController classesController = new ClassesController();
        public void HomeworkWordAdd(Classes classes, string filename)
        {
            if (classes.HomeworkLink != null)
            {
                MessageBox.Show("Домашнее задание уже добавлено", "Уже добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string homework = $"{classes.IdClass}.docx";
            classes.HomeworkLink = homework;
            classesController.UpdateClasses(classes);
            File.Copy(filename, $"{Directory.GetCurrentDirectory()}\\Documents\\{homework}");
            MessageBox.Show("Домашнее Задание успешно добавлено", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void OpenHomework(Classes classes)
        {
            if (classes.HomeworkLink == null)
            {
                MessageBox.Show("Домашнего задания нет", "Дз нет", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CloseApplication();
            
            App.wordApplication = new Word.Application();
            Word.Document document = App.wordApplication.Documents.Open($"{Directory.GetCurrentDirectory()}\\Documents\\{classes.HomeworkLink}");
            App.wordApplication.Visible = true;
        }

        public void OpenDocument()
        {
            
            CloseApplication();

            App.wordApplication = new Word.Application();
            Word.Document document = App.wordApplication.Documents.Open($"{Directory.GetCurrentDirectory()}\\Documents\\Document.docx");
            App.wordApplication.Visible = true;
        }

        public void StudentsOtchet(Groups groups)
        {
            GroupsClientsController groupsClientsController = new GroupsClientsController();
            ClientsController clientsController = new ClientsController();
            CloseApplication();
            List<GroupsClients> groupsClients = groupsClientsController.GetGroupsClientsByGroupId(groups.IdGroup);
            List<Clients> clients = new List<Clients>(); 
            foreach (GroupsClients item in groupsClients)
            {
                clients.Add(clientsController.GetClientById(item.IdClient));
            }
            App.wordApplication = new Word.Application();
            Word.Document document = App.wordApplication.Documents.Open($"{Directory.GetCurrentDirectory()}\\Documents\\Students.docx");
            document.Bookmarks["group"].Range.Text = groups.GroupName;
            Word.Table table = document.Tables.Add(document.Bookmarks["table"].Range, clients.Count + 1, 2);
            table.Cell(1, 1).Range.Text = "№";
            table.Cell(1, 2).Range.Text = "ФИО";
            int i = 2;
            foreach (Clients client in clients)
            {
                table.Cell(i, 1).Range.Text = $"{i - 1}";
                table.Cell(i, 2).Range.Text = client.ClientNameAndSurname;          
                i++;
            }
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            App.wordApplication.Visible = true;
        }
        public void CloseApplication()
        {
            try
            {
                if (App.wordApplication != null)
                {
                    App.wordApplication.Quit();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {

            }
        }
    }
}
