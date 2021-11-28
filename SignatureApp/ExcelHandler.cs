﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApp
{
    class ExcelHandler
    {
        //public static string FilePath = @"C:\Users\Vladislav\Desktop\ErrorRates(Vladislav Galkov).xlsx";

        public static string FilePath { get; set; }

        private void GetDatabaseFolderPath()
        {
            string exePath = Environment.CurrentDirectory; //folder where .exe is located
            string exeDir = System.IO.Path.GetDirectoryName(exePath); //folder where bin is located
            DirectoryInfo binDir = System.IO.Directory.GetParent(exeDir); //get the parent of the folder where bin-folder is located
            FilePath = Path.Combine(binDir.ToString(), @"Rates\ErrorRates(Vladislav Galkov).xlsx").ToString();
        }

        private static async Task SaveExcelFile(List<ErrorRates> ErrorRates)
        {
            var file = new FileInfo(FilePath);
            DeleteIfExists(file);

            using (var package = new ExcelPackage(FilePath))
            {
                var ws = package.Workbook.Worksheets.Add("ErrorRates");
                var range = ws.Cells["A1"].LoadFromCollection(ErrorRates, true);
                range.AutoFitColumns();

                await package.SaveAsync();
            }
        }

        private static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists)
                file.Delete();
        }

        public static List<ErrorRates> SetUpData()
        {
            var output = new List<ErrorRates>();
            var dict = Evaluator.GetUserRates();
            foreach (var value in dict.Values)
            {
                output.Add(value);
            };

            return output;
        }

        public static async Task SetUpExcel(List<ErrorRates> errorRates)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            await SaveExcelFile(errorRates);
        }
    }
}
