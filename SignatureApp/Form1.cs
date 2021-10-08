using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            //Signature signatures = new Signature();
            InitializeComponent();
            var keys = signatures.Parse().Keys.ToList();
            foreach (var user in keys)
            {
                cBoxUsers.Items.Add(user);
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
           // e.Graphics.DrawLine(new Pen(Color.Black), 124/2, 250/2, 126/2, 250/2);
            List<Point> points = new List<Point>();

            Pen pen = new Pen(Color.Black);

            if (!cBoxUsers.Text.Equals("") && !cBoxSignatures.Text.Equals(""))
            {
                Trace.WriteLine(cBoxUsers.Text);
                Trace.WriteLine(cBoxSignatures.Text);
                string path = @"F:\Programming\C#\Signature Verification Project\SignatureApp\SignatureApp\Database\" + cBoxUsers.Text + '_' + cBoxSignatures.Text + "trj";
                //string path = @"F:\Programming\C#\Signature Verification Project\SignatureApp\SignatureApp\Database\A03_F1_2.trj";

                string[] lines = System.IO.File.ReadAllLines(path);

                for (int i = 1; i < lines.Length - 1; i++)
                {
                    string line = lines[i];
                    string[] parsed = line.Split(' ');

                    if (!Int32.Parse(parsed[0]).Equals(-1))
                    {
                        Point p = new Point(Int32.Parse(parsed[0]), Int32.Parse(parsed[1]));
                        points.Add(p);
                    }
                }

                for (int i = 1; i < points.Count; i++)
                {

                    //e.Graphics.DrawLine(pen, 124, 397, 126, 402);

                    var xMinusOne = points[i - 1].X;
                    var yMinusOne = points[i - 1].Y;

                    var X = points[i].X;
                    var Y = points[i].Y;

                    double scale = 1;

                    //Trace.WriteLine(xMinusOne);
                    //Trace.WriteLine(yMinusOne);
                    e.Graphics.DrawLine(pen, (int)((points[i-1].X)/scale), (int)((points[i - 1].Y - 300) / scale), (int)((points[i].X) / scale), (int)((points[i].Y - 300) / scale));
                }
            }
        }

        private void cBoxSignatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
