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
            Signature signatures = new Signature();
            InitializeComponent();
           
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            var keys = signatures.Parse().Keys.ToList();
            foreach (var user in keys)
            {
                cBoxUsers.Items.Add(user);
            }
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
    }
}
