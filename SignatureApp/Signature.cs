using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignatureApp.Properties;

namespace SignatureApp
{
    class Signature
    {
        public Dictionary<string, List<string>> UserData { get; set; }

        private readonly string databaseFolderPath = @"F:\Programming\C#\Signature Verification Project\SignatureApp\SignatureApp\Database";
        //private string databaseFolderPath;
        //private String DatabaseFolderPath
        //{
        //    get => databaseFolderPath;
        //    set
        //    {
        //        string exePath = Environment.CurrentDirectory;
        //        string exeDir = System.IO.Path.GetDirectoryName(exePath);
        //        DirectoryInfo binDir = System.IO.Directory.GetParent(exeDir);

        //        value = Path.Combine(binDir.ToString(), @"Database").ToString();
        //        databaseFolderPath = value;
        //    }
        //}


        public List<string> GetSignatureFileNames()
        {
            List<string> fileNames = new List<string>();  

            string[] files = Directory.GetFiles(databaseFolderPath); // paths of the files
            foreach (var file in files)
            {  
                var signatureFile = Path.GetFileName(file); // returns only the name + extension
                fileNames.Add(signatureFile);
                //Trace.WriteLine(signatureFile);
            }

            return fileNames;
        }

        public Dictionary<string, List<string>> Parse()
        {
            UserData = new Dictionary<string, List<string>>();
           // Dictionary<string, List<string>> userData = new Dictionary<string, List<string>>();
            List<string> signatureList = new List<string>();
            List<string> fileNames = GetSignatureFileNames();
            StringBuilder stringBuilder = new StringBuilder();
            string[] parsedName;
            foreach (var name in fileNames)
            {
                stringBuilder.Clear();
                parsedName = name.Split('_'); //A01 F1 1.trj
                parsedName[2] = parsedName[2].Substring(0, 2); //get rid of extension
                for (int i = 1; i <= 2; i++)
                {
                    stringBuilder.Append(parsedName[i]);
                    if (i != 2)
                        stringBuilder.Append('_'); // no underscore at the end 
                }

                if (!UserData.ContainsKey(parsedName[0])) // if it's a new user, create new signature list for it
                {

                    signatureList = new List<string>(); // make it empty
                    signatureList.Add(stringBuilder.ToString());
                    UserData[parsedName[0]] = signatureList;
                }

                else
                {
                    signatureList.Add(stringBuilder.ToString());
                    UserData[parsedName[0]] = signatureList;
                }
            }

            return UserData;
        }

        public static void Draw(string fileName)
        {
            Pen pen = new Pen(Color.Black);

            string[] lines = System.IO.File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                while (line[0].CompareTo("-1") != 0)
                {
                    Point p = new Point(line[0], line[1]);

                }
            }
        }
    }
}
