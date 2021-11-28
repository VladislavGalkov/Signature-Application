using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApp
{
    static class Evaluator
    {
        readonly static Signature signatureAndUserDatabase = new Signature();
        //public static string User { get; }
        public static List<PointF>[] Signatures { get; set; }

        public static int FalseAcceptanceCount { get; set; }
        public static int FalseRejectionCount { get; set; }
        
        //public static Evaluator(string user)
        //{
        //    User = user;
        //}

        //public Evaluator(Signature signatureAndUserDatabase)
        //{
        //    this.signatureAndUserDatabase = signatureAndUserDatabase;
        //}

        //public Evaluator(Signature signatureAndUserDatabase, string user)
        //{
        //    this.signatureAndUserDatabase = signatureAndUserDatabase;
        //    User = user;
        //}

        public static void EvaluateRateError(string user)
        {
            var references = signatureAndUserDatabase.GetSignatures(user, 'R', true);
            Signatures = signatureAndUserDatabase.GetSignatures(user, ' ', true);

            var forgedSignatures = signatureAndUserDatabase.GetSignatures(user, 'F', true);
            var genuineSignatures = signatureAndUserDatabase.GetSignatures(user, 'G', true);

            foreach (var forged in forgedSignatures)
            {
                FalseAcceptanceCount = 0;

                var verifierForForgedSignatures = new Verifier(forged, references);
              
                if (verifierForForgedSignatures.IsGenuine())
                {
                    Trace.WriteLine($"This forged signature is genuine ");
                    FalseAcceptanceCount++;
                }
                else
                {
                    Trace.WriteLine($"This forged signature is truly forged ");
                }
            }


            foreach (var genuine in genuineSignatures)
            {
                FalseRejectionCount = 0;
                var verifierForForgedSignatures = new Verifier(genuine, references);
                if (!verifierForForgedSignatures.IsGenuine())
                {
                    Trace.WriteLine($"This genuine signature is forged ");
                    FalseRejectionCount++;
                }
                else
                {
                    Trace.WriteLine($"This genuine signature is truly genuine ");
                }
            }
        }

        public static double GetFalseRejectionErrorRate()
        {
            return (double)FalseRejectionCount / 10;
        }

        public static double GetFalseAcceptanceErrorRate()
        {
            return (double)FalseAcceptanceCount / 10;
        }

        public static double GetAverageErrorRate()
        {
            return (double)(GetFalseAcceptanceErrorRate() + GetFalseRejectionErrorRate()) / 2;
        }


        public static Dictionary<string, ErrorRates> GetUserRates()
        {
            var result = new Dictionary<string, ErrorRates>();
            List<string> users = signatureAndUserDatabase.UserData.Keys.ToList();
            
            foreach (var user in users)
            {
                Trace.WriteLine(user);
                var rates = new List<ErrorRates>();
                EvaluateRateError(user);

                var FRR = GetFalseRejectionErrorRate();
                var FAR = GetFalseAcceptanceErrorRate();
                var AVGR = GetAverageErrorRate();

                Trace.WriteLine($"FRR = {FRR}, FAR = {FAR}");
                Trace.WriteLine(AVGR);
                Trace.WriteLine(user + " DONE!");
                Trace.WriteLine("---------------");

                result[user] = new ErrorRates() { FalseRejectionErrorRate = FRR, FalseAcceptanceErrorRate = FAR, AverageErrorRate = AVGR };
            }
            return result;
        }
    }

}
