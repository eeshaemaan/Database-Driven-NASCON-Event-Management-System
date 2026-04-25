namespace WindowsFormsApp1
{
    partial class Participant_Accommodation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Participant_Accommodation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_adjust = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_budget = new System.Windows.Forms.TextBox();
            this.comboBox_room = new System.Windows.Forms.ComboBox();
            this.comboBox_check_out = new System.Windows.Forms.ComboBox();
            this.comboBox_check_in = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.submit_button = new System.Windows.Forms.Button();
            this.label_EventOrg_ID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 57);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(72, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nascon";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.label_EventOrg_ID);
            this.groupBox1.Controls.Add(this.button_adjust);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_budget);
            this.groupBox1.Controls.Add(this.comboBox_room);
            this.groupBox1.Controls.Add(this.comboBox_check_out);
            this.groupBox1.Controls.Add(this.comboBox_check_in);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.submit_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Lucida Calligraphy", 16.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(0, 57);
            this.groupBox1.MinimumSize = new System.Drawing.Size(1016, 643);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 643);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Accommodation";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button_adjust
            // 
            this.button_adjust.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_adjust.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_adjust.ForeColor = System.Drawing.SystemColors.Info;
            this.button_adjust.Location = new System.Drawing.Point(552, 541);
            this.button_adjust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_adjust.Name = "button_adjust";
            this.button_adjust.Size = new System.Drawing.Size(212, 41);
            this.button_adjust.TabIndex = 36;
            this.button_adjust.Text = "Adjust Preference";
            this.button_adjust.UseVisualStyleBackColor = false;
            this.button_adjust.Click += new System.EventHandler(this.button_adjust_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label9.Location = new System.Drawing.Point(480, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 25);
            this.label9.TabIndex = 35;
            this.label9.Text = "Enter your budget";
            // 
            // textBox_budget
            // 
            this.textBox_budget.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.textBox_budget.Location = new System.Drawing.Point(485, 455);
            this.textBox_budget.Name = "textBox_budget";
            this.textBox_budget.Size = new System.Drawing.Size(319, 34);
            this.textBox_budget.TabIndex = 34;
            // 
            // comboBox_room
            // 
            this.comboBox_room.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_room.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBox_room.FormattingEnabled = true;
            this.comboBox_room.Items.AddRange(new object[] {
            "Shared Room - 1000 per night",
            "Double Room - 2000 per night",
            "Single Room - 3000 per night"});
            this.comboBox_room.Location = new System.Drawing.Point(485, 321);
            this.comboBox_room.Name = "comboBox_room";
            this.comboBox_room.Size = new System.Drawing.Size(319, 33);
            this.comboBox_room.TabIndex = 33;
            this.comboBox_room.Text = "Select a Room Preference";
            // 
            // comboBox_check_out
            // 
            this.comboBox_check_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox_check_out.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBox_check_out.FormattingEnabled = true;
            this.comboBox_check_out.Items.AddRange(new object[] {
            "2025-05-09",
            "2025-05-10",
            "2025-05-11",
            "2025-05-12"});
            this.comboBox_check_out.Location = new System.Drawing.Point(485, 207);
            this.comboBox_check_out.Name = "comboBox_check_out";
            this.comboBox_check_out.Size = new System.Drawing.Size(319, 33);
            this.comboBox_check_out.TabIndex = 32;
            this.comboBox_check_out.Text = "Select Check-Out Date";
            // 
            // comboBox_check_in
            // 
            this.comboBox_check_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox_check_in.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBox_check_in.FormattingEnabled = true;
            this.comboBox_check_in.Items.AddRange(new object[] {
            "2025-05-08",
            "2025-05-09",
            "2025-05-10",
            "2025-05-11"});
            this.comboBox_check_in.Location = new System.Drawing.Point(485, 95);
            this.comboBox_check_in.Name = "comboBox_check_in";
            this.comboBox_check_in.Size = new System.Drawing.Size(319, 33);
            this.comboBox_check_in.TabIndex = 31;
            this.comboBox_check_in.Text = "Select Check-In Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(111, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 31);
            this.label8.TabIndex = 30;
            this.label8.Text = "Check-Out";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(111, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 31);
            this.label5.TabIndex = 29;
            this.label5.Text = "Budget";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(111, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 31);
            this.label4.TabIndex = 28;
            this.label4.Text = "Room Preference";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(111, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 31);
            this.label2.TabIndex = 27;
            this.label2.Text = "Check-In";
            // 
            // submit_button
            // 
            this.submit_button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.submit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_button.ForeColor = System.Drawing.SystemColors.Info;
            this.submit_button.Location = new System.Drawing.Point(298, 541);
            this.submit_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(212, 41);
            this.submit_button.TabIndex = 15;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = false;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click_1);
            // 
            // label_EventOrg_ID
            // 
            this.label_EventOrg_ID.AutoSize = true;
            this.label_EventOrg_ID.BackColor = System.Drawing.Color.Transparent;
            this.label_EventOrg_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label_EventOrg_ID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_EventOrg_ID.Location = new System.Drawing.Point(860, 24);
            this.label_EventOrg_ID.Name = "label_EventOrg_ID";
            this.label_EventOrg_ID.Size = new System.Drawing.Size(44, 25);
            this.label_EventOrg_ID.TabIndex = 27;
            this.label_EventOrg_ID.Text = "----";
            this.label_EventOrg_ID.Click += new System.EventHandler(this.label_EventOrg_ID_Click);
            // 
            // Participant_Accommodation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1016, 700);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Participant_Accommodation";
            this.Text = "Accomodation";
            this.Load += new System.EventHandler(this.Accomodation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_budget;
        private System.Windows.Forms.ComboBox comboBox_room;
        private System.Windows.Forms.ComboBox comboBox_check_out;
        private System.Windows.Forms.ComboBox comboBox_check_in;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_adjust;
        private System.Windows.Forms.Label label_EventOrg_ID;
    }
}