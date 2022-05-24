namespace SignatureApp
{
    partial class UI
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
            this.cBoxUsers1 = new System.Windows.Forms.ComboBox();
            this.cBoxSignatures1 = new System.Windows.Forms.ComboBox();
            this.OkayButtonLeft = new System.Windows.Forms.Button();
            this.cBoxUsers2 = new System.Windows.Forms.ComboBox();
            this.cBoxSignatures2 = new System.Windows.Forms.ComboBox();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.bDTW = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCostX = new System.Windows.Forms.TextBox();
            this.tbCostY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDistancePreProcess = new System.Windows.Forms.TextBox();
            this.tbCostXPreProcess = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCostYPreProcess = new System.Windows.Forms.TextBox();
            this.rbZNorm = new System.Windows.Forms.RadioButton();
            this.tbVerificationLeft = new System.Windows.Forms.TextBox();
            this.bVerify = new System.Windows.Forms.Button();
            this.tbVerificationRight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRefAvrgLeft = new System.Windows.Forms.TextBox();
            this.tbSelectedAvrgLeft = new System.Windows.Forms.TextBox();
            this.tbRefAvrgRight = new System.Windows.Forms.TextBox();
            this.tbSelectedAvrgRight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(12, 215);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(824, 314);
            this.canvas.TabIndex = 6;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // cBoxUsers1
            // 
            this.cBoxUsers1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUsers1.FormattingEnabled = true;
            this.cBoxUsers1.Location = new System.Drawing.Point(12, 31);
            this.cBoxUsers1.Name = "cBoxUsers1";
            this.cBoxUsers1.Size = new System.Drawing.Size(65, 24);
            this.cBoxUsers1.TabIndex = 1;
            this.cBoxUsers1.SelectedIndexChanged += new System.EventHandler(this.cBoxUsers1_SelectedIndexChanged);
            // 
            // cBoxSignatures1
            // 
            this.cBoxSignatures1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSignatures1.FormattingEnabled = true;
            this.cBoxSignatures1.Location = new System.Drawing.Point(78, 31);
            this.cBoxSignatures1.Name = "cBoxSignatures1";
            this.cBoxSignatures1.Size = new System.Drawing.Size(73, 24);
            this.cBoxSignatures1.TabIndex = 2;
            // 
            // OkayButtonLeft
            // 
            this.OkayButtonLeft.Location = new System.Drawing.Point(727, 12);
            this.OkayButtonLeft.Name = "OkayButtonLeft";
            this.OkayButtonLeft.Size = new System.Drawing.Size(109, 66);
            this.OkayButtonLeft.TabIndex = 3;
            this.OkayButtonLeft.Text = "OK";
            this.OkayButtonLeft.UseMnemonic = false;
            this.OkayButtonLeft.UseVisualStyleBackColor = true;
            this.OkayButtonLeft.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // cBoxUsers2
            // 
            this.cBoxUsers2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUsers2.FormattingEnabled = true;
            this.cBoxUsers2.Location = new System.Drawing.Point(204, 31);
            this.cBoxUsers2.Name = "cBoxUsers2";
            this.cBoxUsers2.Size = new System.Drawing.Size(60, 24);
            this.cBoxUsers2.TabIndex = 4;
            this.cBoxUsers2.SelectedIndexChanged += new System.EventHandler(this.cBoxUsers2_SelectedIndexChanged);
            // 
            // cBoxSignatures2
            // 
            this.cBoxSignatures2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSignatures2.FormattingEnabled = true;
            this.cBoxSignatures2.Location = new System.Drawing.Point(270, 31);
            this.cBoxSignatures2.Name = "cBoxSignatures2";
            this.cBoxSignatures2.Size = new System.Drawing.Size(66, 24);
            this.cBoxSignatures2.TabIndex = 5;
            // 
            // tbDistance
            // 
            this.tbDistance.Location = new System.Drawing.Point(486, 86);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.ReadOnly = true;
            this.tbDistance.Size = new System.Drawing.Size(77, 22);
            this.tbDistance.TabIndex = 9;
            // 
            // bDTW
            // 
            this.bDTW.Location = new System.Drawing.Point(512, 9);
            this.bDTW.Name = "bDTW";
            this.bDTW.Size = new System.Drawing.Size(117, 43);
            this.bDTW.TabIndex = 10;
            this.bDTW.Text = "DTW distances";
            this.bDTW.UseMnemonic = false;
            this.bDTW.UseVisualStyleBackColor = true;
            this.bDTW.Click += new System.EventHandler(this.bDTW_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "DTWx";
            // 
            // tbCostX
            // 
            this.tbCostX.Location = new System.Drawing.Point(486, 114);
            this.tbCostX.Name = "tbCostX";
            this.tbCostX.ReadOnly = true;
            this.tbCostX.Size = new System.Drawing.Size(77, 22);
            this.tbCostX.TabIndex = 12;
            // 
            // tbCostY
            // 
            this.tbCostY.Location = new System.Drawing.Point(486, 142);
            this.tbCostY.Name = "tbCostY";
            this.tbCostY.ReadOnly = true;
            this.tbCostY.Size = new System.Drawing.Size(77, 22);
            this.tbCostY.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "DTWy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "DTWDiff";
            // 
            // tbDistancePreProcess
            // 
            this.tbDistancePreProcess.Location = new System.Drawing.Point(577, 86);
            this.tbDistancePreProcess.Name = "tbDistancePreProcess";
            this.tbDistancePreProcess.ReadOnly = true;
            this.tbDistancePreProcess.Size = new System.Drawing.Size(77, 22);
            this.tbDistancePreProcess.TabIndex = 16;
            // 
            // tbCostXPreProcess
            // 
            this.tbCostXPreProcess.Location = new System.Drawing.Point(577, 114);
            this.tbCostXPreProcess.Name = "tbCostXPreProcess";
            this.tbCostXPreProcess.ReadOnly = true;
            this.tbCostXPreProcess.Size = new System.Drawing.Size(77, 22);
            this.tbCostXPreProcess.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Original";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(574, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Preprocessing";
            // 
            // tbCostYPreProcess
            // 
            this.tbCostYPreProcess.Location = new System.Drawing.Point(577, 142);
            this.tbCostYPreProcess.Name = "tbCostYPreProcess";
            this.tbCostYPreProcess.ReadOnly = true;
            this.tbCostYPreProcess.Size = new System.Drawing.Size(77, 22);
            this.tbCostYPreProcess.TabIndex = 20;
            // 
            // rbZNorm
            // 
            this.rbZNorm.AutoSize = true;
            this.rbZNorm.Location = new System.Drawing.Point(691, 121);
            this.rbZNorm.Name = "rbZNorm";
            this.rbZNorm.Size = new System.Drawing.Size(78, 21);
            this.rbZNorm.TabIndex = 21;
            this.rbZNorm.TabStop = true;
            this.rbZNorm.Text = "Z-score";
            this.rbZNorm.UseVisualStyleBackColor = true;
            this.rbZNorm.CheckedChanged += new System.EventHandler(this.rbZNorm_CheckedChanged);
            // 
            // tbVerificationLeft
            // 
            this.tbVerificationLeft.Location = new System.Drawing.Point(12, 66);
            this.tbVerificationLeft.Name = "tbVerificationLeft";
            this.tbVerificationLeft.ReadOnly = true;
            this.tbVerificationLeft.Size = new System.Drawing.Size(139, 22);
            this.tbVerificationLeft.TabIndex = 22;
            // 
            // bVerify
            // 
            this.bVerify.Location = new System.Drawing.Point(114, 166);
            this.bVerify.Name = "bVerify";
            this.bVerify.Size = new System.Drawing.Size(117, 43);
            this.bVerify.TabIndex = 23;
            this.bVerify.Text = "Verify";
            this.bVerify.UseMnemonic = false;
            this.bVerify.UseVisualStyleBackColor = true;
            this.bVerify.Click += new System.EventHandler(this.bVerify_Click);
            // 
            // tbVerificationRight
            // 
            this.tbVerificationRight.Location = new System.Drawing.Point(203, 66);
            this.tbVerificationRight.Name = "tbVerificationRight";
            this.tbVerificationRight.ReadOnly = true;
            this.tbVerificationRight.Size = new System.Drawing.Size(133, 22);
            this.tbVerificationRight.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "User1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "User2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "Signature";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Signature";
            // 
            // tbRefAvrgLeft
            // 
            this.tbRefAvrgLeft.Location = new System.Drawing.Point(12, 112);
            this.tbRefAvrgLeft.Name = "tbRefAvrgLeft";
            this.tbRefAvrgLeft.ReadOnly = true;
            this.tbRefAvrgLeft.Size = new System.Drawing.Size(139, 22);
            this.tbRefAvrgLeft.TabIndex = 29;
            // 
            // tbSelectedAvrgLeft
            // 
            this.tbSelectedAvrgLeft.Location = new System.Drawing.Point(12, 137);
            this.tbSelectedAvrgLeft.Name = "tbSelectedAvrgLeft";
            this.tbSelectedAvrgLeft.ReadOnly = true;
            this.tbSelectedAvrgLeft.Size = new System.Drawing.Size(139, 22);
            this.tbSelectedAvrgLeft.TabIndex = 30;
            // 
            // tbRefAvrgRight
            // 
            this.tbRefAvrgRight.Location = new System.Drawing.Point(197, 112);
            this.tbRefAvrgRight.Name = "tbRefAvrgRight";
            this.tbRefAvrgRight.ReadOnly = true;
            this.tbRefAvrgRight.Size = new System.Drawing.Size(139, 22);
            this.tbRefAvrgRight.TabIndex = 33;
            // 
            // tbSelectedAvrgRight
            // 
            this.tbSelectedAvrgRight.Location = new System.Drawing.Point(197, 137);
            this.tbSelectedAvrgRight.Name = "tbSelectedAvrgRight";
            this.tbSelectedAvrgRight.ReadOnly = true;
            this.tbSelectedAvrgRight.Size = new System.Drawing.Size(139, 22);
            this.tbSelectedAvrgRight.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 541);
            this.Controls.Add(this.tbSelectedAvrgRight);
            this.Controls.Add(this.tbRefAvrgRight);
            this.Controls.Add(this.tbSelectedAvrgLeft);
            this.Controls.Add(this.tbRefAvrgLeft);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbVerificationRight);
            this.Controls.Add(this.bVerify);
            this.Controls.Add(this.tbVerificationLeft);
            this.Controls.Add(this.rbZNorm);
            this.Controls.Add(this.tbCostYPreProcess);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCostXPreProcess);
            this.Controls.Add(this.tbDistancePreProcess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCostY);
            this.Controls.Add(this.tbCostX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bDTW);
            this.Controls.Add(this.tbDistance);
            this.Controls.Add(this.cBoxSignatures2);
            this.Controls.Add(this.cBoxUsers2);
            this.Controls.Add(this.OkayButtonLeft);
            this.Controls.Add(this.cBoxSignatures1);
            this.Controls.Add(this.cBoxUsers1);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Signature Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.ComboBox cBoxUsers1;
        private System.Windows.Forms.ComboBox cBoxSignatures1;
        private System.Windows.Forms.Button OkayButtonLeft;
        private System.Windows.Forms.ComboBox cBoxUsers2;
        private System.Windows.Forms.ComboBox cBoxSignatures2;
        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.Button bDTW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCostX;
        private System.Windows.Forms.TextBox tbCostY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDistancePreProcess;
        private System.Windows.Forms.TextBox tbCostXPreProcess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCostYPreProcess;
        private System.Windows.Forms.RadioButton rbZNorm;
        private System.Windows.Forms.TextBox tbVerificationLeft;
        private System.Windows.Forms.Button bVerify;
        private System.Windows.Forms.TextBox tbVerificationRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRefAvrgLeft;
        private System.Windows.Forms.TextBox tbSelectedAvrgLeft;
        private System.Windows.Forms.TextBox tbRefAvrgRight;
        private System.Windows.Forms.TextBox tbSelectedAvrgRight;
    }
}

