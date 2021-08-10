
using AngleSharp.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npoi.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TSDHybridFramework.Core.DataMapper;
using TSDHybridFramework.Core.Utils;

namespace MAW.Core.Utils
{
    class Excel
    {
        private string excelFilePath { get; set; }
        private Mapper excel;


        public Excel(String fileName) {
            
            var projectPath = Helper.GetProjectBaseDirectoryPath();
            var excelFilePath = projectPath + String.Format("TestData\\{0}.xlsx", fileName); 
            excel = new Mapper(excelFilePath);
        }

        public Mapper Reader() {
            return excel;
        }

        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Dictionary<string, string>> ReadSheet(String sheetName) {

            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();


            List<RowInfo<dynamic>> list
                = this.Reader().Take<dynamic>(sheetName).ToList();

            NPOI.SS.UserModel.ISheet sheet
                = GetSheet(sheetName);

            List<string> headerValues = new List<string>(); 
            //Header Row
            NPOI.SS.UserModel.IRow row
                = sheet.GetRow(0);

            int totalCells = row.LastCellNum;
            int lastRow = sheet.LastRowNum;

            for (int i = 0; i < totalCells; i++) {
                headerValues.Add(row.GetCell(i).StringCellValue);
            }

            

            for (int r = 1; r < lastRow; r++) {
                Dictionary<string, string> rowKeyValuePairs = new Dictionary<string, string>();

                for (int cell = 0; cell < totalCells; cell++) {
                    rowKeyValuePairs.Add(headerValues[cell].ToUpper().Trim(),
                        sheet.GetRow(r).GetCell(cell).StringCellValue
                        );
                }

                rows.Add(rowKeyValuePairs);
            }

            return rows;   
        }

        public NPOI.SS.UserModel.ISheet GetSheet(string sheetName)
        {

            if (isExistSheet(sheetName))
            {
                return this.Reader().Workbook.GetSheet(sheetName);
            }
            else {
                return null;
           }


        }
        private bool isExistSheet(string sheetName)
        {
            NPOI.SS.UserModel.ISheet sheet = this.Reader().Workbook.GetSheet(sheetName);
            if (sheet != null)
            {
                sheet.ForceFormulaRecalculation = true;
                return true;
            }
            else
                return false;
        }
       
    }
}
