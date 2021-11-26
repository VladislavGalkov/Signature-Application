using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using OfficeOpenXml;

namespace SignatureApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(@"C:\Users\Vladislav\Desktop\ErrorRates.xlsx");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //  Application.Run(new Form1());

            var database = new Signature();
            var dict = database.Parse();
            List<string> users = database.UserData.Keys.ToList();
            var output = new List<ErrorRates>();
            foreach (var user in users)
            {
                Trace.WriteLine(user);
                var evaluator = new Evaluator(database, user);
                evaluator.EvaluateRateError();
                var FRR = evaluator.GetFalseRejectionErrorRate();
                var FAR = evaluator.GetFalseAcceptanceErrorRate();
                var AVGR = evaluator.GetAverageErrorRate();

                output.Add(new ErrorRates(){ FalseRejectionErrorRate = FRR, FalseAcceptanceErrorRate = FAR, AverageErrorRate =  AVGR });
                Trace.WriteLine($"FRR = {FRR}, FAR = {FAR}");
                Trace.WriteLine(AVGR);
                Trace.WriteLine(user + " DONE!");
                Trace.WriteLine("---------------");
            }

            ExcelHandler.SaveExcelFile(output);
        }
    }
}
