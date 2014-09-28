namespace WindowsFormsApplication3
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
            this.lblBankname = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.comboBoxBank = new System.Windows.Forms.ComboBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnCalculation = new System.Windows.Forms.Button();
            this.lblIntarest = new System.Windows.Forms.Label();
            this.txtIntarest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBankname
            // 
            this.lblBankname.AutoSize = true;
            this.lblBankname.Location = new System.Drawing.Point(77, 45);
            this.lblBankname.Name = "lblBankname";
            this.lblBankname.Size = new System.Drawing.Size(63, 13);
            this.lblBankname.TabIndex = 0;
            this.lblBankname.Text = "Bank Name";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(77, 129);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(67, 13);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Time(in year)";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(77, 229);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(46, 13);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "Balance";
            // 
            // comboBoxBank
            // 
            this.comboBoxBank.FormattingEnabled = true;
            this.comboBoxBank.Items.AddRange(new object[] {
            "BRAC",
            "DBBL",
            "HSBC"});
            this.comboBoxBank.Location = new System.Drawing.Point(372, 45);
            this.comboBoxBank.Name = "comboBoxBank";
            this.comboBoxBank.Size = new System.Drawing.Size(202, 21);
            this.comboBoxBank.TabIndex = 3;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(372, 122);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 4;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(372, 226);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBalance.TabIndex = 5;
            // 
            // btnCalculation
            // 
            this.btnCalculation.Location = new System.Drawing.Point(355, 316);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Size = new System.Drawing.Size(152, 30);
            this.btnCalculation.TabIndex = 6;
            this.btnCalculation.Text = "Calculation Intarest";
            this.btnCalculation.UseVisualStyleBackColor = true;
            this.btnCalculation.Click += new System.EventHandler(this.btnCalculation_Click);
            // 
            // lblIntarest
            // 
            this.lblIntarest.AutoSize = true;
            this.lblIntarest.Location = new System.Drawing.Point(77, 386);
            this.lblIntarest.Name = "lblIntarest";
            this.lblIntarest.Size = new System.Drawing.Size(48, 13);
            this.lblIntarest.TabIndex = 7;
            this.lblIntarest.Text = "Intarest=";
            // 
            // txtIntarest
            // 
            this.txtIntarest.Location = new System.Drawing.Point(372, 379);
            this.txtIntarest.Name = "txtIntarest";
            this.txtIntarest.Size = new System.Drawing.Size(100, 20);
            this.txtIntarest.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 421);
            this.Controls.Add(this.txtIntarest);
            this.Controls.Add(this.lblIntarest);
            this.Controls.Add(this.btnCalculation);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.comboBoxBank);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblBankname);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBankname;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.ComboBox comboBoxBank;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button btnCalculation;
        private System.Windows.Forms.Label lblIntarest;
        private System.Windows.Forms.TextBox txtIntarest;
    }
}

