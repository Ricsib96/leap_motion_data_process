using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Thesis
{
    class ChartCreator
    {

        public ChartCreator() { }

        public void createTempChart()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook
               .Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 2] = "a";
            xlWorkSheet.Cells[1, 3] = "b";

            Excel.Application xlApp1 = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp1.Workbooks.Open
               (@"E:\temp.csv");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;


            Excel.Range chartRange;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet
   .ChartObjects(Type.Missing);
            Excel.ChartObject myChart =
               (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;
            chartRange = xlWorkSheet.get_Range("A1", "C6");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
            // Export chart as picture file
            chartPage.Export(@"E:\temp_data.bmp", "BMP",
               misValue);
            xlWorkBook.SaveAs("temp.csv",
               Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
               misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive,
               misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            DeallocateObject(xlWorkSheet);
            DeallocateObject(xlWorkBook);
            DeallocateObject(xlApp);
            DeallocateObject(xlApp1);
        }

        private static void DeallocateObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal
                   .ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }

}
