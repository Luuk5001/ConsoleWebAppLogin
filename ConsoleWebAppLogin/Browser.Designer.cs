namespace ConsoleWebAppLogin
{
    partial class Browser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.prevPageButton = new System.Windows.Forms.ToolStripButton();
			this.nextPageButton = new System.Windows.Forms.ToolStripButton();
			this.infoButton = new System.Windows.Forms.ToolStripButton();
			this.currentAdress = new System.Windows.Forms.ToolStripLabel();
			this.showMessagesButton = new System.Windows.Forms.ToolStripButton();
			this.showStatusIcon = new System.Windows.Forms.Panel();
			this.messageTextBox = new System.Windows.Forms.TextBox();
			this.messagePanel = new System.Windows.Forms.Panel();
			this.printButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip.SuspendLayout();
			this.showStatusIcon.SuspendLayout();
			this.messagePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prevPageButton,
            this.nextPageButton,
            this.infoButton,
            this.currentAdress,
            this.showMessagesButton,
            this.printButton});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(846, 25);
			this.toolStrip.TabIndex = 1;
			// 
			// prevPageButton
			// 
			this.prevPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.prevPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.prevPageButton.Name = "prevPageButton";
			this.prevPageButton.Size = new System.Drawing.Size(23, 22);
			this.prevPageButton.Text = "Terug";
			this.prevPageButton.Click += new System.EventHandler(this.PrevPageButton_Click);
			// 
			// nextPageButton
			// 
			this.nextPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.nextPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nextPageButton.Name = "nextPageButton";
			this.nextPageButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.nextPageButton.Size = new System.Drawing.Size(23, 22);
			this.nextPageButton.Text = "Vooruit";
			this.nextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
			// 
			// infoButton
			// 
			this.infoButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.infoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.infoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.infoButton.Name = "infoButton";
			this.infoButton.Size = new System.Drawing.Size(23, 22);
			this.infoButton.Text = "Info";
			this.infoButton.Click += new System.EventHandler(this.InfoButton_Click);
			// 
			// currentAdress
			// 
			this.currentAdress.Name = "currentAdress";
			this.currentAdress.Size = new System.Drawing.Size(0, 22);
			// 
			// showMessagesButton
			// 
			this.showMessagesButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.showMessagesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.showMessagesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.showMessagesButton.Name = "showMessagesButton";
			this.showMessagesButton.Size = new System.Drawing.Size(23, 22);
			this.showMessagesButton.Text = "Applicatie berichten";
			this.showMessagesButton.Click += new System.EventHandler(this.ShowMessagesButton_Click);
			// 
			// showStatusIcon
			// 
			this.showStatusIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.showStatusIcon.Controls.Add(this.messagePanel);
			this.showStatusIcon.Location = new System.Drawing.Point(0, 25);
			this.showStatusIcon.Name = "showStatusIcon";
			this.showStatusIcon.Size = new System.Drawing.Size(846, 535);
			this.showStatusIcon.TabIndex = 0;
			// 
			// messageTextBox
			// 
			this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.messageTextBox.BackColor = System.Drawing.Color.Black;
			this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.messageTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.messageTextBox.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.messageTextBox.ForeColor = System.Drawing.Color.White;
			this.messageTextBox.Location = new System.Drawing.Point(-1, 0);
			this.messageTextBox.Margin = new System.Windows.Forms.Padding(10);
			this.messageTextBox.Multiline = true;
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.ReadOnly = true;
			this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.messageTextBox.Size = new System.Drawing.Size(499, 250);
			this.messageTextBox.TabIndex = 0;
			// 
			// messagePanel
			// 
			this.messagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.messagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.messagePanel.Controls.Add(this.messageTextBox);
			this.messagePanel.Location = new System.Drawing.Point(343, 3);
			this.messagePanel.Name = "messagePanel";
			this.messagePanel.Size = new System.Drawing.Size(500, 250);
			this.messagePanel.TabIndex = 1;
			this.messagePanel.Visible = false;
			// 
			// printButton
			// 
			this.printButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.printButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printButton.Name = "printButton";
			this.printButton.Size = new System.Drawing.Size(23, 22);
			this.printButton.Text = "Print";
			this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
			// 
			// Browser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 560);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.showStatusIcon);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Browser";
			this.Text = "Browser";
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.showStatusIcon.ResumeLayout(false);
			this.messagePanel.ResumeLayout(false);
			this.messagePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton nextPageButton;
		private System.Windows.Forms.ToolStripButton prevPageButton;
		private System.Windows.Forms.Panel showStatusIcon;
		private System.Windows.Forms.ToolStripLabel currentAdress;
		private System.Windows.Forms.ToolStripButton infoButton;
		private System.Windows.Forms.TextBox messageTextBox;
		private System.Windows.Forms.ToolStripButton showMessagesButton;
		private System.Windows.Forms.Panel messagePanel;
		private System.Windows.Forms.ToolStripButton printButton;
	}
}

