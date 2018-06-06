namespace location
{
    partial class Client
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
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.protocolComboBox = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.protocolLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.timeoutTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.timeoutLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.serverdetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.debugModeCheckBox = new System.Windows.Forms.CheckBox();
            this.serverdetailsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(6, 39);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(160, 20);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBox_TextChanged);
            // 
            // protocolComboBox
            // 
            this.protocolComboBox.FormattingEnabled = true;
            this.protocolComboBox.Items.AddRange(new object[] {
            "whois",
            "-h9",
            "-h0",
            "-h1"});
            this.protocolComboBox.Location = new System.Drawing.Point(9, 118);
            this.protocolComboBox.Name = "protocolComboBox";
            this.protocolComboBox.Size = new System.Drawing.Size(129, 21);
            this.protocolComboBox.TabIndex = 1;
            this.protocolComboBox.SelectedIndexChanged += new System.EventHandler(this.ProtocolComboBox_SelectedIndexChanged);
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.Black;
            this.sendButton.Location = new System.Drawing.Point(125, 105);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(41, 28);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // protocolLabel
            // 
            this.protocolLabel.AutoSize = true;
            this.protocolLabel.Location = new System.Drawing.Point(6, 102);
            this.protocolLabel.Name = "protocolLabel";
            this.protocolLabel.Size = new System.Drawing.Size(46, 13);
            this.protocolLabel.TabIndex = 3;
            this.protocolLabel.Text = "Protocol";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(9, 79);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(129, 20);
            this.portTextBox.TabIndex = 4;
            this.portTextBox.TextChanged += new System.EventHandler(this.PortTextBox_TextChanged);
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(9, 40);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(129, 20);
            this.hostTextBox.TabIndex = 5;
            this.hostTextBox.TextChanged += new System.EventHandler(this.HostTextBox_TextChanged);
            // 
            // timeoutTextBox
            // 
            this.timeoutTextBox.Location = new System.Drawing.Point(9, 158);
            this.timeoutTextBox.Name = "timeoutTextBox";
            this.timeoutTextBox.Size = new System.Drawing.Size(129, 20);
            this.timeoutTextBox.TabIndex = 6;
            this.timeoutTextBox.TextChanged += new System.EventHandler(this.TimeoutTextBox_TextChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(6, 63);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 7;
            this.portLabel.Text = "Port";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(6, 24);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(29, 13);
            this.hostLabel.TabIndex = 8;
            this.hostLabel.Text = "Host";
            // 
            // timeoutLabel
            // 
            this.timeoutLabel.AutoSize = true;
            this.timeoutLabel.Location = new System.Drawing.Point(6, 142);
            this.timeoutLabel.Name = "timeoutLabel";
            this.timeoutLabel.Size = new System.Drawing.Size(45, 13);
            this.timeoutLabel.TabIndex = 9;
            this.timeoutLabel.Text = "Timeout";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(3, 23);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 11;
            this.usernameLabel.Text = "Username";
            // 
            // serverdetailsGroupBox
            // 
            this.serverdetailsGroupBox.Controls.Add(this.debugModeCheckBox);
            this.serverdetailsGroupBox.Controls.Add(this.hostLabel);
            this.serverdetailsGroupBox.Controls.Add(this.portTextBox);
            this.serverdetailsGroupBox.Controls.Add(this.timeoutTextBox);
            this.serverdetailsGroupBox.Controls.Add(this.timeoutLabel);
            this.serverdetailsGroupBox.Controls.Add(this.portLabel);
            this.serverdetailsGroupBox.Controls.Add(this.hostTextBox);
            this.serverdetailsGroupBox.Controls.Add(this.protocolLabel);
            this.serverdetailsGroupBox.Controls.Add(this.protocolComboBox);
            this.serverdetailsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.serverdetailsGroupBox.Name = "serverdetailsGroupBox";
            this.serverdetailsGroupBox.Size = new System.Drawing.Size(144, 218);
            this.serverdetailsGroupBox.TabIndex = 12;
            this.serverdetailsGroupBox.TabStop = false;
            this.serverdetailsGroupBox.Text = "Server Details";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(6, 79);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(160, 20);
            this.locationTextBox.TabIndex = 13;
            this.locationTextBox.TextChanged += new System.EventHandler(this.LocationTextBox_TextChanged);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(3, 63);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 13);
            this.locationLabel.TabIndex = 14;
            this.locationLabel.Text = "Location";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usernameTextBox);
            this.groupBox1.Controls.Add(this.locationLabel);
            this.groupBox1.Controls.Add(this.sendButton);
            this.groupBox1.Controls.Add(this.usernameLabel);
            this.groupBox1.Controls.Add(this.locationTextBox);
            this.groupBox1.Location = new System.Drawing.Point(185, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 139);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Locator";
            // 
            // debugModeCheckBox
            // 
            this.debugModeCheckBox.AutoSize = true;
            this.debugModeCheckBox.Location = new System.Drawing.Point(50, 184);
            this.debugModeCheckBox.Name = "debugModeCheckBox";
            this.debugModeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.debugModeCheckBox.Size = new System.Drawing.Size(88, 17);
            this.debugModeCheckBox.TabIndex = 16;
            this.debugModeCheckBox.Text = "Debug Mode";
            this.debugModeCheckBox.UseVisualStyleBackColor = true;
            this.debugModeCheckBox.CheckedChanged += new System.EventHandler(this.debugModeCheckBox_CheckedChanged);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serverdetailsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.serverdetailsGroupBox.ResumeLayout(false);
            this.serverdetailsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label protocolLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label timeoutLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.GroupBox serverdetailsGroupBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.ComboBox protocolComboBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox timeoutTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.CheckBox debugModeCheckBox;
    }
}