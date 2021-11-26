using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApp
{
    class Evaluator
    {
        readonly Signature signatureAndUserDatabase;
        public string User { get; }
        public List<PointF>[] Signatures { get; set; }

        public int FalseAcceptanceCount {get; set;}
        public int FalseRejectionCount { get; set; }
        public Evaluator(string user)
        {
            User = user;
        }

        public Evaluator(Signature signatureAndUserDatabase)
        {
            this.signatureAndUserDatabase = signatureAndUserDatabase;
        }

        public Evaluator(Signature signatureAndUserDatabase, string user)
        {
            this.signatureAndUserDatabase = signatureAndUserDatabase;
            User = user;
        }

        public void EvaluateRateError()
        {
            var references = signatureAndUserDatabase.GetReferenceSignatures(User);
            Signatures = signatureAndUserDatabase.GetSignatures(User);

            var forgedSignatures = signatureAndUserDatabase.GetForgedSignatures(User);

            foreach (var forged in forgedSignatures)
            {
                FalseAcceptanceCount = 0;
                var verifierForForgedSignatures = new Verifier(forged, references);
                if (verifierForForgedSignatures.IsGenuine())
                {
                    FalseAcceptanceCount++; 
                }
            }

            var genuineSignatures = signatureAndUserDatabase.GetGenuineSignatures(User);

            foreach (var genuine in genuineSignatures)
            {
                FalseRejectionCount = 0;
                var verifierForForgedSignatures = new Verifier(genuine, references);
                if (!verifierForForgedSignatures.IsGenuine())
                {
                    FalseRejectionCount++;
                }
            }
        }

        public double GetFalseRejectionErrorRate()
        {
            return (double)FalseRejectionCount / 10;
        }

        public double GetFalseAcceptanceErrorRate()
        {
            return (double)FalseAcceptanceCount / 10;
        }

        public double GetAverageErrorRate()
        {
            return (double)(GetFalseAcceptanceErrorRate() + GetFalseRejectionErrorRate()) / 2;
        }
    }
}
