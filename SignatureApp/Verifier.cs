using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApp
{
    class Verifier
    {
        public List<PointF> SelectedSignature { get; }
        private double[,] ReferenceMatrix { get; }

        List<PointF>[] FirstTenSignatures { get; }

        public Verifier(List<PointF> selectedSignature, List<PointF>[] firstTenSignatures)
        {
            SelectedSignature = selectedSignature;
            FirstTenSignatures = firstTenSignatures;
            ReferenceMatrix = GetReferenceMatrix();
        }

        private double[,] GetReferenceMatrix()
        {
            var result = new double[FirstTenSignatures.Length, FirstTenSignatures.Length];

            for (int i = 0; i < FirstTenSignatures.Length; i++)
                for (int j = 0; j < FirstTenSignatures.Length; j++)
                {
                    var dtw = new DTW(FirstTenSignatures[i], FirstTenSignatures[j]);
                    result[i, j] = dtw.DTWAlgorithm(dtw.DistanceMatrixX);
                }
                               
            return result; 
        }

        private double GetReferenceAverage()
        {
            double sum = 0;
            foreach (var value in ReferenceMatrix)
                sum += value; 
            
            return sum / ReferenceMatrix.Length;
        }

        private List<double> GetDTWBetweenSelectedAndReference(List<PointF> selectedSignature)
        {
            var result = new List<double>();

            foreach (var sign in FirstTenSignatures)
            {
                var dtw = new DTW(selectedSignature, sign);
                result.Add(dtw.DTWAlgorithm(dtw.DistanceMatrixX));
            }

            return result;
        }

        private double GetAverage()
        {
            var dtwBetweenSelectedAndReference = GetDTWBetweenSelectedAndReference(SelectedSignature);

            double sum = 0;

            foreach (var value in dtwBetweenSelectedAndReference)
                sum += value;

            return sum / dtwBetweenSelectedAndReference.Count;
        }

        public bool IsGenuine()
        {
            var referenceAverage = GetReferenceAverage();
            var average = GetAverage();

            return average <= referenceAverage;
        }
    }
}
