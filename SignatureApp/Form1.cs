using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureApp
{
    public partial class Form1 : Form
    {
        readonly Signature signatures = new Signature();

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
            List<Point> points = new List<Point>();
            Pen pen = new Pen(Color.Black);


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

                    if (!Int32.Parse(parsed[0]).Equals(-1)) // when a line starts with '-1', it means the end of a stroke
                    {
                        Point p = new Point(Int32.Parse(parsed[0]), Int32.Parse(parsed[1]));
                        points.Add(p);
                    }
                }


                var flipYMatrix = new Matrix(1, 0, 0, -1, 0, canvas.Height); // reflection in the X-axis 

                e.Graphics.Transform = flipYMatrix;
                // e.Graphics.DrawLines(pen, points.ToArray());


                for (int i = 1; i < points.Count; i++)
                {
                    Point prevPoint = new Point(points[i - 1].X, points[i - 1].Y);
                    Point currPoint = new Point(points[i].X, points[i].Y);


                    Trace.WriteLine($"Previous point {i}:  ({prevPoint.X}, {prevPoint.Y}) ");
                    Trace.WriteLine($"Current point: {i}: ({currPoint.X}, {currPoint.Y}) ");

                    double scale = 1;
                    //e.Graphics.DrawLine(pen, (int)(prevPoint.X / scale), (int)(prevPoint.Y - 350 / scale), (int)(currPoint.X / scale), (int)(currPoint.Y - 350 / scale));
                    e.Graphics.DrawLine(pen, prevPoint.X - 125, prevPoint.Y - 300, currPoint.X - 125, currPoint.Y - 300);
                }
            }
        }

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




        private void CancelButton_Click(object sender, EventArgs e)
        {
            LeftCanvas.Controls.Clear();
        }

     
    }
}
