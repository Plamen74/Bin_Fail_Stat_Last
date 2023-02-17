namespace WindowsApplication8
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
            this.components = new System.ComponentModel.Container();
            this.bins_clb = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.status_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.numoffails_lb = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lowlimit_lb = new System.Windows.Forms.ListBox();
            this.hilimit_lb = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.offset_tb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numoftestedparts_tb = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.r_limit_tb = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bins_clb
            // 
            this.bins_clb.CheckOnClick = true;
            this.bins_clb.FormattingEnabled = true;
            this.bins_clb.HorizontalScrollbar = true;
            this.bins_clb.Location = new System.Drawing.Point(12, 35);
            this.bins_clb.Name = "bins_clb";
            this.bins_clb.Size = new System.Drawing.Size(103, 559);
            this.bins_clb.TabIndex = 4;
            this.bins_clb.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lime;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "BINs ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(940, 679);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // status_tb
            // 
            this.status_tb.Enabled = false;
            this.status_tb.Location = new System.Drawing.Point(943, 37);
            this.status_tb.Name = "status_tb";
            this.status_tb.Size = new System.Drawing.Size(106, 20);
            this.status_tb.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Lime;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(999, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "STATUS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(924, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Browse Log File";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(580, 679);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lime;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(146, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "FAILS under Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Lime;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(264, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "FAILS up to MAX";
            // 
            // listBox1
            // 
            this.listBox1.DisplayMember = "-";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(147, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(100, 563);
            this.listBox1.TabIndex = 29;
            this.listBox1.ValueMember = "-";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(266, 35);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(92, 563);
            this.listBox2.TabIndex = 30;
            // 
            // numoffails_lb
            // 
            this.numoffails_lb.FormattingEnabled = true;
            this.numoffails_lb.Location = new System.Drawing.Point(588, 37);
            this.numoffails_lb.Name = "numoffails_lb";
            this.numoffails_lb.ScrollAlwaysVisible = true;
            this.numoffails_lb.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.numoffails_lb.Size = new System.Drawing.Size(67, 563);
            this.numoffails_lb.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Lime;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(585, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 26);
            this.label6.TabIndex = 33;
            this.label6.Text = "Number Of \r\nFails min,max";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Lime;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(970, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 26);
            this.label7.TabIndex = 34;
            this.label7.Text = "Number Of \r\nTested Parts";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(927, 431);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 35;
            this.button4.Text = "START";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lowlimit_lb
            // 
            this.lowlimit_lb.FormattingEnabled = true;
            this.lowlimit_lb.HorizontalScrollbar = true;
            this.lowlimit_lb.Location = new System.Drawing.Point(377, 37);
            this.lowlimit_lb.Name = "lowlimit_lb";
            this.lowlimit_lb.ScrollAlwaysVisible = true;
            this.lowlimit_lb.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lowlimit_lb.Size = new System.Drawing.Size(85, 563);
            this.lowlimit_lb.TabIndex = 36;
            // 
            // hilimit_lb
            // 
            this.hilimit_lb.FormattingEnabled = true;
            this.hilimit_lb.HorizontalScrollbar = true;
            this.hilimit_lb.Location = new System.Drawing.Point(477, 37);
            this.hilimit_lb.Name = "hilimit_lb";
            this.hilimit_lb.ScrollAlwaysVisible = true;
            this.hilimit_lb.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.hilimit_lb.Size = new System.Drawing.Size(87, 563);
            this.hilimit_lb.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Lime;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(421, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Low Limit";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Lime;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(494, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Hi Limit";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button5.Location = new System.Drawing.Point(927, 303);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 25);
            this.button5.TabIndex = 40;
            this.button5.Text = "OPEN";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // offset_tb
            // 
            this.offset_tb.Location = new System.Drawing.Point(703, 149);
            this.offset_tb.Name = "offset_tb";
            this.offset_tb.Size = new System.Drawing.Size(37, 20);
            this.offset_tb.TabIndex = 42;
            this.offset_tb.Text = "4";
            this.offset_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Lime;
            this.label12.Location = new System.Drawing.Point(697, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "First Bin Offset";
            // 
            // numoftestedparts_tb
            // 
            this.numoftestedparts_tb.Location = new System.Drawing.Point(967, 123);
            this.numoftestedparts_tb.Name = "numoftestedparts_tb";
            this.numoftestedparts_tb.Size = new System.Drawing.Size(82, 20);
            this.numoftestedparts_tb.TabIndex = 46;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Lime;
            this.label15.Location = new System.Drawing.Point(924, 406);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "Process Single File";
            // 
            // r_limit_tb
            // 
            this.r_limit_tb.Location = new System.Drawing.Point(703, 46);
            this.r_limit_tb.Name = "r_limit_tb";
            this.r_limit_tb.Size = new System.Drawing.Size(100, 20);
            this.r_limit_tb.TabIndex = 60;
            this.r_limit_tb.Text = "100";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Lime;
            this.label19.Location = new System.Drawing.Point(697, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(158, 13);
            this.label19.TabIndex = 61;
            this.label19.Text = "R low  limit for leakage test,Ohm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 748);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.r_limit_tb);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numoftestedparts_tb);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.offset_tb);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.hilimit_lb);
            this.Controls.Add(this.lowlimit_lb);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numoffails_lb);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.status_tb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bins_clb);
            this.Name = "Form1";
            this.Text = "FAILED BIN STATISTICS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox bins_clb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox status_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox numoffails_lb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox lowlimit_lb;
        private System.Windows.Forms.ListBox hilimit_lb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox offset_tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox numoftestedparts_tb;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox r_limit_tb;
        private System.Windows.Forms.Label label19;
    }
}

