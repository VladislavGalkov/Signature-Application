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
                cBoxUsers.Items.Add(user);
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }


        private void cBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dict = signatures.Parse();
            var signaturesOfUser = dict[cBoxUsers.Text]; 
            foreach (var sign in signaturesOfUser)
            {
                cBoxSignatures.Items.Add(sign);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            List<Point> points = new List<Point>();
            Pen pen = new Pen(Color.Black);


            if (!cBoxUsers.Text.Equals("") && !cBoxSignatures.Text.Equals("")) // when the program starts both comboboxes are empty
            {
                //Trace.WriteLine(cBoxUsers.Text);
                //Trace.WriteLine(cBoxSignatures.Text);

                string path = signatures.DatabaseFolderPath + "\\" + cBoxUsers.Text + '_' + cBoxSignatures.Text + ".trj";

                string[] lines = System.IO.File.ReadAllLines(path);

                for (int i = 1; i < lines.Length - 1; i++)
                {
                    string line = lines[i];
                    string[] parsed = line.Split(' ');

                    if (!Int32.Parse(parsed[0]).Equals(-1)) // when a line starts with '-1', it means the end of a stroke
                    {
                        Point p = new Point(Int32.Parse(parsed[0]), Int32.Parse(parsed[1]));
                       // CheckPosition();
                        points.Add(p);
                    }
                }

               
                var flipYMatrix = new Matrix(1, 0, 0, -1, 0, canvas.Height); // reflection in the X-axis 
                
                e.Graphics.Transform = flipYMatrix;
                e.Graphics.DrawLines(pen, points.ToArray());

                //for (int i = 1; i < points.Count; i++)
                //{
                //    Point prevPoint = new Point(points[i - 1].X, points[i - 1].Y);
                //    Point currPoint = new Point(points[i].X, points[i].Y);

                //    Trace.WriteLine($"Previous point {i}:  ({prevPoint.X}, {prevPoint.Y}) ");
                //    Trace.WriteLine($"Current point: {i}: ({currPoint.X}, {currPoint.Y}) ");

                //    double scale = 1;
                //    e.Graphics.DrawLine(pen, (int)(prevPoint.X / scale), (int)(prevPoint.Y - 350 / scale), (int)(currPoint.X / scale), (int)(currPoint.Y - 350 / scale));
                //}
            }
        }

        private void CheckPosition(Point point)
        {
            if (point.X < canvas.Width)
                point.X = canvas.Width;
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            canvas.Controls.Clear();
        }
    }
}
