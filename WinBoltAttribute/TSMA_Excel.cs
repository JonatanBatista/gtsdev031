using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinBoltAttribute
{
    public class TSMA_Excel
    {
        public class ExcelLine
        {
            public string descriptionERP { get; set; }
            public string codeERP { get; set; }
            public string mark { get; set; }
            public string description { get; set; }
        }

        public List<ExcelLine> ExcelLines { get; set; }

        public TSMA_Excel(string SheetName, ProgressBar pgrBar)
        {
            readExcel(SheetName, pgrBar);
        }

        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;

        private void readExcel(string sheetName, ProgressBar pgrBar)
        {
            this.ExcelLines = new List<ExcelLine>();
            pgrBar.Visible = true;
            try
            {
                xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                xlWorkBook = xlApp.ActiveWorkbook;

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[sheetName];

            }
            catch
            {
                string appendText = string.Format("Não foi possível localizar a aba {0}", sheetName);
            }

            try
            {
                //var columns = new Dictionary<string, int>();
                var cCount = xlWorkSheet.UsedRange.Columns.Count;

                //for (int c = 1; c <= cCount; c++)
                //{
                //    if (xlWorkSheet.Cells[2, c].Value != null)
                //        if (xlWorkSheet.Cells[2, c].Value.ToString() != "")
                //        {
                //            var cName = xlWorkSheet.Cells[2, c].Value.ToString().Trim();
                //            columns.Add(cName, c);
                //        }
                //}

                var rCount = xlWorkSheet.UsedRange.Rows.Count;

                pgrBar.Maximum = rCount;
                for (int r = 2; r <= rCount; r++)
                {
                    //if (xlWorkSheet.Cells[r, columns["ID ATC"]].Value != null)
                    if (xlWorkSheet.Cells[r, 1].Value != null)
                    {
                        var line = new ExcelLine
                        {
                            descriptionERP = Convert.ToString(xlWorkSheet.Cells[r, 1].Value),
                            codeERP = Convert.ToString(xlWorkSheet.Cells[r, 2].Value),
                            mark = Convert.ToString(xlWorkSheet.Cells[r, 3].Value),
                            description = Convert.ToString(xlWorkSheet.Cells[r, 6].Value)
                        };

                        this.ExcelLines.Add(line);
                        pgrBar.PerformStep();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler o Excel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pgrBar.Visible = false;
                logger.WriteLog("Erro ao ler o Excel.");
            }


            pgrBar.Visible = false;
        }
    }
}
