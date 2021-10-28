using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SignatureApp.Tests
{
    [TestClass]
    public class DTWTests
    {
        [TestMethod]
        public void GetSignalValuesTest()
        {
            var lSign = new List<Point>();
            lSign.Add(new Point(0, 0));
            lSign.Add(new Point(0, 1));
            lSign.Add(new Point(1, 1));

            var rSign = new List<Point>();
            rSign.Add(new Point(0, 0));
            rSign.Add(new Point(0, 1));
            rSign.Add(new Point(1, 1));
            
            DTW dtw = new DTW(lSign, rSign);

            var expected = new List<double>();

            dtw.DTWAlgorithm();


        }
    }
}
