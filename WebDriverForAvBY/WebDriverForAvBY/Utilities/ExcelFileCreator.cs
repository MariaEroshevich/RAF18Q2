using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebDriverForAvBY.Utilities
{
    public class ExcelFileCreator
    {
        private List<InterestedCar> interestedCar;

        public ExcelFileCreator(List<InterestedCar> interestedCar)
        {
            this.interestedCar = interestedCar;
        }

        public void CreateExcelFile()
        {
            int count = 1;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, "A"] = "MarkAndModel";
            xlWorkSheet.Cells[1, "B"] = "Year";
            xlWorkSheet.Cells[1, "C"] = "Price";
            xlWorkSheet.Cells[1, "D"] = "City";
            xlWorkSheet.Cells[1, "E"] = "Description";
            xlWorkSheet.Cells[1, "F"] = "OwnerDescription";
            xlWorkSheet.Cells[1, "G"] = "Reference";
            
            foreach (InterestedCar car in interestedCar)
            {
                count++;
                xlWorkSheet.Cells[count, "A"] = car.MarkAndModel;
                xlWorkSheet.Cells[count, "B"] = car.Year;
                xlWorkSheet.Cells[count, "C"] = car.Price;
                xlWorkSheet.Cells[count, "D"] = car.City;
                xlWorkSheet.Cells[count, "E"] = car.Description;
                xlWorkSheet.Cells[count, "F"] = car.OwnerDiscription;
                xlWorkSheet.Cells[count, "G"] = car.Reference;
            }
            xlWorkBook.SaveAs(string.Format(@"{0}\Cars.xlsx", Environment.CurrentDirectory));
            xlWorkBook.Close(true);
            xlApp.Quit();
        }
    }
}
