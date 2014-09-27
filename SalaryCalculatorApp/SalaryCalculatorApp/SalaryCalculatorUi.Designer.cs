namespace SalaryCalculatorApp
{
    partial class SalaryCalculatorUi
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
            this.showSalaryButton = new System.Windows.Forms.Button();
            this.employeeNameTextBox = new System.Windows.Forms.TextBox();
            this.basicAmounTextBox = new System.Windows.Forms.TextBox();
            this.houseRentTextBox = new System.Windows.Forms.TextBox();
            this.medicalAllowanceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showSalaryButton
            // 
            this.showSalaryButton.Location = new System.Drawing.Point(154, 195);
            this.showSalaryButton.Name = "showSalaryButton";
            this.showSalaryButton.Size = new System.Drawing.Size(283, 29);
            this.showSalaryButton.TabIndex = 0;
            this.showSalaryButton.Text = "Show Me Salary";
            this.showSalaryButton.UseVisualStyleBackColor = true;
            this.showSalaryButton.Click += new System.EventHandler(this.showSalaryButton_Click);
            // 
            // employeeNameTextBox
            // 
            this.employeeNameTextBox.Location = new System.Drawing.Point(129, 24);
            this.employeeNameTextBox.Name = "employeeNameTextBox";
            this.employeeNameTextBox.Size = new System.Drawing.Size(350, 20);
            this.employeeNameTextBox.TabIndex = 1;
            // 
            // basicAmounTextBox
            // 
            this.basicAmounTextBox.Location = new System.Drawing.Point(129, 66);
            this.basicAmounTextBox.Name = "basicAmounTextBox";
            this.basicAmounTextBox.Size = new System.Drawing.Size(283, 20);
            this.basicAmounTextBox.TabIndex = 2;
            // 
            // houseRentTextBox
            // 
            this.houseRentTextBox.Location = new System.Drawing.Point(129, 110);
            this.houseRentTextBox.Name = "houseRentTextBox";
            this.houseRentTextBox.Size = new System.Drawing.Size(283, 20);
            this.houseRentTextBox.TabIndex = 2;
            // 
            // medicalAllowanceTextBox
            // 
            this.medicalAllowanceTextBox.Location = new System.Drawing.Point(129, 152);
            this.medicalAllowanceTextBox.Name = "medicalAllowanceTextBox";
            this.medicalAllowanceTextBox.Size = new System.Drawing.Size(283, 20);
            this.medicalAllowanceTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employee Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Basic Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "House Rent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Medical Allowance";
            // 
            // SalaryCalculatorUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 251);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.medicalAllowanceTextBox);
            this.Controls.Add(this.houseRentTextBox);
            this.Controls.Add(this.basicAmounTextBox);
            this.Controls.Add(this.employeeNameTextBox);
            this.Controls.Add(this.showSalaryButton);
            this.Name = "SalaryCalculatorUi";
            this.Text = "Salary Calculator";
           
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showSalaryButton;
        private System.Windows.Forms.TextBox employeeNameTextBox;
        private System.Windows.Forms.TextBox basicAmounTextBox;
        private System.Windows.Forms.TextBox houseRentTextBox;
        private System.Windows.Forms.TextBox medicalAllowanceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

