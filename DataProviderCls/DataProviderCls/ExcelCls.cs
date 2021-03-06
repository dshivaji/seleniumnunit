﻿/*######################################################################################################
 Author: shivaji Doddapaneni
 Description:This class is used to get data from excel spread shetet
########################################################################################################*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;


namespace DataProviderCls
{    
    public class ExcelCls
    {



        public Dictionary<object,object> openExcel(String path)
        {

            

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheetScenario = null;
            Excel.Worksheet xlWorkSheetTestData= null;
            Excel.Worksheet xlWorkSheetTestRun = null;
            Excel.Range range;

            Excel.Range rangeScenarios;
            //ArrayList list = new ArrayList();
            
            Dictionary<object, object> dictionary =   new Dictionary<object, object>();
            string param = "";

            string str;
            int rCnt = 0;
            int cCnt = 0;

            
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(@path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

             
            
               //Microsoft.Office.Interop.Excel
            try
             {
                 
                foreach (Excel.Worksheet xlworksheet in xlWorkBook.Worksheets)
                {
                    if (xlworksheet.Name == "FuntionalScenario")
                    {
                        xlWorkSheetScenario = xlworksheet;
                    }
                    else if (xlworksheet.Name == "TestData")
                    {
                        xlWorkSheetTestData = xlworksheet;
                    }
                    else if (xlworksheet.Name == "TestRun")
                    {
                        xlWorkSheetTestRun = xlworksheet;
                    }

                }


                int row = xlWorkSheetTestData.Cells.Find("Test_1").Row;
                int col = xlWorkSheetTestData.Cells.Find("Test_1").Column;

                int colScenario = xlWorkSheetScenario.Cells.Find("Function1").Column;

                int colTestData = xlWorkSheetTestRun.Cells.Find("TestScripts").Column;
                int colTestScript = xlWorkSheetTestRun.Cells.Find("TestData").Column;

                range = xlWorkSheetTestRun.UsedRange;
                rangeScenarios = xlWorkSheetScenario.UsedRange;


                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    // int Tempval = ((range.Cells[rCnt, colTestData] as Excel.Range).Value2);

                    row = xlWorkSheetTestData.Cells.Find(System.Convert.ToString((range.Cells[rCnt, colTestScript] as Excel.Range).Value2)).Row;
                    col = xlWorkSheetTestData.Cells.Find(System.Convert.ToString((range.Cells[rCnt, colTestScript] as Excel.Range).Value2)).Column;


                    str = System.Convert.ToString((range.Cells[rCnt, colTestData] as Excel.Range).Value2);
                    int Rowscenario = xlWorkSheetScenario.Cells.Find(str).Row;
                    for (cCnt = colScenario; cCnt <= rangeScenarios.Columns.Count; cCnt += 2)
                    {

                        string fun = System.Convert.ToString(xlWorkSheetScenario.Cells[Rowscenario, cCnt].Value2);

                        if (str != null && fun != null)
                        {
                            param = "";
                            string convert = System.Convert.ToString(xlWorkSheetScenario.Cells[Rowscenario, cCnt + 1].Value2);
                            if (convert != null && convert != "")
                            {
                                object[] strout = convert.Split(',');
                                foreach (object s in strout)
                                {
                                    col = xlWorkSheetTestData.Cells.Find(Convert.ToString(s)).Column;
                                    param = param + "," + Convert.ToString(s).Replace(Convert.ToString(s), Convert.ToString(xlWorkSheetTestData.Cells[row, col].Value2));


                                }

                                dictionary.Add(rCnt + ":" + fun, param.Substring(1));
                            }
                            else
                            {
                                dictionary.Add(rCnt + ":" + fun, null);
                            }


                            
                        }

                    }
                    //if (flag) break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(""+e.Message);
            }
            finally
            {
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                releaseObject(xlWorkSheetScenario);
                releaseObject(xlWorkSheetTestData);
                releaseObject(xlWorkSheetTestRun);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
               
            }
            
            return dictionary;
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
    
}
