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
        public static List<PointF>[] Signatures { get; set; }

        public static int FalseAcceptanceCount { get; set; }
        public static int FalseRejectionCount { get; set; }

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

        public static double GetFalseRejectionErrorRate(string user)
        {
            return (double)FalseRejectionCount / signatureAndUserDatabase.GetSignatures(user, 'F', true).Count();
        }

        public static double GetFalseAcceptanceErrorRate(string user)
        {
            return (double)FalseAcceptanceCount / signatureAndUserDatabase.GetSignatures(user, 'G', true).Count(); ;
        }

        public static double GetAverageErrorRate(string user)
        {
            return (double)(GetFalseAcceptanceErrorRate(user) + GetFalseRejectionErrorRate(user)) / 2;
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

                var FRR = GetFalseRejectionErrorRate(user);
                var FAR = GetFalseAcceptanceErrorRate(user);
                var AVGR = GetAverageErrorRate(user);

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
