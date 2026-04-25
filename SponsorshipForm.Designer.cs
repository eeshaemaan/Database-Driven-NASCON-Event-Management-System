namespace WindowsFormsApp1
{
    partial class SponsorshipForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_CompanyName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Category = new System.Windows.Forms.Label();
            this.label_UserId = new System.Windows.Forms.Label();
            this.textBox_CompanyName = new System.Windows.Forms.TextBox();
            this.textBox_EventId = new System.Windows.Forms.TextBox();
            this.textBox_UserId = new System.Windows.Forms.TextBox();
            this.comboBox_Category = new System.Windows.Forms.ComboBox();
            this.label_EventId = new System.Windows.Forms.Label();
            this.label_EventOrgId = new System.Windows.Forms.Label();
            this.textBox_EventOrgId = new System.Windows.Forms.TextBox();
            this.label_Amount = new System.Windows.Forms.Label();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.button_Submit = new System.Windows.Forms.Button();
            this.button_MakePayment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(72, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nascon";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_CompanyName
            // 
            this.label_CompanyName.AutoSize = true;
            this.label_CompanyName.BackColor = System.Drawing.Color.Transparent;
            this.label_CompanyName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_CompanyName.Location = new System.Drawing.Point(78, 189);
            this.label_CompanyName.Name = "label_CompanyName";
            this.label_CompanyName.Size = new System.Drawing.Size(167, 28);
            this.label_CompanyName.TabIndex = 3;
            this.label_CompanyName.Text = "Company Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(357, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sponsorship";
            // 
            // label_Category
            // 
            this.label_Category.AutoSize = true;
            this.label_Category.BackColor = System.Drawing.Color.Transparent;
            this.label_Category.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_Category.Location = new System.Drawing.Point(78, 250);
            this.label_Category.Name = "label_Category";
            this.label_Category.Size = new System.Drawing.Size(103, 28);
            this.label_Category.TabIndex = 5;
            this.label_Category.Text = "Category:";
            // 
            // label_UserId
            // 
            this.label_UserId.AutoSize = true;
            this.label_UserId.BackColor = System.Drawing.Color.Transparent;
            this.label_UserId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_UserId.Location = new System.Drawing.Point(78, 304);
            this.label_UserId.Name = "label_UserId";
            this.label_UserId.Size = new System.Drawing.Size(86, 28);
            this.label_UserId.TabIndex = 6;
            this.label_UserId.Text = "User ID:";
            // 
            // textBox_CompanyName
            // 
            this.textBox_CompanyName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_CompanyName.Location = new System.Drawing.Point(335, 190);
            this.textBox_CompanyName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_CompanyName.Name = "textBox_CompanyName";
            this.textBox_CompanyName.Size = new System.Drawing.Size(448, 34);
            this.textBox_CompanyName.TabIndex = 7;
            // 
            // textBox_EventId
            // 
            this.textBox_EventId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_EventId.Location = new System.Drawing.Point(335, 364);
            this.textBox_EventId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_EventId.Name = "textBox_EventId";
            this.textBox_EventId.Size = new System.Drawing.Size(448, 34);
            this.textBox_EventId.TabIndex = 8;
            // 
            // textBox_UserId
            // 
            this.textBox_UserId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_UserId.Location = new System.Drawing.Point(335, 305);
            this.textBox_UserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_UserId.Name = "textBox_UserId";
            this.textBox_UserId.Size = new System.Drawing.Size(448, 34);
            this.textBox_UserId.TabIndex = 9;
            // 
            // comboBox_Category
            // 
            this.comboBox_Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox_Category.FormattingEnabled = true;
            this.comboBox_Category.Location = new System.Drawing.Point(335, 248);
            this.comboBox_Category.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Category.Name = "comboBox_Category";
            this.comboBox_Category.Size = new System.Drawing.Size(448, 33);
            this.comboBox_Category.TabIndex = 10;
            this.comboBox_Category.SelectedIndexChanged += new System.EventHandler(this.comboBox_Category_SelectedIndexChanged);
            // 
            // label_EventId
            // 
            this.label_EventId.AutoSize = true;
            this.label_EventId.BackColor = System.Drawing.Color.Transparent;
            this.label_EventId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_EventId.Location = new System.Drawing.Point(78, 365);
            this.label_EventId.Name = "label_EventId";
            this.label_EventId.Size = new System.Drawing.Size(97, 28);
            this.label_EventId.TabIndex = 12;
            this.label_EventId.Text = "Event ID:";
            // 
            // label_EventOrgId
            // 
            this.label_EventOrgId.AutoSize = true;
            this.label_EventOrgId.BackColor = System.Drawing.Color.Transparent;
            this.label_EventOrgId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_EventOrgId.Location = new System.Drawing.Point(78, 430);
            this.label_EventOrgId.Name = "label_EventOrgId";
            this.label_EventOrgId.Size = new System.Drawing.Size(196, 28);
            this.label_EventOrgId.TabIndex = 13;
            this.label_EventOrgId.Text = "Event Organizer ID:";
            // 
            // textBox_EventOrgId
            // 
            this.textBox_EventOrgId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_EventOrgId.Location = new System.Drawing.Point(335, 430);
            this.textBox_EventOrgId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_EventOrgId.Name = "textBox_EventOrgId";
            this.textBox_EventOrgId.Size = new System.Drawing.Size(448, 34);
            this.textBox_EventOrgId.TabIndex = 14;
            // 
            // label_Amount
            // 
            this.label_Amount.AutoSize = true;
            this.label_Amount.BackColor = System.Drawing.Color.Transparent;
            this.label_Amount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_Amount.Location = new System.Drawing.Point(78, 490);
            this.label_Amount.Name = "label_Amount";
            this.label_Amount.Size = new System.Drawing.Size(140, 28);
            this.label_Amount.TabIndex = 15;
            this.label_Amount.Text = "Amount Paid:";
            // 
            // textBox_Amount
            // 
            this.textBox_Amount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_Amount.Location = new System.Drawing.Point(335, 490);
            this.textBox_Amount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Amount.Name = "textBox_Amount";
            this.textBox_Amount.Size = new System.Drawing.Size(448, 34);
            this.textBox_Amount.TabIndex = 16;
            // 
            // button_Submit
            // 
            this.button_Submit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Submit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.button_Submit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Submit.Location = new System.Drawing.Point(396, 608);
            this.button_Submit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Submit.Name = "button_Submit";
            this.button_Submit.Size = new System.Drawing.Size(206, 57);
            this.button_Submit.TabIndex = 17;
            this.button_Submit.Text = "Submit Sponsorship";
            this.button_Submit.UseVisualStyleBackColor = false;
            this.button_Submit.Click += new System.EventHandler(this.button_Submit_Click);
            // 
            // button_MakePayment
            // 
            this.button_MakePayment.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_MakePayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.button_MakePayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_MakePayment.Location = new System.Drawing.Point(831, 490);
            this.button_MakePayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_MakePayment.Name = "button_MakePayment";
            this.button_MakePayment.Size = new System.Drawing.Size(158, 41);
            this.button_MakePayment.TabIndex = 18;
            this.button_MakePayment.Text = "Pay Now";
            this.button_MakePayment.UseVisualStyleBackColor = false;
            this.button_MakePayment.Click += new System.EventHandler(this.button_MakePayment_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(75, 551);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 28);
            this.label3.TabIndex = 19;
            this.label3.Text = "Payment Status:";
            // 
            // statusTextBox
            // 
            this.statusTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.statusTextBox.Location = new System.Drawing.Point(335, 551);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(448, 34);
            this.statusTextBox.TabIndex = 20;
            // 
            // SponsorshipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Backgrounf_Img;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1016, 700);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_MakePayment);
            this.Controls.Add(this.button_Submit);
            this.Controls.Add(this.textBox_Amount);
            this.Controls.Add(this.label_Amount);
            this.Controls.Add(this.textBox_EventOrgId);
            this.Controls.Add(this.label_EventOrgId);
            this.Controls.Add(this.label_EventId);
            this.Controls.Add(this.comboBox_Category);
            this.Controls.Add(this.textBox_UserId);
            this.Controls.Add(this.textBox_EventId);
            this.Controls.Add(this.textBox_CompanyName);
            this.Controls.Add(this.label_UserId);
            this.Controls.Add(this.label_Category);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_CompanyName);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SponsorshipForm";
            this.Text = "SponsorshipForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_CompanyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Category;
        private System.Windows.Forms.Label label_UserId;
        private System.Windows.Forms.TextBox textBox_CompanyName;
        private System.Windows.Forms.TextBox textBox_EventId;
        private System.Windows.Forms.TextBox textBox_UserId;
        private System.Windows.Forms.ComboBox comboBox_Category;
        private System.Windows.Forms.Label label_EventId;
        private System.Windows.Forms.Label label_EventOrgId;
        private System.Windows.Forms.TextBox textBox_EventOrgId;
        private System.Windows.Forms.Label label_Amount;
        private System.Windows.Forms.TextBox textBox_Amount;
        private System.Windows.Forms.Button button_Submit;
        private System.Windows.Forms.Button button_MakePayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox statusTextBox;
    }
}