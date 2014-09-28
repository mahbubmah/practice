namespace Daily_Expense
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.particularTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.catagoryComboBox = new System.Windows.Forms.ComboBox();
            this.catagoryComboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.catagorywiseListView = new System.Windows.Forms.ListView();
            this.totalTextBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.showButton2 = new System.Windows.Forms.Button();
            this.maximumTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Daily Expense Entry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ammount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Particular";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "View Summary";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Expense";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Maximum Expense";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(185, 69);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 7;
            this.amountTextBox.TextChanged += new System.EventHandler(this.amountTextBox_TextChanged);
            // 
            // particularTextBox
            // 
            this.particularTextBox.Location = new System.Drawing.Point(185, 160);
            this.particularTextBox.Name = "particularTextBox";
            this.particularTextBox.Size = new System.Drawing.Size(100, 20);
            this.particularTextBox.TabIndex = 11;
            this.particularTextBox.TextChanged += new System.EventHandler(this.particularTextBox_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(334, 160);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(334, 232);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 13;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // catagoryComboBox
            // 
            this.catagoryComboBox.FormattingEnabled = true;
            this.catagoryComboBox.Items.AddRange(new object[] {
            "Paper Bill",
            "Treat Bill",
            "Utility Bill",
            "Hotel Rent"});
            this.catagoryComboBox.Location = new System.Drawing.Point(185, 117);
            this.catagoryComboBox.Name = "catagoryComboBox";
            this.catagoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.catagoryComboBox.TabIndex = 14;
            this.catagoryComboBox.SelectedIndexChanged += new System.EventHandler(this.catagoryComboBox_SelectedIndexChanged);
            // 
            // catagoryComboBox1
            // 
            this.catagoryComboBox1.FormattingEnabled = true;
            this.catagoryComboBox1.Location = new System.Drawing.Point(779, 82);
            this.catagoryComboBox1.Name = "catagoryComboBox1";
            this.catagoryComboBox1.Size = new System.Drawing.Size(121, 21);
            this.catagoryComboBox1.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(704, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Category";
            // 
            // catagorywiseListView
            // 
            this.catagorywiseListView.Location = new System.Drawing.Point(779, 160);
            this.catagorywiseListView.Name = "catagorywiseListView";
            this.catagorywiseListView.Size = new System.Drawing.Size(121, 97);
            this.catagorywiseListView.TabIndex = 17;
            this.catagorywiseListView.UseCompatibleStateImageBehavior = false;
            // 
            // totalTextBox2
            // 
            this.totalTextBox2.Location = new System.Drawing.Point(779, 313);
            this.totalTextBox2.Name = "totalTextBox2";
            this.totalTextBox2.Size = new System.Drawing.Size(100, 20);
            this.totalTextBox2.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(722, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Total";
            // 
            // showButton2
            // 
            this.showButton2.Location = new System.Drawing.Point(824, 114);
            this.showButton2.Name = "showButton2";
            this.showButton2.Size = new System.Drawing.Size(75, 23);
            this.showButton2.TabIndex = 20;
            this.showButton2.Text = "Show";
            this.showButton2.UseVisualStyleBackColor = true;
            // 
            // maximumTextBox
            // 
            this.maximumTextBox.Location = new System.Drawing.Point(171, 370);
            this.maximumTextBox.Name = "maximumTextBox";
            this.maximumTextBox.Size = new System.Drawing.Size(100, 20);
            this.maximumTextBox.TabIndex = 10;
            this.maximumTextBox.TextChanged += new System.EventHandler(this.maximumTextBox_TextChanged);
            // 
            // totalTextBox
            // 
            this.totalTextBox.Location = new System.Drawing.Point(171, 327);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalTextBox.TabIndex = 9;
            this.totalTextBox.TextChanged += new System.EventHandler(this.totalTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 460);
            this.Controls.Add(this.showButton2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.totalTextBox2);
            this.Controls.Add(this.catagorywiseListView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.catagoryComboBox1);
            this.Controls.Add(this.catagoryComboBox);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.particularTextBox);
            this.Controls.Add(this.maximumTextBox);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox particularTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.ComboBox catagoryComboBox;
        private System.Windows.Forms.ComboBox catagoryComboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView catagorywiseListView;
        private System.Windows.Forms.TextBox totalTextBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button showButton2;
        private System.Windows.Forms.TextBox maximumTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
    }
}

