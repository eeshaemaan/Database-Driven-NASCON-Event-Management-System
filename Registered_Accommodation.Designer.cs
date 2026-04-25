namespace WindowsFormsApp1
{
    partial class Registered_Accommodation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registered_Accommodation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Total_Cost_Label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.check_out_date = new System.Windows.Forms.Label();
            this.check_in_date = new System.Windows.Forms.Label();
            this.room_type_label = new System.Windows.Forms.Label();
            this.room_name_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(981, 57);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(72, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nascon";
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
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.label_EventOrg_ID);
            this.groupBox1.Controls.Add(this.Total_Cost_Label);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.check_out_date);
            this.groupBox1.Controls.Add(this.check_in_date);
            this.groupBox1.Controls.Add(this.room_type_label);
            this.groupBox1.Controls.Add(this.room_name_label);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Lucida Calligraphy", 16.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(0, 57);
            this.groupBox1.MinimumSize = new System.Drawing.Size(1016, 643);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 643);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Accommodation";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Total_Cost_Label
            // 
            this.Total_Cost_Label.AutoSize = true;
            this.Total_Cost_Label.BackColor = System.Drawing.Color.Transparent;
            this.Total_Cost_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Total_Cost_Label.Location = new System.Drawing.Point(534, 541);
            this.Total_Cost_Label.Name = "Total_Cost_Label";
            this.Total_Cost_Label.Size = new System.Drawing.Size(44, 25);
            this.Total_Cost_Label.TabIndex = 45;
            this.Total_Cost_Label.Text = "----";
            this.Total_Cost_Label.Click += new System.EventHandler(this.Total_Cost_Label_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(119, 541);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 31);
            this.label9.TabIndex = 44;
            this.label9.Text = "Total Cost";
            // 
            // check_out_date
            // 
            this.check_out_date.AutoSize = true;
            this.check_out_date.BackColor = System.Drawing.Color.Transparent;
            this.check_out_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.check_out_date.Location = new System.Drawing.Point(534, 219);
            this.check_out_date.Name = "check_out_date";
            this.check_out_date.Size = new System.Drawing.Size(44, 25);
            this.check_out_date.TabIndex = 43;
            this.check_out_date.Text = "----";
            this.check_out_date.Click += new System.EventHandler(this.check_out_date_Click);
            // 
            // check_in_date
            // 
            this.check_in_date.AutoSize = true;
            this.check_in_date.BackColor = System.Drawing.Color.Transparent;
            this.check_in_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.check_in_date.Location = new System.Drawing.Point(534, 114);
            this.check_in_date.Name = "check_in_date";
            this.check_in_date.Size = new System.Drawing.Size(44, 25);
            this.check_in_date.TabIndex = 42;
            this.check_in_date.Text = "----";
            this.check_in_date.Click += new System.EventHandler(this.check_in_date_Click);
            // 
            // room_type_label
            // 
            this.room_type_label.AutoSize = true;
            this.room_type_label.BackColor = System.Drawing.Color.Transparent;
            this.room_type_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.room_type_label.Location = new System.Drawing.Point(534, 426);
            this.room_type_label.Name = "room_type_label";
            this.room_type_label.Size = new System.Drawing.Size(44, 25);
            this.room_type_label.TabIndex = 41;
            this.room_type_label.Text = "----";
            this.room_type_label.Click += new System.EventHandler(this.room_type_label_Click);
            // 
            // room_name_label
            // 
            this.room_name_label.AutoSize = true;
            this.room_name_label.BackColor = System.Drawing.Color.Transparent;
            this.room_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.room_name_label.Location = new System.Drawing.Point(534, 324);
            this.room_name_label.Name = "room_name_label";
            this.room_name_label.Size = new System.Drawing.Size(44, 25);
            this.room_name_label.TabIndex = 40;
            this.room_name_label.Text = "----";
            this.room_name_label.Click += new System.EventHandler(this.room_name_label_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(119, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 31);
            this.label5.TabIndex = 39;
            this.label5.Text = "Room Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(119, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 31);
            this.label4.TabIndex = 38;
            this.label4.Text = "Room Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(119, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 31);
            this.label8.TabIndex = 30;
            this.label8.Text = "Check-Out Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(119, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 31);
            this.label2.TabIndex = 27;
            this.label2.Text = "Check-In Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_EventOrg_ID
            // 
            this.label_EventOrg_ID.AutoSize = true;
            this.label_EventOrg_ID.BackColor = System.Drawing.Color.Transparent;
            this.label_EventOrg_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label_EventOrg_ID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_EventOrg_ID.Location = new System.Drawing.Point(905, 21);
            this.label_EventOrg_ID.Name = "label_EventOrg_ID";
            this.label_EventOrg_ID.Size = new System.Drawing.Size(44, 25);
            this.label_EventOrg_ID.TabIndex = 28;
            this.label_EventOrg_ID.Text = "----";
            this.label_EventOrg_ID.Click += new System.EventHandler(this.label_EventOrg_ID_Click);
            // 
            // Registered_Accommodation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 648);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Registered_Accommodation";
            this.Text = "Registered_Accommodation";
            this.Load += new System.EventHandler(this.Registered_Accommodation_Load);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label check_out_date;
        private System.Windows.Forms.Label check_in_date;
        private System.Windows.Forms.Label room_type_label;
        private System.Windows.Forms.Label room_name_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Total_Cost_Label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_EventOrg_ID;
    }
}