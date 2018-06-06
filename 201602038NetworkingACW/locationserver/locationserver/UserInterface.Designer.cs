namespace locationserver
{
    partial class UserInterface
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.consoleOutputTextBox = new System.Windows.Forms.TextBox();
            this.startListeningButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.databaseFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.logFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timeoutTextBox = new System.Windows.Forms.TextBox();
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 306);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.consoleOutputTextBox);
            this.tabPage1.Controls.Add(this.startListeningButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(457, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Window";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Console Output:";
            // 
            // consoleOutputTextBox
            // 
            this.consoleOutputTextBox.BackColor = System.Drawing.Color.Silver;
            this.consoleOutputTextBox.Location = new System.Drawing.Point(9, 58);
            this.consoleOutputTextBox.Multiline = true;
            this.consoleOutputTextBox.Name = "consoleOutputTextBox";
            this.consoleOutputTextBox.ReadOnly = true;
            this.consoleOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleOutputTextBox.Size = new System.Drawing.Size(392, 155);
            this.consoleOutputTextBox.TabIndex = 7;
            this.consoleOutputTextBox.TextChanged += new System.EventHandler(this.consoleOutputTextBox_TextChanged);
            // 
            // startListeningButton
            // 
            this.startListeningButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startListeningButton.Location = new System.Drawing.Point(9, 6);
            this.startListeningButton.Name = "startListeningButton";
            this.startListeningButton.Size = new System.Drawing.Size(96, 23);
            this.startListeningButton.TabIndex = 0;
            this.startListeningButton.Text = "Start Listening";
            this.startListeningButton.UseVisualStyleBackColor = false;
            this.startListeningButton.Click += new System.EventHandler(this.startListeningButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Server Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.databaseFileLocationTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.logFileLocationTextBox);
            this.groupBox2.Location = new System.Drawing.Point(147, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 142);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Locations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Log File Location:";
            // 
            // databaseFileLocationTextBox
            // 
            this.databaseFileLocationTextBox.Location = new System.Drawing.Point(9, 77);
            this.databaseFileLocationTextBox.Name = "databaseFileLocationTextBox";
            this.databaseFileLocationTextBox.Size = new System.Drawing.Size(242, 20);
            this.databaseFileLocationTextBox.TabIndex = 7;
            this.databaseFileLocationTextBox.TextChanged += new System.EventHandler(this.databaseFileLocationTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Database File Location:";
            // 
            // logFileLocationTextBox
            // 
            this.logFileLocationTextBox.Location = new System.Drawing.Point(9, 32);
            this.logFileLocationTextBox.Name = "logFileLocationTextBox";
            this.logFileLocationTextBox.Size = new System.Drawing.Size(242, 20);
            this.logFileLocationTextBox.TabIndex = 6;
            this.logFileLocationTextBox.TextChanged += new System.EventHandler(this.logFileLocationTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.timeoutTextBox);
            this.groupBox1.Controls.Add(this.debugCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 142);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Functions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Timeout:";
            // 
            // timeoutTextBox
            // 
            this.timeoutTextBox.Location = new System.Drawing.Point(0, 32);
            this.timeoutTextBox.Name = "timeoutTextBox";
            this.timeoutTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeoutTextBox.TabIndex = 2;
            this.timeoutTextBox.TextChanged += new System.EventHandler(this.timeoutTextBox_TextChanged);
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Location = new System.Drawing.Point(12, 57);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.debugCheckBox.Size = new System.Drawing.Size(88, 17);
            this.debugCheckBox.TabIndex = 0;
            this.debugCheckBox.Text = "Debug Mode";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            this.debugCheckBox.CheckedChanged += new System.EventHandler(this.debugCheckBox_CheckedChanged);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 330);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "UserInterface";
            this.Text = "UserInterface";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox consoleOutputTextBox;
        private System.Windows.Forms.Button startListeningButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox logFileLocationTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox timeoutTextBox;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.TextBox databaseFileLocationTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
    }
}