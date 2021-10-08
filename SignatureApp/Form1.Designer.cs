namespace SignatureApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.Panel();
            this.cBoxUsers = new System.Windows.Forms.ComboBox();
            this.cBoxSignatures = new System.Windows.Forms.ComboBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 91);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1217, 502);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // cBoxUsers
            // 
            this.cBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUsers.FormattingEnabled = true;
            this.cBoxUsers.Location = new System.Drawing.Point(173, 40);
            this.cBoxUsers.Name = "cBoxUsers";
            this.cBoxUsers.Size = new System.Drawing.Size(149, 24);
            this.cBoxUsers.TabIndex = 1;
            this.cBoxUsers.SelectedIndexChanged += new System.EventHandler(this.cBoxUsers_SelectedIndexChanged);
            // 
            // cBoxSignatures
            // 
            this.cBoxSignatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSignatures.FormattingEnabled = true;
            this.cBoxSignatures.Location = new System.Drawing.Point(400, 40);
            this.cBoxSignatures.Name = "cBoxSignatures";
            this.cBoxSignatures.Size = new System.Drawing.Size(149, 24);
            this.cBoxSignatures.TabIndex = 2;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(760, 30);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(112, 43);
            this.OKbutton.TabIndex = 3;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseMnemonic = false;
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(900, 30);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 43);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseMnemonic = false;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 605);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.cBoxSignatures);
            this.Controls.Add(this.cBoxUsers);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Signature Verification";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.ComboBox cBoxUsers;
        private System.Windows.Forms.ComboBox cBoxSignatures;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button CancelButton;
    }
}

