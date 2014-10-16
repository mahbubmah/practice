namespace ShopAppDB
{
    partial class ShopUI
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
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxShopName = new System.Windows.Forms.TextBox();
            this.textBoxShopAddress = new System.Windows.Forms.TextBox();
            this.textBoxProductID = new System.Windows.Forms.TextBox();
            this.textBoxItemQTY = new System.Windows.Forms.TextBox();
            this.saveShopButton = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.showDetailButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shop Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quantity";
            // 
            // textBoxShopName
            // 
            this.textBoxShopName.Location = new System.Drawing.Point(112, 9);
            this.textBoxShopName.Name = "textBoxShopName";
            this.textBoxShopName.Size = new System.Drawing.Size(170, 20);
            this.textBoxShopName.TabIndex = 5;
            // 
            // textBoxShopAddress
            // 
            this.textBoxShopAddress.Location = new System.Drawing.Point(112, 35);
            this.textBoxShopAddress.Name = "textBoxShopAddress";
            this.textBoxShopAddress.Size = new System.Drawing.Size(170, 20);
            this.textBoxShopAddress.TabIndex = 6;
            // 
            // textBoxProductID
            // 
            this.textBoxProductID.Location = new System.Drawing.Point(112, 62);
            this.textBoxProductID.Name = "textBoxProductID";
            this.textBoxProductID.Size = new System.Drawing.Size(100, 20);
            this.textBoxProductID.TabIndex = 7;
            // 
            // textBoxItemQTY
            // 
            this.textBoxItemQTY.Location = new System.Drawing.Point(112, 88);
            this.textBoxItemQTY.Name = "textBoxItemQTY";
            this.textBoxItemQTY.Size = new System.Drawing.Size(100, 20);
            this.textBoxItemQTY.TabIndex = 9;
            // 
            // saveShopButton
            // 
            this.saveShopButton.Location = new System.Drawing.Point(288, 9);
            this.saveShopButton.Name = "saveShopButton";
            this.saveShopButton.Size = new System.Drawing.Size(114, 46);
            this.saveShopButton.TabIndex = 10;
            this.saveShopButton.Text = "Save Shop";
            this.saveShopButton.UseVisualStyleBackColor = true;
            this.saveShopButton.Click += new System.EventHandler(this.saveShopButton_Click);
            // 
            // addItemButton
            // 
            this.addItemButton.Location = new System.Drawing.Point(281, 62);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(121, 75);
            this.addItemButton.TabIndex = 11;
            this.addItemButton.Text = "Add Item";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // showDetailButton
            // 
            this.showDetailButton.Location = new System.Drawing.Point(112, 114);
            this.showDetailButton.Name = "showDetailButton";
            this.showDetailButton.Size = new System.Drawing.Size(170, 23);
            this.showDetailButton.TabIndex = 12;
            this.showDetailButton.Text = "Show";
            this.showDetailButton.UseVisualStyleBackColor = true;
            this.showDetailButton.Click += new System.EventHandler(this.showDetailButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(27, 155);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(375, 150);
            this.dataGridView.TabIndex = 13;
            // 
            // ShopUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 325);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.showDetailButton);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.saveShopButton);
            this.Controls.Add(this.textBoxItemQTY);
            this.Controls.Add(this.textBoxProductID);
            this.Controls.Add(this.textBoxShopAddress);
            this.Controls.Add(this.textBoxShopName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShopUI";
            this.Text = "ShopUI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxShopName;
        private System.Windows.Forms.TextBox textBoxShopAddress;
        private System.Windows.Forms.TextBox textBoxProductID;
        private System.Windows.Forms.TextBox textBoxItemQTY;
        private System.Windows.Forms.Button saveShopButton;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Button showDetailButton;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

