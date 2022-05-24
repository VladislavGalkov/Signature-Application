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
    public partial class UI : Form
    {
        readonly Signature signatureAndUserDatabase = new Signature();
        public List<PointF> LSign { get; set; }
        public List<PointF> RSign { get; set; }

        public UI()
        {
            InitializeComponent();
            var keys = signatureAndUserDatabase.Parse().Keys.ToList(); //all users
            foreach (var user in keys)
            {
                cBoxUsers1.Items.Add(user);
                cBoxUsers2.Items.Add(user);
            }
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            canvas.Invalidate();
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
            //var dict = signatureAndUserDatabase.Parse();
            var signaturesOfUser = signatureAndUserDatabase.GetSignatureNames(users.Text);

            if (signs.Items.Count == 0)
            {
                signs = GetSignatures(signs, signaturesOfUser);
            }

            else
            {
                signs.Items.Clear();
                signs = GetSignatures(signs, signaturesOfUser);
            }
        }

        private List<PointF> GetOriginalSignatureFromCombobox(ComboBox users, ComboBox signs)
        {
            var result = new List<PointF>();

            if (!users.Text.Equals("") && !signs.Text.Equals("")) // when the program starts all comboboxes are empty
            {
                result = signatureAndUserDatabase.CreateSignature(users.Text, signs.Text);
            }

            return result;
        }

        private ComboBox GetSignatures(ComboBox signs, List<string> signatures)
        {
            foreach (var sign in signatures)
            {
                signs.Items.Add(sign);
            }

            return signs;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Draw(sender, e, cBoxUsers1, cBoxSignatures1, canvas, Color.Yellow);
            Draw(sender, e, cBoxUsers2, cBoxSignatures2, canvas, Color.Red);

        }

        private void Draw(object sender, PaintEventArgs e, ComboBox users, ComboBox signs, Panel canvas, Color color)
        {
            LSign = GetOriginalSignatureFromCombobox(cBoxUsers1, cBoxSignatures1);
            RSign = GetOriginalSignatureFromCombobox(cBoxUsers2, cBoxSignatures2);

            Pen pen = new Pen(color, 0.5f);

            var points = GetOriginalSignatureFromCombobox(users, signs);

            var flipYMatrix = new Matrix(1, 0, 0, -1, 0, canvas.Height); // reflection in the X-axis 

            //// scale and translate the coordinates
            //e.Graphics.ScaleTransform(1.0F, -1.0F);
            //e.Graphics.TranslateTransform(0.0F, -(float)canvas.Height);

            e.Graphics.TranslateTransform(canvas.Width / 2, canvas.Height / 2);

            e.Graphics.Transform = flipYMatrix;

            PointF[] pointsToDraw = null;

            if (points != null && points.Count != 0)
            {
                for (int i = 1; i < points.Count; i++)
                {
                    var prevPoint = new PointF(points[i - 1].X, points[i - 1].Y);
                    var currPoint = new PointF(points[i].X, points[i].Y);


                    Trace.WriteLine($"Previous point {i}:  ({prevPoint.X}, {prevPoint.Y}) ");
                    Trace.WriteLine($"Current point: {i}: ({currPoint.X}, {currPoint.Y}) ");


                    //e.Graphics.DrawLine(pen, (int)prevPoint.X / 2, (int)prevPoint.Y / 2, (int)currPoint.X / 2, (int)currPoint.Y / 2);

                    pointsToDraw = points.ToArray();

                }

                int height = canvas.Height;
                int width = canvas.Width;
                var newPointArray = Array.ConvertAll(pointsToDraw, p => new PointF((p.X / canvas.Height) * 180, (p.Y / canvas.Width) * 180));
               
                foreach (var point in pointsToDraw)
                {
                    Trace.WriteLine($"({point.X}, {point.Y})");
                }

                e.Graphics.DrawLines(pen, newPointArray);
            }

            pen.Dispose();           
        }


        private void bDTW_Click(object sender, EventArgs e)
        {
            rbZNorm.Checked = false;

            LSign = GetOriginalSignatureFromCombobox(cBoxUsers1, cBoxSignatures1);
            RSign = GetOriginalSignatureFromCombobox(cBoxUsers2, cBoxSignatures2);

            DTW dtwOriginal = new DTW(LSign, RSign);
            var result = dtwOriginal.DTWAlgorithm(dtwOriginal.DistanceMatrix);
            var DTWx = dtwOriginal.DTWAlgorithm(dtwOriginal.DistanceMatrixX);
            var DTWy = dtwOriginal.DTWAlgorithm(dtwOriginal.DistanceMatrixY);

            var preprocessor = new Preprocessor();

            LSign = preprocessor.ScaleAndShift(LSign);
            RSign = preprocessor.ScaleAndShift(RSign);

            DTW dtwPreProcess = new DTW(LSign, RSign);
            var resultPreProcess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrix);
            var DTWxPreProcess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrixX);
            var DTWyPreprocess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrixY);

            #region Alignment
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

            #endregion

            tbDistance.Text = result.ToString(CultureInfo.InvariantCulture);
            tbCostX.Text = DTWx.ToString(CultureInfo.InvariantCulture);
            tbCostY.Text = DTWy.ToString(CultureInfo.InvariantCulture);

            tbDistancePreProcess.Text = resultPreProcess.ToString(CultureInfo.InvariantCulture);
            tbCostXPreProcess.Text = DTWxPreProcess.ToString(CultureInfo.InvariantCulture);
            tbCostYPreProcess.Text = DTWyPreprocess.ToString(CultureInfo.InvariantCulture);


            Task.Run(() =>
            {
                var output = ExcelHandler.SetUpData();
                ExcelHandler.SetUpExcel(output);
                Trace.WriteLine("Done with EXCEL!");
            }
            );
        }

        private void rbZNorm_CheckedChanged(object sender, EventArgs e)
        {
            var Normalizator = new Normalizator();
            LSign = Normalizator.Normalize(LSign);
            RSign = Normalizator.Normalize(RSign);

            DTW dtwPreProcess = new DTW(LSign, RSign);
            var resultPreProcess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrix);
            var DTWxPreProcess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrixX);
            var DTWyPreprocess = dtwPreProcess.DTWAlgorithm(dtwPreProcess.DistanceMatrixY); 

            tbDistancePreProcess.Text = resultPreProcess.ToString(CultureInfo.InvariantCulture);
            tbCostXPreProcess.Text = DTWxPreProcess.ToString(CultureInfo.InvariantCulture);
            tbCostYPreProcess.Text = DTWyPreprocess.ToString(CultureInfo.InvariantCulture); 
        }

        private void bVerify_Click(object sender, EventArgs e)
        {
            var verifierLeft = new Verifier(LSign, signatureAndUserDatabase.GetSignatures(cBoxUsers1.Text, 'R', true));
            var verifierRight = new Verifier(RSign, signatureAndUserDatabase.GetSignatures(cBoxUsers2.Text, 'R', true));
            tbVerificationLeft.Text = verifierLeft.IsGenuine() ? "Genuine!" : "Forged!"; //first signature
            tbVerificationRight.Text = verifierRight.IsGenuine() ? "Genuine!" : "Forged!"; //second signature
            tbSelectedAvrgLeft.Text = verifierLeft.average.ToString();
            tbRefAvrgLeft.Text = verifierLeft.refAverage.ToString();
            tbSelectedAvrgRight.Text = verifierRight.average.ToString();
            tbRefAvrgRight.Text = verifierRight.refAverage.ToString();
        }
    }
}
