using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApp
{
    class Normalization
    {
        public List<PointF> Normalize(List<PointF> signature)
        {
            var mean = getMeanValue(signature);
            var SD = getStandardDeviation(signature);

            var result = new List<PointF>();

            foreach (var point in signature)
            {
                result.Add(new PointF((point.X - mean) / SD, point.Y));
            }
        
            return result;
        }

        private float getMeanValue(List<PointF> signature)
        {
            float sum = 0; 

            foreach (var p in signature)
            {
                sum += p.X;
            }

            return sum / signature.Count;
        }

        private float getStandardDeviation(List<PointF> signature)
        {
            var mean = getMeanValue(signature);
            float numerator = 0; 
            var N = signature.Count;

            foreach (var point in signature)
            {
                numerator += (point.X - mean) * (point.X - mean);
            }

            return (float)Math.Sqrt(numerator / N);
        }
    }
}
