using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignatureApp.Properties;

namespace SignatureApp
{
    class Signature
    {
        //public Dictionary<string, List<string>> UserData { get; set; }

        const String resourcesFolderPath =
            @"F:\Programming\C#\Signature Verification Project\SignatureApp\SignatureApp\Database";

        public List<string> GetSignatureFileNames()
        {
            List<string> fileNames = new List<string>();  

            string[] files = Directory.GetFiles(resourcesFolderPath); // paths of the files
            foreach (var file in files)
            {  
                var signatureFile = Path.GetFileName(file); // returns only the name + extension
                fileNames.Add(signatureFile);
                Trace.WriteLine(signatureFile);
            }

            return fileNames;
        }

        public Dictionary<string, List<string>> Parse()
        {
            Dictionary<string, List<string>> userData = new Dictionary<string, List<string>>();
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
                    stringBuilder.Append('_');
                }

                if (!userData.ContainsKey(parsedName[0]))
                {
                    signatureList.Clear();
                    signatureList.Add(stringBuilder.ToString());
                    userData[parsedName[0]] = signatureList;
                }
                else
                {
                    signatureList.Add(stringBuilder.ToString());
                    userData[parsedName[0]] = signatureList;
                }
            }

            return userData;
        }
    }
}
