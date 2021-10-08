using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SignatureApp.Properties;

namespace SignatureApp
{
    class Signature
    {
        public Dictionary<string, List<string>> UserData { get; set; } // key = user, List = list of signatures for every user

        private string databaseFolderPath;

        public string DatabaseFolderPath => databaseFolderPath;

        private void getDatabaseFolderPath()
        {
            string exePath = Environment.CurrentDirectory; //folder where .exe is located
            string exeDir = System.IO.Path.GetDirectoryName(exePath); //folder where bin is located
            DirectoryInfo binDir = System.IO.Directory.GetParent(exeDir); //get the parent of the folder where bin-folder is located
            this.databaseFolderPath = Path.Combine(binDir.ToString(), @"Database").ToString(); 
        }

        #region NoYieldReturn




        //public List<string> GetSignatureFileNames()
        //{
        //    List<string> fileNames = new List<string>();
        //    getDatabaseFolderPath();


        //    string[] files = Directory.GetFiles(DatabaseFolderPath); // paths of the files
        //    foreach (var file in files)
        //    {  
        //        var signatureFile = Path.GetFileName(file); // returns only the name + extension
        //        fileNames.Add(signatureFile);
        //        //Trace.WriteLine(signatureFile);
        //    }

        //    return fileNames;
        //}

        //public Dictionary<string, List<string>> Parse()
        //{
        //    UserData = new Dictionary<string, List<string>>();
        //   // Dictionary<string, List<string>> userData = new Dictionary<string, List<string>>();
        //    List<string> signatureList = new List<string>();
        //    List<string> fileNames = GetSignatureFileNames();
        //    StringBuilder stringBuilder = new StringBuilder();
        //    string[] parsedName;
        //    foreach (var name in fileNames)
        //    {
        //        stringBuilder.Clear();
        //        parsedName = name.Split('_'); //A01 F1 1.trj
        //        parsedName[2] = parsedName[2].Substring(0, 2); //get rid of extension
        //        for (int i = 1; i <= 2; i++)
        //        {
        //            stringBuilder.Append(parsedName[i]);
        //            if (i != 2)
        //                stringBuilder.Append('_'); // no underscore at the end 
        //        }

        //        if (!UserData.ContainsKey(parsedName[0])) // if it's a new user, create new signature list for it
        //        {
        //            signatureList = new List<string>(); // make it empty
        //            signatureList.Add(stringBuilder.ToString());
        //            UserData[parsedName[0]] = signatureList;
        //        }

        //        else
        //        {
        //            signatureList.Add(stringBuilder.ToString());
        //            UserData[parsedName[0]] = signatureList;
        //        }
        //    }

        //    return UserData;
        //}

        #endregion

        public IEnumerable<string> GetSignatureFileNames()
        {
            getDatabaseFolderPath();

            string[] files = Directory.GetFiles(DatabaseFolderPath); // paths of the files
            foreach (var file in files)
            {
                var signatureFile = Path.GetFileName(file); // returns only the name + extension
                yield return signatureFile;
                //Trace.WriteLine(signatureFile);
            }
        }

        public Dictionary<string, List<string>> Parse()
        {
            UserData = new Dictionary<string, List<string>>();

            List<string> signatureList = new List<string>();

            var fileNames = GetSignatureFileNames();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var name in fileNames)
            {
                stringBuilder.Clear();
                var parsedName = name.Split('_'); // A01 F1 1.trj

                if (parsedName[2].IndexOf('.') == 2) //for example, 10.trj
                    parsedName[2] = parsedName[2].Substring(0, 2); //get rid of extension -> 10

                else
                {
                    parsedName[2] = parsedName[2].Substring(0, 1); //get rid of extension -> 1
                }

                for (int i = 1; i <= 2; i++)
                {
                    stringBuilder.Append(parsedName[i]); //F1
                    if (i != 2)
                        stringBuilder.Append('_'); // no underscore at the end, or else F1_
                }

                if (!UserData.ContainsKey(parsedName[0])) // if it's a new user, create new signature list for it
                {
                    signatureList = new List<string>(); // make it empty
                    signatureList.Add(stringBuilder.ToString());
                    UserData[parsedName[0]] = signatureList;
                }

                else
                {
                    signatureList.Add(stringBuilder.ToString()); // update current list
                    UserData[parsedName[0]] = signatureList;
                }
            }
            return UserData;
        }
    }
}
