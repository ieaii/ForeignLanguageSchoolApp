using ForeignLanguageSchoolApp.Controllers;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ForeignLanguageSchoolApp.Utils
{
    public class ExcelOtchet
    {
        ClientsController clientsController = new ClientsController();
        UsersController usersController = new UsersController();
        public void FormOtchet()
        {
            CloseApplication();
            App.excelApplication = new Excel.Application();
            Excel.Workbook workbook = App.excelApplication.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Cells[1][1] = "Сводный отчет";
            worksheet.Cells[2][1] = DateTime.Now.Date;
            worksheet.Cells[1][2] = "Количество Клиентов ";
            worksheet.Cells[2][2] = clientsController.GetClientsList().Count;
            worksheet.Cells[1][3] = "Количество работников ";
            worksheet.Cells[2][3] = usersController.GetUsersList().Count;
            worksheet.Name = "Otchet"; 
            App.excelApplication.Visible = true;
        }

        public void CloseApplication()
        {
            try
            {
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
