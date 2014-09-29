namespace QueeManagementApp
{
    partial class QueueCustomarUi
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.enqueueButton = new System.Windows.Forms.Button();
            this.enqueueComplainTextBox = new System.Windows.Forms.TextBox();
            this.enqueueNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dequeueNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dequeueSerialNoTextBox = new System.Windows.Forms.TextBox();
            this.dequeueButton = new System.Windows.Forms.Button();
            this.dequeueComplainTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.waitingQueueListView = new System.Windows.Forms.ListView();
            this.serialNoColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.complainColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.enqueueButton);
            this.groupBox1.Controls.Add(this.enqueueComplainTextBox);
            this.groupBox1.Controls.Add(this.enqueueNameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enqueue Customar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Complain";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // enqueueButton
            // 
            this.enqueueButton.Location = new System.Drawing.Point(95, 105);
            this.enqueueButton.Name = "enqueueButton";
            this.enqueueButton.Size = new System.Drawing.Size(137, 29);
            this.enqueueButton.TabIndex = 2;
            this.enqueueButton.Text = "Enqueue";
            this.enqueueButton.UseVisualStyleBackColor = true;
            this.enqueueButton.Click += new System.EventHandler(this.enqueueButton_Click);
            // 
            // enqueueComplainTextBox
            // 
            this.enqueueComplainTextBox.Location = new System.Drawing.Point(95, 69);
            this.enqueueComplainTextBox.Name = "enqueueComplainTextBox";
            this.enqueueComplainTextBox.Size = new System.Drawing.Size(243, 20);
            this.enqueueComplainTextBox.TabIndex = 1;
            // 
            // enqueueNameTextBox
            // 
            this.enqueueNameTextBox.Location = new System.Drawing.Point(95, 26);
            this.enqueueNameTextBox.Name = "enqueueNameTextBox";
            this.enqueueNameTextBox.Size = new System.Drawing.Size(137, 20);
            this.enqueueNameTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dequeueNameTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dequeueSerialNoTextBox);
            this.groupBox2.Controls.Add(this.dequeueButton);
            this.groupBox2.Controls.Add(this.dequeueComplainTextBox);
            this.groupBox2.Location = new System.Drawing.Point(385, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dequeue Customar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Name";
            // 
            // dequeueNameTextBox
            // 
            this.dequeueNameTextBox.Location = new System.Drawing.Point(96, 69);
            this.dequeueNameTextBox.Name = "dequeueNameTextBox";
            this.dequeueNameTextBox.Size = new System.Drawing.Size(187, 20);
            this.dequeueNameTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Complain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Serial No";
            // 
            // dequeueSerialNoTextBox
            // 
            this.dequeueSerialNoTextBox.Location = new System.Drawing.Point(96, 31);
            this.dequeueSerialNoTextBox.Name = "dequeueSerialNoTextBox";
            this.dequeueSerialNoTextBox.Size = new System.Drawing.Size(83, 20);
            this.dequeueSerialNoTextBox.TabIndex = 1;
            // 
            // dequeueButton
            // 
            this.dequeueButton.Location = new System.Drawing.Point(214, 28);
            this.dequeueButton.Name = "dequeueButton";
            this.dequeueButton.Size = new System.Drawing.Size(125, 29);
            this.dequeueButton.TabIndex = 0;
            this.dequeueButton.Text = "Dequeue";
            this.dequeueButton.UseVisualStyleBackColor = true;
            this.dequeueButton.Click += new System.EventHandler(this.dequeueButton_Click);
            // 
            // dequeueComplainTextBox
            // 
            this.dequeueComplainTextBox.Location = new System.Drawing.Point(96, 105);
            this.dequeueComplainTextBox.Name = "dequeueComplainTextBox";
            this.dequeueComplainTextBox.Size = new System.Drawing.Size(243, 20);
            this.dequeueComplainTextBox.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.waitingQueueListView);
            this.groupBox3.Location = new System.Drawing.Point(12, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(736, 306);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Waiting Queue";
            // 
            // waitingQueueListView
            // 
            this.waitingQueueListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serialNoColumnHeader,
            this.nameColumnHeader,
            this.complainColumnHeader});
            this.waitingQueueListView.GridLines = true;
            this.waitingQueueListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.waitingQueueListView.Location = new System.Drawing.Point(22, 26);
            this.waitingQueueListView.Name = "waitingQueueListView";
            this.waitingQueueListView.Size = new System.Drawing.Size(689, 268);
            this.waitingQueueListView.TabIndex = 0;
            this.waitingQueueListView.UseCompatibleStateImageBehavior = false;
            this.waitingQueueListView.View = System.Windows.Forms.View.Details;
            // 
            // serialNoColumnHeader
            // 
            this.serialNoColumnHeader.Text = "Serial No";
            this.serialNoColumnHeader.Width = 69;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 207;
            // 
            // complainColumnHeader
            // 
            this.complainColumnHeader.Text = "Complain";
            this.complainColumnHeader.Width = 504;
            // 
            // QueueCustomarUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 522);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QueueCustomarUi";
            this.Text = "Queue Customar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button enqueueButton;
        private System.Windows.Forms.TextBox enqueueComplainTextBox;
        private System.Windows.Forms.TextBox enqueueNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dequeueNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dequeueSerialNoTextBox;
        private System.Windows.Forms.Button dequeueButton;
        private System.Windows.Forms.TextBox dequeueComplainTextBox;
        private System.Windows.Forms.ListView waitingQueueListView;
        private System.Windows.Forms.ColumnHeader serialNoColumnHeader;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader complainColumnHeader;
    }
}

