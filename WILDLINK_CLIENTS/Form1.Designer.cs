namespace WILDLINK_CLIENTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lstChatBox = new System.Windows.Forms.ListBox();
            this.btnExportMessage = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "WildLink ID:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(81, 19);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(126, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnJoin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnJoin.FlatAppearance.BorderSize = 0;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJoin.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnJoin.Location = new System.Drawing.Point(406, 3);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(85, 23);
            this.btnJoin.TabIndex = 2;
            this.btnJoin.Text = "Connect";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // txtInterest
            // 
            this.txtInterest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInterest.Location = new System.Drawing.Point(270, 19);
            this.txtInterest.Multiline = true;
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(126, 20);
            this.txtInterest.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(214, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interest:";
            // 
            // btnSend
            // 
            this.btnSend.BackgroundImage = global::WILDLINK_CLIENTS.Properties.Resources.Send;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(469, 467);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(44, 41);
            this.btnSend.TabIndex = 8;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(48, 473);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(415, 34);
            this.txtMessage.TabIndex = 7;
            // 
            // lstChatBox
            // 
            this.lstChatBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChatBox.FormattingEnabled = true;
            this.lstChatBox.HorizontalScrollbar = true;
            this.lstChatBox.ItemHeight = 17;
            this.lstChatBox.Location = new System.Drawing.Point(7, 56);
            this.lstChatBox.Name = "lstChatBox";
            this.lstChatBox.ScrollAlwaysVisible = true;
            this.lstChatBox.Size = new System.Drawing.Size(506, 395);
            this.lstChatBox.TabIndex = 9;
            // 
            // btnExportMessage
            // 
            this.btnExportMessage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportMessage.BackgroundImage = global::WILDLINK_CLIENTS.Properties.Resources.Document;
            this.btnExportMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportMessage.FlatAppearance.BorderSize = 0;
            this.btnExportMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMessage.Location = new System.Drawing.Point(7, 471);
            this.btnExportMessage.Name = "btnExportMessage";
            this.btnExportMessage.Size = new System.Drawing.Size(35, 37);
            this.btnExportMessage.TabIndex = 10;
            this.btnExportMessage.UseVisualStyleBackColor = true;
            this.btnExportMessage.Click += new System.EventHandler(this.btnExportMessage_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Crimson;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisconnect.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDisconnect.Location = new System.Drawing.Point(406, 29);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(85, 23);
            this.btnDisconnect.TabIndex = 11;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(525, 514);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnExportMessage);
            this.Controls.Add(this.lstChatBox);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtInterest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uni-WildLink Chatroom";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txtInterest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lstChatBox;
        private System.Windows.Forms.Button btnExportMessage;
        private System.Windows.Forms.Button btnDisconnect;
    }
}

