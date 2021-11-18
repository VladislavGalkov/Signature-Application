using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureApp
{
    public partial class Form1 : Form
    {
        readonly Signature signatures = new Signature();
        //private List<List<Point>> DTWTest = new List<List<Point>>();

        public Form1()
        {
            InitializeComponent();
            var keys = signatures.Parse().Keys.ToList(); //all users
            foreach (var user in keys)
            {
                cBoxUsers1.Items.Add(user);
                cBoxUsers2.Items.Add(user);
            }
        }

        private void OkayButtonLeft_Click(object sender, EventArgs e)
        {
            LeftCanvas.Invalidate();
        }

        private void OkayButtonRight_Click(object sender, EventArgs e)
        {
            RightCanvas.Invalidate();
        }

        private void cBoxUsers1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSignatures(cBoxUsers1, cBoxSignatures1);
        }

        private void cBoxUsers2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSignatures(cBoxUsers2, cBoxSignatures2);
        }

        private void ShowSignatures(ComboBox users, ComboBox signs)
        {
            var dict = signatures.Parse();
            var signaturesOfUser = dict[users.Text];
            foreach (var sign in signaturesOfUser)
            {
                signs.Items.Add(sign);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
        }

        private void LeftCanvas_Paint(object sender, PaintEventArgs e)
        {
            Draw(sender, e, cBoxUsers1, cBoxSignatures1, LeftCanvas);
        }

        private void RightCanvas_Paint(object sender, PaintEventArgs e)
        {
            Draw(sender, e, cBoxUsers2, cBoxSignatures2, RightCanvas);
        }

        private void Draw(object sender, PaintEventArgs e, ComboBox users, ComboBox signs, Panel canvas)
        {
          // List<Point> points = new List<Point>();
            Pen pen = new Pen(Color.Black);

            var points = GetSignatureThroughComboboxes(users, signs);
           // var points = GetSignatureThroughComboboxes(users, signs).Select(p => new PointF(p.X, p.Y)).ToList(); //convert to List<PointF> 

            var flipYMatrix = new Matrix(1, 0, 0, -1, 0, canvas.Height); // reflection in the X-axis 

            e.Graphics.Transform = flipYMatrix;

            //Preprocessor preprocessor = new Preprocessor();
            //preprocessor.ScaleAndShift(points);



            //if (points.Count != 0)
            //{
            //    e.Graphics.DrawLines(pen, points.ToArray());
            //}


            for (int i = 1; i < points.Count; i++)
            {
                var prevPoint = new PointF(points[i - 1].X, points[i - 1].Y);
                var currPoint = new PointF(points[i].X, points[i].Y);


                Trace.WriteLine($"Previous point {i}:  ({prevPoint.X}, {prevPoint.Y}) ");
                Trace.WriteLine($"Current point: {i}: ({currPoint.X}, {currPoint.Y}) ");

                //e.Graphics.DrawLine(pen, (int)(prevPoint.X / scale), (int)(prevPoint.Y - 350 / scale), (int)(currPoint.X / scale), (int)(currPoint.Y - 350 / scale));
                e.Graphics.DrawLine(pen, (int) prevPoint.X/2, (int) prevPoint.Y/2, (int) currPoint.X/2, (int) currPoint.Y/2);
               // e.Graphics.DrawLine(pen, (int)prevPoint.X, (int)prevPoint.Y, (int)currPoint.X, (int)currPoint.Y);
            }

            #region OldDrawing
            //if (!users.Text.Equals("") && !signs.Text.Equals("")) // when the program starts all comboboxes are empty
            //{
            //    //Trace.WriteLine(cBoxUsers.Text);
            //    //Trace.WriteLine(cBoxSignatures.Text);

            //    string path = signatures.DatabaseFolderPath + "\\" + users.Text + '_' + signs.Text + ".trj";

            //    string[] lines = System.IO.File.ReadAllLines(path);

            //    for (int i = 1; i < lines.Length - 1; i++)
            //    {
            //        string line = lines[i];
            //        string[] parsed = line.Split(' ');

            //        if (!Int32.Parse(parsed[0]).Equals(-1)) // when a line starts with '-1', it means the end of a stroke
            //        {
            //            Point p = new Point(Int32.Parse(parsed[0]), Int32.Parse(parsed[1]));
            //            points.Add(p);
            //        }
            //    }

            //    //DTWTest.Add(points);


            //    var flipYMatrix = new Matrix(1, 0, 0, -1, 0, canvas.Height); // reflection in the X-axis 

            //    e.Graphics.Transform = flipYMatrix;
            //    // e.Graphics.DrawLines(pen, points.ToArray());


            //    for (int i = 1; i < points.Count; i++)
            //    {
            //        Point prevPoint = new Point(points[i - 1].X, points[i - 1].Y);
            //        Point currPoint = new Point(points[i].X, points[i].Y);


            //        Trace.WriteLine($"Previous point {i}:  ({prevPoint.X}, {prevPoint.Y}) ");
            //        Trace.WriteLine($"Current point: {i}: ({currPoint.X}, {currPoint.Y}) ");

            //        double scale = 1;
            //        //e.Graphics.DrawLine(pen, (int)(prevPoint.X / scale), (int)(prevPoint.Y - 350 / scale), (int)(currPoint.X / scale), (int)(currPoint.Y - 350 / scale));
            //        e.Graphics.DrawLine(pen, prevPoint.X - 125, prevPoint.Y - 300, currPoint.X - 125, currPoint.Y - 300);
            //    }
            //}


            #endregion
        }

        private List<PointF> GetSignatureThroughComboboxes(ComboBox users, ComboBox signs)
        {
            var result = new List<PointF>();

            if (!users.Text.Equals("") && !signs.Text.Equals("")) // when the program starts all comboboxes are empty
            {
                //Trace.WriteLine(cBoxUsers.Text);
                //Trace.WriteLine(cBoxSignatures.Text);

                string path = signatures.DatabaseFolderPath + "\\" + users.Text + '_' + signs.Text + ".trj";

                string[] lines = System.IO.File.ReadAllLines(path);

                for (int i = 1; i < lines.Length - 1; i++)
                {
                    string line = lines[i];
                    string[] parsed = line.Split(' ');

                    if (!Int32.Parse(parsed[0])
                        .Equals(-1)) // when a line starts with '-1', it means the end of a stroke
                    {
                        Point p = new Point(Int32.Parse(parsed[0]), Int32.Parse(parsed[1]));
                        result.Add(p);
                    }
                }
            }

            return result;
        }

        #region TestImplementationOfDTW




        //public double DTW(List<Point> x, List<Point> y)
        //{
        //    // get all distances
        //    var DistMatrix = new double[x.Count,y.Count];

        //    for (int i = 0; i < x.Count - 1; i++)
        //    {
        //        for (int j = 0; j < y.Count - 1; j++)
        //        {
        //            DistMatrix[i, j] = GetDistance(x[i], y[j]);
        //        }
        //    }

        //    var CostMatrix = new double[x.Count + 1, y.Count + 1];

        //    //CostMatrix Initialization 
        //    CostMatrix[0, 0] = 0;
        //    for (int i = 1; i < x.Count + 1; i++)
        //        CostMatrix[i, 0] = Double.PositiveInfinity;
        //    for (int j = 1; j < y.Count + 1; j++)
        //        CostMatrix[0, j] = Double.PositiveInfinity;

        //    //fill the CostMatrix 

        //    var backtraceMatrix = new double[x.Count, y.Count];
        //    //for (int i = 0; i < x.Count - 1; i++)
        //    //{
        //    //    for (int j = 0; j < y.Count - 1; j++)
        //    //    {
        //    //        backtraceMatrix[i, j] = 0;
        //    //    }
        //    //}

        //    for (int i = 0; i < x.Count; i++)
        //    {
        //        for (int j = 0; j < y.Count; j++)
        //        {
        //            double match = CostMatrix[i, j];
        //            double insertion = CostMatrix[i, j + 1];
        //            double deletion = CostMatrix[i + 1, j];

        //            List<double> values = new List<double>();
        //            values.Add(match);
        //            values.Add(insertion);
        //            values.Add(deletion);

        //            double min = Math.Min(match, Math.Min(insertion, deletion));
        //           //var min = values.Min();
        //           CostMatrix[i + 1, j + 1] = DistMatrix[i, j] + min; //CostMatrix[0,0] = 0; 
        //           backtraceMatrix[i, j] = values.IndexOf(min);
        //        }
        //    }

        //    //traceback from bottom right
        //    int k = x.Count - 1;
        //    int l = y.Count - 1;

        //    var result = CostMatrix[k, l];
        //    while (k > 0 || l > 0)
        //    {
        //        var oper = backtraceMatrix[k, l];
        //        switch (oper)
        //        {
        //            case 0:
        //            {
        //                k--; l--;
        //            }break;

        //            case 1:
        //            {
        //                k--; 
        //            } break;

        //            case 2:
        //            {
        //               l--;
        //            } break;
        //        }

        //        result += CostMatrix[k, l];
        //    }

        //    tbDistance.Text = result.ToString(CultureInfo.InvariantCulture);
        //    return result;
        //}

        //private double GetDistance(Point point, Point point1)
        //{
        //    Trace.WriteLine(Math.Sqrt(Math.Pow(point.X - point1.X, 2) + Math.Pow(point.Y - point1.Y, 2)));
        //    return Math.Sqrt(Math.Pow(point.X - point1.X, 2) + Math.Pow(point.Y - point1.Y, 2));
        //}

        //private List<Point> CheckPosition(List<Point> points, Panel canvas)
        //{
        //    int count = 0;
        //    foreach (var point in points)
        //    {
        //        if (point.Y > canvas.Height)
        //        {
        //            count++;
        //            break;
        //        }
        //    }

        //    foreach (var point in points)
        //    {
        //        point.Y = -150;
        //    }
        //}

        #endregion


        private void CancelButton_Click(object sender, EventArgs e)
        {
            LeftCanvas.Controls.Clear();
        }

    

        private void bDTW_Click(object sender, EventArgs e)
        {
            rbZNorm.Checked = false;

            var signature1 = GetSignatureThroughComboboxes(cBoxUsers1, cBoxSignatures1);
            var signature2 = GetSignatureThroughComboboxes(cBoxUsers2, cBoxSignatures2);

            DTW dtwOriginal = new DTW(signature1, signature2);
            var result = dtwOriginal.DTWAlgorithm(dtwOriginal.DistanceMatrix);
            var DTWx = dtwOriginal.DTWAlgorithm(dtwOriginal.DistanceMatrixX);
            var DTWy = dtwOriginal.DTWAlgorithm(dtwOriginal.DistanceMatrixY);

            var preprocessor = new Preprocessor();

            signature1 = preprocessor.Scale(signature1);
            signature1 = preprocessor.Shift(signature1);

            signature2 = preprocessor.Scale(signature2);
            signature2 = preprocessor.Shift(signature2);

            DTW dtwPreProcess = new DTW(signature1, signature2);
            var resultPreProcess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrix);
            var DTWxPreProcess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrixX);
            var DTWyPreprocess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrixY);

            //var alignmentOperations = dtw.GetAlignment();


            // var lSign = new List<Point>();
            // lSign.Add(new Point(0, 0));
            // //lSign.Add(new Point(0, 1));
            // //lSign.Add(new Point(1, 1));

            // var rSign = new List<Point>();
            // rSign.Add(new Point(0, 0));
            //// rSign.Add(new Point(0, 1));
            // //rSign.Add(new Point(1, 1));
            // rSign.Add(new Point(1, 2));
            // rSign.Add(new Point(1, 3));

            //  DTW dtw = new DTW(lSign, rSign);
            //  var result = dtw.DTWAlgorithm();
            //  var alignmentOperations = dtw.GetAlignment();
            //List<Point> points = dtw.Path;

            //foreach (var point in alignmentOperations.Item1)
            //{
            //    Trace.WriteLine($"Point: [{point.X}, {point.Y}]");
            //}

            //foreach (var oper in alignmentOperations.Item2)
            //{
            //    Trace.WriteLine($"Operation: {oper}");
            //}

            tbDistance.Text = result.ToString(CultureInfo.InvariantCulture);
            tbCostX.Text = DTWx.ToString(CultureInfo.InvariantCulture);
            tbCostY.Text = DTWy.ToString(CultureInfo.InvariantCulture);

            tbDistancePreProcess.Text = resultPreProcess.ToString(CultureInfo.InvariantCulture);
            tbCostXPreProcess.Text = DTWxPreProcess.ToString(CultureInfo.InvariantCulture);
            tbCostYPreProcess.Text = DTWyPreprocess.ToString(CultureInfo.InvariantCulture);
        }

        private void rbZNorm_CheckedChanged(object sender, EventArgs e)
        {
            var signature1 = GetSignatureThroughComboboxes(cBoxUsers1, cBoxSignatures1);
            var signature2 = GetSignatureThroughComboboxes(cBoxUsers2, cBoxSignatures2);
            var Normalizator = new Normalization();
            signature1 = Normalizator.Normalize(signature1);
            signature2 = Normalizator.Normalize(signature2);

            DTW dtwPreProcess = new DTW(signature1, signature2);
            var resultPreProcess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrix);
            var DTWxPreProcess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrixX);
            var DTWyPreprocess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrixY);

            tbDistancePreProcess.Text = resultPreProcess.ToString(CultureInfo.InvariantCulture);
            tbCostXPreProcess.Text = DTWxPreProcess.ToString(CultureInfo.InvariantCulture);
            tbCostYPreProcess.Text = DTWyPreprocess.ToString(CultureInfo.InvariantCulture);
        }
    }
}
