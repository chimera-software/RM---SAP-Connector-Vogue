namespace RM___SAP_Connector
{
    partial class Setup
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
            this.button1 = new System.Windows.Forms.Button();
            this.destTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.autoGenCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.branchCodeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.warehouseCodeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 73;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // destTextBox
            // 
            this.destTextBox.Location = new System.Drawing.Point(18, 274);
            this.destTextBox.Name = "destTextBox";
            this.destTextBox.Size = new System.Drawing.Size(205, 20);
            this.destTextBox.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Excel Destination Folder:";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(229, 217);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(51, 23);
            this.openButton.TabIndex = 70;
            this.openButton.Text = "Select";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(18, 220);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(205, 20);
            this.sourceTextBox.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "RM Folder:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(205, 369);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 67;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(18, 369);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 66;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Auto Generate:";
            // 
            // autoGenCheckBox
            // 
            this.autoGenCheckBox.AutoSize = true;
            this.autoGenCheckBox.Location = new System.Drawing.Point(159, 65);
            this.autoGenCheckBox.Name = "autoGenCheckBox";
            this.autoGenCheckBox.Size = new System.Drawing.Size(15, 14);
            this.autoGenCheckBox.TabIndex = 64;
            this.autoGenCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Set Time To Auto Generate:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(159, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(118, 20);
            this.dateTimePicker1.TabIndex = 62;
            // 
            // branchCodeTextBox
            // 
            this.branchCodeTextBox.Location = new System.Drawing.Point(15, 113);
            this.branchCodeTextBox.Name = "branchCodeTextBox";
            this.branchCodeTextBox.Size = new System.Drawing.Size(262, 20);
            this.branchCodeTextBox.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Branch Code:";
            // 
            // warehouseCodeTextBox
            // 
            this.warehouseCodeTextBox.Location = new System.Drawing.Point(15, 167);
            this.warehouseCodeTextBox.Name = "warehouseCodeTextBox";
            this.warehouseCodeTextBox.Size = new System.Drawing.Size(262, 20);
            this.warehouseCodeTextBox.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Warehouse Code:";
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(15, 326);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(262, 20);
            this.prefixTextBox.TabIndex = 79;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Prefix:";
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 404);
            this.Controls.Add(this.prefixTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.warehouseCodeTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.branchCodeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.destTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.autoGenCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Setup";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.Setup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox destTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox autoGenCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox branchCodeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox warehouseCodeTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Label label7;
    }
}