namespace CalculatorOopApp
{
    partial class CalculatorUi
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
            this.additionBoutton = new System.Windows.Forms.Button();
            this.subtructionButton = new System.Windows.Forms.Button();
            this.multiplicationButton = new System.Windows.Forms.Button();
            this.divisionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.firstNumberTextBox = new System.Windows.Forms.TextBox();
            this.lastNumberTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // additionBoutton
            // 
            this.additionBoutton.Location = new System.Drawing.Point(12, 173);
            this.additionBoutton.Name = "additionBoutton";
            this.additionBoutton.Size = new System.Drawing.Size(93, 30);
            this.additionBoutton.TabIndex = 0;
            this.additionBoutton.Text = "Add";
            this.additionBoutton.UseVisualStyleBackColor = true;
            this.additionBoutton.Click += new System.EventHandler(this.additionBoutton_Click);
            // 
            // subtructionButton
            // 
            this.subtructionButton.Location = new System.Drawing.Point(111, 173);
            this.subtructionButton.Name = "subtructionButton";
            this.subtructionButton.Size = new System.Drawing.Size(93, 30);
            this.subtructionButton.TabIndex = 0;
            this.subtructionButton.Text = "Sub";
            this.subtructionButton.UseVisualStyleBackColor = true;
            this.subtructionButton.Click += new System.EventHandler(this.subtructionButton_Click);
            // 
            // multiplicationButton
            // 
            this.multiplicationButton.Location = new System.Drawing.Point(210, 173);
            this.multiplicationButton.Name = "multiplicationButton";
            this.multiplicationButton.Size = new System.Drawing.Size(93, 30);
            this.multiplicationButton.TabIndex = 0;
            this.multiplicationButton.Text = "Multiple";
            this.multiplicationButton.UseVisualStyleBackColor = true;
            this.multiplicationButton.Click += new System.EventHandler(this.multiplicationButton_Click);
            // 
            // divisionButton
            // 
            this.divisionButton.Location = new System.Drawing.Point(309, 173);
            this.divisionButton.Name = "divisionButton";
            this.divisionButton.Size = new System.Drawing.Size(93, 30);
            this.divisionButton.TabIndex = 0;
            this.divisionButton.Text = "Div";
            this.divisionButton.UseVisualStyleBackColor = true;
            this.divisionButton.Click += new System.EventHandler(this.divisionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Result";
            // 
            // firstNumberTextBox
            // 
            this.firstNumberTextBox.Location = new System.Drawing.Point(136, 37);
            this.firstNumberTextBox.Name = "firstNumberTextBox";
            this.firstNumberTextBox.Size = new System.Drawing.Size(266, 20);
            this.firstNumberTextBox.TabIndex = 2;
            // 
            // lastNumberTextBox
            // 
            this.lastNumberTextBox.Location = new System.Drawing.Point(137, 85);
            this.lastNumberTextBox.Name = "lastNumberTextBox";
            this.lastNumberTextBox.Size = new System.Drawing.Size(265, 20);
            this.lastNumberTextBox.TabIndex = 2;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(136, 126);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(266, 20);
            this.resultTextBox.TabIndex = 2;
            // 
            // CalculatorUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 215);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.lastNumberTextBox);
            this.Controls.Add(this.firstNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.divisionButton);
            this.Controls.Add(this.subtructionButton);
            this.Controls.Add(this.multiplicationButton);
            this.Controls.Add(this.additionBoutton);
            this.Name = "CalculatorUi";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button additionBoutton;
        private System.Windows.Forms.Button subtructionButton;
        private System.Windows.Forms.Button multiplicationButton;
        private System.Windows.Forms.Button divisionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox firstNumberTextBox;
        private System.Windows.Forms.TextBox lastNumberTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

