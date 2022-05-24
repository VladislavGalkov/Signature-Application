using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApp
{
    class Preprocessor
    {
        public List<PointF> Scale(List<PointF> signature)
        {
            var scaledSignature = new List<PointF>();
            if (signature.Count != 0)
            {
                var minX = signature.Min<PointF>(x => x.X);
                var maxX = signature.Max<PointF>(x => x.X);

                // scaling by replacing the X values
                foreach (var point in signature)
                {
                    scaledSignature.Add(new PointF((point.X - minX) / (maxX - minX), point.Y));
                }
            }
            return scaledSignature;
        }

        public List<PointF> Shift(List<PointF> signature)
        {
            var shiftedSignature = new List<PointF>();
            if (signature.Count != 0)
            {
                float minY = signature.Min<PointF>(y => y.Y);
           

                foreach (var point in signature)
                {
                    shiftedSignature.Add(new PointF(point.X, point.Y - minY));
                }    
            }
            return shiftedSignature;
        }

        public List<PointF> ScaleAndShift(List<PointF> signature)
        {
            signature = Scale(signature);
            signature = Shift(signature);

            return signature;
        }

        public List<PointF> Preprocess(List<PointF> signature)
        {
            var normalizer = new Normalizator();
            signature = ScaleAndShift(signature);
            signature = normalizer.Normalize(signature);

            return signature;
        }
    }
}
