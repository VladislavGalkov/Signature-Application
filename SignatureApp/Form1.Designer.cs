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
            this.LeftCanvas = new System.Windows.Forms.Panel();
            this.cBoxUsers1 = new System.Windows.Forms.ComboBox();
            this.cBoxSignatures1 = new System.Windows.Forms.ComboBox();
            this.OkayButtonLeft = new System.Windows.Forms.Button();
            this.cBoxUsers2 = new System.Windows.Forms.ComboBox();
            this.cBoxSignatures2 = new System.Windows.Forms.ComboBox();
            this.OkayButtonRight = new System.Windows.Forms.Button();
            this.RightCanvas = new System.Windows.Forms.Panel();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.bDTW = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCostX = new System.Windows.Forms.TextBox();
            this.tbCostY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LeftCanvas
            // 
            this.LeftCanvas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LeftCanvas.Location = new System.Drawing.Point(12, 168);
            this.LeftCanvas.Name = "LeftCanvas";
            this.LeftCanvas.Size = new System.Drawing.Size(621, 630);
            this.LeftCanvas.TabIndex = 0;
            this.LeftCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.LeftCanvas_Paint);
            // 
            // cBoxUsers1
            // 
            this.cBoxUsers1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUsers1.FormattingEnabled = true;
            this.cBoxUsers1.Location = new System.Drawing.Point(48, 40);
            this.cBoxUsers1.Name = "cBoxUsers1";
            this.cBoxUsers1.Size = new System.Drawing.Size(149, 24);
            this.cBoxUsers1.TabIndex = 1;
            this.cBoxUsers1.SelectedIndexChanged += new System.EventHandler(this.cBoxUsers1_SelectedIndexChanged);
            // 
            // cBoxSignatures1
            // 
            this.cBoxSignatures1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSignatures1.FormattingEnabled = true;
            this.cBoxSignatures1.Location = new System.Drawing.Point(313, 40);
            this.cBoxSignatures1.Name = "cBoxSignatures1";
            this.cBoxSignatures1.Size = new System.Drawing.Size(149, 24);
            this.cBoxSignatures1.TabIndex = 2;
            // 
            // OkayButtonLeft
            // 
            this.OkayButtonLeft.Location = new System.Drawing.Point(201, 97);
            this.OkayButtonLeft.Name = "OkayButtonLeft";
            this.OkayButtonLeft.Size = new System.Drawing.Size(112, 43);
            this.OkayButtonLeft.TabIndex = 3;
            this.OkayButtonLeft.Text = "OK";
            this.OkayButtonLeft.UseMnemonic = false;
            this.OkayButtonLeft.UseVisualStyleBackColor = true;
            this.OkayButtonLeft.Click += new System.EventHandler(this.OkayButtonLeft_Click);
            // 
            // cBoxUsers2
            // 
            this.cBoxUsers2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUsers2.FormattingEnabled = true;
            this.cBoxUsers2.Location = new System.Drawing.Point(822, 40);
            this.cBoxUsers2.Name = "cBoxUsers2";
            this.cBoxUsers2.Size = new System.Drawing.Size(149, 24);
            this.cBoxUsers2.TabIndex = 4;
            this.cBoxUsers2.SelectedIndexChanged += new System.EventHandler(this.cBoxUsers2_SelectedIndexChanged);
            // 
            // cBoxSignatures2
            // 
            this.cBoxSignatures2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSignatures2.FormattingEnabled = true;
            this.cBoxSignatures2.Location = new System.Drawing.Point(1077, 40);
            this.cBoxSignatures2.Name = "cBoxSignatures2";
            this.cBoxSignatures2.Size = new System.Drawing.Size(149, 24);
            this.cBoxSignatures2.TabIndex = 5;
            // 
            // OkayButtonRight
            // 
            this.OkayButtonRight.Location = new System.Drawing.Point(965, 97);
            this.OkayButtonRight.Name = "OkayButtonRight";
            this.OkayButtonRight.Size = new System.Drawing.Size(112, 43);
            this.OkayButtonRight.TabIndex = 6;
            this.OkayButtonRight.Text = "OK";
            this.OkayButtonRight.UseMnemonic = false;
            this.OkayButtonRight.UseVisualStyleBackColor = true;
            this.OkayButtonRight.Click += new System.EventHandler(this.OkayButtonRight_Click);
            // 
            // RightCanvas
            // 
            this.RightCanvas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RightCanvas.Location = new System.Drawing.Point(686, 168);
            this.RightCanvas.Name = "RightCanvas";
            this.RightCanvas.Size = new System.Drawing.Size(621, 630);
            this.RightCanvas.TabIndex = 7;
            this.RightCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.RightCanvas_Paint);
            // 
            // tbDistance
            // 
            this.tbDistance.Location = new System.Drawing.Point(545, 61);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.ReadOnly = true;
            this.tbDistance.Size = new System.Drawing.Size(238, 22);
            this.tbDistance.TabIndex = 9;
            // 
            // bDTW
            // 
            this.bDTW.Location = new System.Drawing.Point(576, 12);
            this.bDTW.Name = "bDTW";
            this.bDTW.Size = new System.Drawing.Size(168, 43);
            this.bDTW.TabIndex = 10;
            this.bDTW.Text = "DTW distances";
            this.bDTW.UseMnemonic = false;
            this.bDTW.UseVisualStyleBackColor = true;
            this.bDTW.Click += new System.EventHandler(this.bDTW_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "DTWx";
            // 
            // tbCostX
            // 
            this.tbCostX.Location = new System.Drawing.Point(545, 97);
            this.tbCostX.Name = "tbCostX";
            this.tbCostX.ReadOnly = true;
            this.tbCostX.Size = new System.Drawing.Size(238, 22);
            this.tbCostX.TabIndex = 12;
            // 
            // tbCostY
            // 
            this.tbCostY.Location = new System.Drawing.Point(545, 140);
            this.tbCostY.Name = "tbCostY";
            this.tbCostY.ReadOnly = true;
            this.tbCostY.Size = new System.Drawing.Size(238, 22);
            this.tbCostY.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "DTWy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "DTWDiff";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 810);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCostY);
            this.Controls.Add(this.tbCostX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bDTW);
            this.Controls.Add(this.tbDistance);
            this.Controls.Add(this.RightCanvas);
            this.Controls.Add(this.OkayButtonRight);
            this.Controls.Add(this.cBoxSignatures2);
            this.Controls.Add(this.cBoxUsers2);
            this.Controls.Add(this.OkayButtonLeft);
            this.Controls.Add(this.cBoxSignatures1);
            this.Controls.Add(this.cBoxUsers1);
            this.Controls.Add(this.LeftCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Signature Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LeftCanvas;
        private System.Windows.Forms.ComboBox cBoxUsers1;
        private System.Windows.Forms.ComboBox cBoxSignatures1;
        private System.Windows.Forms.Button OkayButtonLeft;
        private System.Windows.Forms.ComboBox cBoxUsers2;
        private System.Windows.Forms.ComboBox cBoxSignatures2;
        private System.Windows.Forms.Button OkayButtonRight;
        private System.Windows.Forms.Panel RightCanvas;
        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.Button bDTW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCostX;
        private System.Windows.Forms.TextBox tbCostY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

