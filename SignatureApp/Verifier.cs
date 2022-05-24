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

        List<PointF>[] References { get; }

        public double average { get; set; }
        public double refAverage { get; set; }


        public Verifier(List<PointF> selectedSignature, List<PointF>[] referenceSignatures)
        {
            SelectedSignature = selectedSignature;
            References = referenceSignatures;
           // References = PreprocessReferenceSignatures();

            ReferenceMatrix = GetReferenceMatrix();
        }

        private double[,] GetReferenceMatrix()
        {
            var result = new double[References.Length, References.Length];

            for (int i = 0; i < References.Length; i++)
                for (int j = 0; i > j; j++) // i > j since we do not want to calculate the same DTW twice 
                {
                    var dtw = new DTW(References[i], References[j]);
                    result[i, j] = dtw.DTWAlgorithm(dtw.DistanceMatrixX);
                }
                               
            return result; 
        }

        public double GetReferenceAverage()
        {
            double sum = 0;
            var count = 0; 
            foreach (var value in ReferenceMatrix)
            {
                if (value != 0)
                {
                    sum += value;
                    count++;
                }
                
            }

            var result = sum / count;
            refAverage = result;
            return result;
        }

        private List<double> GetDTWBetweenSelectedAndReference(List<PointF> selectedSignature)
        {
            var result = new List<double>();

            foreach (var sign in References)
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
            {
                sum += value;
            }

            var result = sum / dtwBetweenSelectedAndReference.Count;
            average = result;

            return result;
        }

        public bool IsGenuine()
        {
            var referenceAverage = GetReferenceAverage();
            var average = GetAverage();

            return average <= referenceAverage;
        }

        private List<PointF>[] PreprocessReferenceSignatures()
        {
            var preprocessor = new Preprocessor();
            var normalizer = new Normalizator();

            var result = new List<PointF>[10];
            for (int i = 0; i < References.Length; i++)
            {
                var signature = References[i];
                signature = preprocessor.ScaleAndShift(signature);
                signature = normalizer.Normalize(signature);
                result[i] = signature;
            }

            return result;
        }
    }
}
