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
        public List<Point> Path { get; set; }

        public DTW(List<Point> list1, List<Point> list2)
        {
            LSign = list1;
            RSign = list2;
            CostMatrix = InitCostMatrix();
            BackTraceMatrix = new Operations[LSign.Count, RSign.Count];
            DistanceMatrix = GetDistanceMatrix();
        }

        private List<double> GetSignalValues(List<Point> sign)
        {
            var result = new List<double>();

            foreach (var point in sign)
            {
                var distance = GetDistanceBetweenTwoPoints(sign[0], point);
                result.Add(distance);
            }

            return result;
        }

        public double[,] GetDistanceMatrix()
        {
            var leftSignValues = GetSignalValues(LSign);

            var rightSignValues = GetSignalValues(RSign);

            var result = new double[LSign.Count, RSign.Count];

            #region OldImplementation
            //for (int i = 0; i < LSign.Count - 1; i++)
            //{
            //    for (int j = 0; j < RSign.Count - 1; j++)
            //    {
            //        result[i, j] = GetDistanceBetweenTwoPoints(LSign[i], RSign[j]);
            //    }
            //}
            #endregion

            for (int i = 0; i < leftSignValues.Count - 1; i++)
            {
                for (int j = 0; j < rightSignValues.Count - 1; j++)
                {
                    result[i, j] = Math.Abs(leftSignValues[i] - rightSignValues[j]);
                }
            }
            return result;
        }

        public double DTWAlgorithm()
        {
            var backTraceMatrix = new double[LSign.Count, RSign.Count]; //new matrix filled out with 0

            for (int i = 0; i < LSign.Count; i++)
                for (int j = 0; j < RSign.Count; j++)
                {
                    double match = CostMatrix[i, j];
                    double insertion = CostMatrix[i, j + 1];
                    double deletion = CostMatrix[i + 1, j];

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

                   //Trace.WriteLine($"Point: [{i}, {j}]");
                   //Trace.WriteLine($"Operation: {BackTraceMatrix[i,j]}");
                }
           return Math.Round(CostMatrix[LSign.Count, RSign.Count], 2); //return top right corner element
        }

        

        #region OldGetAlignment
        //public List<Point> GetAlignment()
        //{
        //    Path = new List<Point>();

        //    //trace back from bottom right

        //    int i = LSign.Count - 1;
        //    int j = RSign.Count - 1;

        //    Path.Add(new Point(i, j));

        //    while (i > 0 || j > 0)
        //    {
        //        var operation = BackTraceMatrix[i, j];
        //        switch (operation)
        //        {
        //            case Operations.MATCH:
        //                {
        //                    i--; j--;
        //                }
        //                break;

        //            case Operations.INSERTION:
        //                {
        //                    i--;
        //                }
        //                break;

        //            case Operations.DELETION:
        //                {
        //                    j--;
        //                }
        //                break;
        //        }

        //        Path.Add(new Point(i, j));
        //        Trace.WriteLine($"Point: [{i}, {j}]");
        //        //Trace.WriteLine($"Operation: {BackTraceMatrix[i, j]}");
        //    }
        //    return Path;
        //}


        #endregion

        public Tuple<List<Point>, List<Operations>> GetAlignment()
        {
            Path = new List<Point>();
            var operations = new List<Operations>();

            //trace back from bottom right

            int i = LSign.Count - 1;
            int j = RSign.Count - 1;

            Path.Add(new Point(i, j));
            Trace.WriteLine($"Point: [{i}, {j}]");
            operations.Add(BackTraceMatrix[i, j]);
            Trace.WriteLine($"Operation: {BackTraceMatrix[i, j]}");

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

                Path.Add(new Point(i, j));
                operations.Add(operation);
                Trace.WriteLine($"Point: [{i}, {j}]");
                Trace.WriteLine($"Operation: {operation}");
            }

            Trace.WriteLine("-------------------");
            //PrintCostMatrix();
            return new Tuple<List<Point>, List<Operations>>(Path, operations);
        }

        private void PrintCostMatrix()
        {
            for (int i = 0; i < CostMatrix.GetLength(0); i++)
            for (int j = 0; j < CostMatrix.GetLength(1); j++)
                Trace.WriteLine($"Point: [{i}, {j}] = {CostMatrix[i, j]}");
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
