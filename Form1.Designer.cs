
namespace Webshook
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.avatarBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.timeBox = new MetroFramework.Controls.MetroTextBox();
            this.deleteButton = new MetroFramework.Controls.MetroButton();
            this.spamButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.messageBox = new MetroFramework.Controls.MetroTextBox();
            this.usernameBox = new MetroFramework.Controls.MetroTextBox();
            this.webhookBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.metroLabel6);
            this.panel1.Controls.Add(this.avatarBox);
            this.panel1.Controls.Add(this.metroLabel5);
            this.panel1.Controls.Add(this.timeBox);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.spamButton);
            this.panel1.Controls.Add(this.metroLabel4);
            this.panel1.Controls.Add(this.metroLabel3);
            this.panel1.Controls.Add(this.metroLabel2);
            this.panel1.Controls.Add(this.messageBox);
            this.panel1.Controls.Add(this.usernameBox);
            this.panel1.Controls.Add(this.webhookBox);
            this.panel1.Location = new System.Drawing.Point(23, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 307);
            this.panel1.TabIndex = 0;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel6.CustomForeColor = true;
            this.metroLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.metroLabel6.Location = new System.Drawing.Point(355, 73);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(219, 19);
            this.metroLabel6.TabIndex = 10;
            this.metroLabel6.Text = "Webhook Avatar URL (not required)";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // avatarBox
            // 
            this.avatarBox.Location = new System.Drawing.Point(355, 95);
            this.avatarBox.MaxLength = 1000;
            this.avatarBox.Name = "avatarBox";
            this.avatarBox.Size = new System.Drawing.Size(219, 23);
            this.avatarBox.TabIndex = 2;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel5.CustomForeColor = true;
            this.metroLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.metroLabel5.Location = new System.Drawing.Point(355, 138);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(93, 19);
            this.metroLabel5.TabIndex = 8;
            this.metroLabel5.Text = "# of messages";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(355, 160);
            this.timeBox.MaxLength = 25;
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(38, 23);
            this.timeBox.TabIndex = 4;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(237, 250);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(123, 35);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.TabStop = false;
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // spamButton
            // 
            this.spamButton.Location = new System.Drawing.Point(267, 209);
            this.spamButton.Name = "spamButton";
            this.spamButton.Size = new System.Drawing.Size(64, 35);
            this.spamButton.TabIndex = 5;
            this.spamButton.TabStop = false;
            this.spamButton.Text = "Spam";
            this.spamButton.Click += new System.EventHandler(this.spamButton_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel4.CustomForeColor = true;
            this.metroLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.metroLabel4.Location = new System.Drawing.Point(139, 138);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(120, 19);
            this.metroLabel4.TabIndex = 4;
            this.metroLabel4.Text = "Webhook Message";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.CustomForeColor = true;
            this.metroLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.metroLabel3.Location = new System.Drawing.Point(139, 73);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(128, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Webhook Username";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.CustomForeColor = true;
            this.metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.metroLabel2.Location = new System.Drawing.Point(139, 17);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(92, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Webhook URL";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(139, 160);
            this.messageBox.MaxLength = 1000;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(199, 23);
            this.messageBox.TabIndex = 3;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(139, 95);
            this.usernameBox.MaxLength = 32;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(199, 23);
            this.usernameBox.TabIndex = 1;
            // 
            // webhookBox
            // 
            this.webhookBox.Location = new System.Drawing.Point(139, 39);
            this.webhookBox.Name = "webhookBox";
            this.webhookBox.Size = new System.Drawing.Size(313, 23);
            this.webhookBox.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.CustomForeColor = true;
            this.metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.metroLabel1.Location = new System.Drawing.Point(282, 71);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(85, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Spam/Delete";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel7.CustomForeColor = true;
            this.metroLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.metroLabel7.Location = new System.Drawing.Point(1, 394);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(102, 19);
            this.metroLabel7.TabIndex = 0;
            this.metroLabel7.Text = "By: Francesco24";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 414);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "WebShook";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox webhookBox;
        private MetroFramework.Controls.MetroTextBox usernameBox;
        private MetroFramework.Controls.MetroTextBox messageBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton spamButton;
        private MetroFramework.Controls.MetroButton deleteButton;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox timeBox;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox avatarBox;
        private MetroFramework.Controls.MetroLabel metroLabel7;
    }
}

