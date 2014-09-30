namespace VehicleApp
{
    partial class VehicleUI
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
            this.label7 = new System.Windows.Forms.Label();
            this.averageSpeedTextBox = new System.Windows.Forms.TextBox();
            this.regNoTextBox = new System.Windows.Forms.TextBox();
            this.currentSpeedTextBox = new System.Windows.Forms.TextBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.minSpeedTextBox = new System.Windows.Forms.TextBox();
            this.nametTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.setCurrentSpeed = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Kilo/Hr";
            // 
            // averageSpeedTextBox
            // 
            this.averageSpeedTextBox.Location = new System.Drawing.Point(108, 199);
            this.averageSpeedTextBox.Name = "averageSpeedTextBox";
            this.averageSpeedTextBox.Size = new System.Drawing.Size(182, 20);
            this.averageSpeedTextBox.TabIndex = 24;
            // 
            // regNoTextBox
            // 
            this.regNoTextBox.Location = new System.Drawing.Point(108, 39);
            this.regNoTextBox.Name = "regNoTextBox";
            this.regNoTextBox.Size = new System.Drawing.Size(182, 20);
            this.regNoTextBox.TabIndex = 10;
            // 
            // currentSpeedTextBox
            // 
            this.currentSpeedTextBox.Location = new System.Drawing.Point(108, 93);
            this.currentSpeedTextBox.Name = "currentSpeedTextBox";
            this.currentSpeedTextBox.Size = new System.Drawing.Size(136, 20);
            this.currentSpeedTextBox.TabIndex = 18;
            // 
            // maxTextBox
            // 
            this.maxTextBox.Location = new System.Drawing.Point(108, 173);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(182, 20);
            this.maxTextBox.TabIndex = 23;
            // 
            // minSpeedTextBox
            // 
            this.minSpeedTextBox.Location = new System.Drawing.Point(108, 145);
            this.minSpeedTextBox.Name = "minSpeedTextBox";
            this.minSpeedTextBox.Size = new System.Drawing.Size(182, 20);
            this.minSpeedTextBox.TabIndex = 22;
            // 
            // nametTextBox
            // 
            this.nametTextBox.Location = new System.Drawing.Point(108, 12);
            this.nametTextBox.Name = "nametTextBox";
            this.nametTextBox.Size = new System.Drawing.Size(182, 20);
            this.nametTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Average Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Max Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Reg No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Speed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Min Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Vehicle Name";
            // 
            // setCurrentSpeed
            // 
            this.setCurrentSpeed.Location = new System.Drawing.Point(296, 91);
            this.setCurrentSpeed.Name = "setCurrentSpeed";
            this.setCurrentSpeed.Size = new System.Drawing.Size(75, 23);
            this.setCurrentSpeed.TabIndex = 20;
            this.setCurrentSpeed.Text = "Enter";
            this.setCurrentSpeed.UseVisualStyleBackColor = true;
            this.setCurrentSpeed.Click += new System.EventHandler(this.setCurrentSpeed_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(296, 173);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 21;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(296, 37);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 17;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // VehicleUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 246);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.averageSpeedTextBox);
            this.Controls.Add(this.regNoTextBox);
            this.Controls.Add(this.currentSpeedTextBox);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.minSpeedTextBox);
            this.Controls.Add(this.nametTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setCurrentSpeed);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.createButton);
            this.Name = "VehicleUI";
            this.Text = "VehicleUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox averageSpeedTextBox;
        private System.Windows.Forms.TextBox regNoTextBox;
        private System.Windows.Forms.TextBox currentSpeedTextBox;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.TextBox minSpeedTextBox;
        private System.Windows.Forms.TextBox nametTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setCurrentSpeed;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button createButton;
    }
}

