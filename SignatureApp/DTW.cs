using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApp
{
    public enum Operations
    {
        MATCH,
        INSERTION,
        DELETION
    } 

    public class DTW
    {
        public List<Point> LSign { get; }
        public List<Point> RSign { get; }
        public double [,] CostMatrix { get; set; }
        public double [,] DistanceMatrix { get; set; }
        public Operations[,] BackTraceMatrix { get; set; }

        public DTW(List<Point> list1, List<Point> list2)
        {
            LSign = list1;
            RSign = list2;
            CostMatrix = InitCostMatrix();
            BackTraceMatrix = new Operations[LSign.Count, RSign.Count];
            DistanceMatrix = GetDistanceMatrix();
        }

        public double[,] GetDistanceMatrix()
        {
            var result = new double[LSign.Count, RSign.Count];

            for (int i = 0; i < LSign.Count - 1; i++)
            {
                for (int j = 0; j < RSign.Count - 1; j++)
                {
                    result[i, j] = GetDistanceBetweenTwoPoints(LSign[i], RSign[j]);
                }
            }
            return result;
        }

        public double DTWAlgorithm()
        {
            //var costMatrix = InitCostMatrix();
            // var backTraceMatrix = new double[LSign.Count, RSign.Count]; //new matrix filled out with 0
            // List<double> operations = new List<double>();

           for (int i = 0; i < LSign.Count; i++)
                for (int j = 0; j < RSign.Count; j++)
                {
                    double match = CostMatrix[i, j];
                    double insertion = CostMatrix[i + 1, j];
                    double deletion = CostMatrix[i, j + 1];

                    //operations.Clear();
                    //operations.Add(Operations.MATCH);
                    //operations.Add(Operations.INSERTION);
                    //operations.Add(Operations.DELETION);
                    var min = GetMinimum(match, insertion, deletion);

                    CostMatrix[i + 1,  j + 1] = DistanceMatrix[i, j] + min;

                    if (min == match)
                    {
                        BackTraceMatrix[i, j] = Operations.MATCH;
                    }

                    else if (min == insertion)
                    {
                        BackTraceMatrix[i, j] = Operations.INSERTION;
                    }

                    else
                    {
                        BackTraceMatrix[i, j] = Operations.DELETION;
                    }
                }

            //return GetAlignment(BackTraceMatrix);

            return CostMatrix[LSign.Count, RSign.Count]; //return top right corner element
        }

        private double GetAlignment(Operations[,] backTraceMatrix)
        {
            backTraceMatrix = BackTraceMatrix;

            //trace back from bottom right

            int i = LSign.Count - 1;
            int j = RSign.Count - 1;

            var result = CostMatrix[i, j];

            while (i > 0 || j > 0)
            {
                var operation = BackTraceMatrix[i, j];
                switch (operation)
                {
                    case Operations.MATCH:
                        {
                            i--; j--;
                        }
                        break;

                    case Operations.INSERTION:
                        {
                            i--;
                        }
                        break;

                    case Operations.DELETION:
                        {
                            j--;
                        }
                        break;
                }

                result += CostMatrix[i, j];
                Trace.WriteLine("Result: " + result);
            }
            return result;
        }

        private double[,] InitCostMatrix()
        {
            var result = new double[LSign.Count + 1, RSign.Count + 1];
            result[0, 0] = 0;
            for (int i = 1; i <= LSign.Count; i++)
                result[i, 0] = Double.PositiveInfinity;
            for (int j = 1; j <= RSign.Count; j++)
                result[0, j] = Double.PositiveInfinity;

            return result;
        }

        private Func<double, double, double, double> GetMinimum = (a, b, c) => Math.Min(a, Math.Min(b, c));
        private Func<Point, Point, double> GetDistanceBetweenTwoPoints = (x, y) => Math.Sqrt(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2));
    }
}
