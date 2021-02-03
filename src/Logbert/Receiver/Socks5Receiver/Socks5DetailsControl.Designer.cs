namespace Couchcoding.Logbert.Controls
{
  partial class Socks5DetailsControl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.logDetailToolStrip = new Couchcoding.Logbert.Gui.Controls.ToolStripEx();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tltTip = new System.Windows.Forms.ToolTip(this.components);
            this.pbxCopyMessage = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.pbxCopyThread = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.pbxCopyDateTime = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.pbxCopyLevel = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.pbxCopyLogger = new Couchcoding.Logbert.Gui.Controls.PictureBoxEx();
            this.LogMessagePanel = new Couchcoding.Logbert.Gui.Controls.InfoPanel();
            this.tblLogMessage = new System.Windows.Forms.TableLayoutPanel();
            this.lblCaptionLogger = new System.Windows.Forms.Label();
            this.lblCaptionLevel = new System.Windows.Forms.Label();
            this.lblCaptionDateTime = new System.Windows.Forms.Label();
            this.lblCaptionThread = new System.Windows.Forms.Label();
            this.lblCaptionMessage = new System.Windows.Forms.Label();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtDataMessage = new System.Windows.Forms.TextBox();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.logDetailToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyThread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLogger)).BeginInit();
            this.LogMessagePanel.SuspendLayout();
            this.tblLogMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // logDetailToolStrip
            // 
            this.logDetailToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.logDetailToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.logDetailToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.toolStripSeparator1,
            this.tsbCopy});
            this.logDetailToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.logDetailToolStrip.Location = new System.Drawing.Point(0, 0);
            this.logDetailToolStrip.Name = "logDetailToolStrip";
            this.logDetailToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.logDetailToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.logDetailToolStrip.Size = new System.Drawing.Size(645, 33);
            this.logDetailToolStrip.TabIndex = 0;
            this.logDetailToolStrip.Text = "tsMessageDetails";
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIn.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.Size = new System.Drawing.Size(34, 30);
            this.tsbZoomIn.Text = "Zoom In";
            this.tsbZoomIn.ToolTipText = "Zoom In";
            this.tsbZoomIn.Click += new System.EventHandler(this.TsbZoomInClick);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(34, 28);
            this.tsbZoomOut.Text = "Zoom Out";
            this.tsbZoomOut.ToolTipText = "Zoom Out";
            this.tsbZoomOut.Click += new System.EventHandler(this.TsbZoomOutClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbCopy
            // 
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(123, 28);
            this.tsbCopy.Text = "Copy Details";
            this.tsbCopy.Click += new System.EventHandler(this.TsbCopyClick);
            // 
            // pbxCopyMessage
            // 
            this.pbxCopyMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxCopyMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCopyMessage.Location = new System.Drawing.Point(608, 131);
            this.pbxCopyMessage.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.pbxCopyMessage.Name = "pbxCopyMessage";
            this.pbxCopyMessage.Size = new System.Drawing.Size(26, 25);
            this.pbxCopyMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCopyMessage.TabIndex = 14;
            this.pbxCopyMessage.TabStop = false;
            this.tltTip.SetToolTip(this.pbxCopyMessage, "Copy Message Details to the Clipboard");
            this.pbxCopyMessage.Visible = false;
            this.pbxCopyMessage.Click += new System.EventHandler(this.PbxCopyMessageClick);
            // 
            // pbxCopyThread
            // 
            this.pbxCopyThread.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxCopyThread.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCopyThread.Location = new System.Drawing.Point(608, 99);
            this.pbxCopyThread.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.pbxCopyThread.Name = "pbxCopyThread";
            this.pbxCopyThread.Size = new System.Drawing.Size(26, 25);
            this.pbxCopyThread.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCopyThread.TabIndex = 13;
            this.pbxCopyThread.TabStop = false;
            this.tltTip.SetToolTip(this.pbxCopyThread, "Copy Thread Details to the Clipboard");
            this.pbxCopyThread.Visible = false;
            this.pbxCopyThread.Click += new System.EventHandler(this.PbxCopyThreadClick);
            // 
            // pbxCopyDateTime
            // 
            this.pbxCopyDateTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxCopyDateTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCopyDateTime.Location = new System.Drawing.Point(608, 67);
            this.pbxCopyDateTime.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.pbxCopyDateTime.Name = "pbxCopyDateTime";
            this.pbxCopyDateTime.Size = new System.Drawing.Size(26, 25);
            this.pbxCopyDateTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCopyDateTime.TabIndex = 12;
            this.pbxCopyDateTime.TabStop = false;
            this.tltTip.SetToolTip(this.pbxCopyDateTime, "Copy Date and Time Details to the Clipboard");
            this.pbxCopyDateTime.Visible = false;
            this.pbxCopyDateTime.Click += new System.EventHandler(this.PbxCopyDateTimeClick);
            // 
            // pbxCopyLevel
            // 
            this.pbxCopyLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxCopyLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCopyLevel.Location = new System.Drawing.Point(608, 35);
            this.pbxCopyLevel.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.pbxCopyLevel.Name = "pbxCopyLevel";
            this.pbxCopyLevel.Size = new System.Drawing.Size(26, 25);
            this.pbxCopyLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCopyLevel.TabIndex = 11;
            this.pbxCopyLevel.TabStop = false;
            this.tltTip.SetToolTip(this.pbxCopyLevel, "Copy Level Details to the Clipboard");
            this.pbxCopyLevel.Visible = false;
            this.pbxCopyLevel.Click += new System.EventHandler(this.PbxCopyLevelClick);
            // 
            // pbxCopyLogger
            // 
            this.pbxCopyLogger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxCopyLogger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCopyLogger.Location = new System.Drawing.Point(608, 3);
            this.pbxCopyLogger.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.pbxCopyLogger.Name = "pbxCopyLogger";
            this.pbxCopyLogger.Size = new System.Drawing.Size(26, 25);
            this.pbxCopyLogger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCopyLogger.TabIndex = 10;
            this.pbxCopyLogger.TabStop = false;
            this.tltTip.SetToolTip(this.pbxCopyLogger, "Copy Logger Details to the Clipboard");
            this.pbxCopyLogger.Visible = false;
            this.pbxCopyLogger.Click += new System.EventHandler(this.PbxCopyLoggerClick);
            // 
            // LogMessagePanel
            // 
            this.LogMessagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogMessagePanel.AutoScroll = true;
            this.LogMessagePanel.BackColor = System.Drawing.SystemColors.Window;
            this.LogMessagePanel.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.LogMessagePanel.Controls.Add(this.tblLogMessage);
            this.LogMessagePanel.Location = new System.Drawing.Point(0, 38);
            this.LogMessagePanel.Margin = new System.Windows.Forms.Padding(4);
            this.LogMessagePanel.Name = "LogMessagePanel";
            this.LogMessagePanel.ShowBorder = false;
            this.LogMessagePanel.ShowTitle = false;
            this.LogMessagePanel.Size = new System.Drawing.Size(645, 280);
            this.LogMessagePanel.TabIndex = 1;
            this.LogMessagePanel.TextPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.LogMessagePanel.Title = null;
            // 
            // tblLogMessage
            // 
            this.tblLogMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLogMessage.AutoSize = true;
            this.tblLogMessage.ColumnCount = 3;
            this.tblLogMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLogMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLogMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblLogMessage.Controls.Add(this.pbxCopyMessage, 2, 4);
            this.tblLogMessage.Controls.Add(this.pbxCopyThread, 2, 3);
            this.tblLogMessage.Controls.Add(this.pbxCopyDateTime, 2, 2);
            this.tblLogMessage.Controls.Add(this.pbxCopyLevel, 2, 1);
            this.tblLogMessage.Controls.Add(this.lblCaptionLogger, 0, 0);
            this.tblLogMessage.Controls.Add(this.lblCaptionLevel, 0, 1);
            this.tblLogMessage.Controls.Add(this.lblCaptionDateTime, 0, 2);
            this.tblLogMessage.Controls.Add(this.lblCaptionThread, 0, 3);
            this.tblLogMessage.Controls.Add(this.lblCaptionMessage, 0, 4);
            this.tblLogMessage.Controls.Add(this.txtDest, 1, 0);
            this.tblLogMessage.Controls.Add(this.txtSize, 1, 1);
            this.tblLogMessage.Controls.Add(this.txtDate, 1, 2);
            this.tblLogMessage.Controls.Add(this.txtType, 1, 3);
            this.tblLogMessage.Controls.Add(this.txtDataMessage, 1, 4);
            this.tblLogMessage.Controls.Add(this.pbxCopyLogger, 2, 0);
            this.tblLogMessage.Location = new System.Drawing.Point(4, 4);
            this.tblLogMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tblLogMessage.Name = "tblLogMessage";
            this.tblLogMessage.RowCount = 5;
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLogMessage.Size = new System.Drawing.Size(637, 271);
            this.tblLogMessage.TabIndex = 0;
            this.tblLogMessage.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TblLogMessageCellPaint);
            // 
            // lblCaptionLogger
            // 
            this.lblCaptionLogger.AutoSize = true;
            this.lblCaptionLogger.Location = new System.Drawing.Point(4, 1);
            this.lblCaptionLogger.Margin = new System.Windows.Forms.Padding(4, 1, 15, 1);
            this.lblCaptionLogger.Name = "lblCaptionLogger";
            this.lblCaptionLogger.Padding = new System.Windows.Forms.Padding(6);
            this.lblCaptionLogger.Size = new System.Drawing.Size(56, 30);
            this.lblCaptionLogger.TabIndex = 0;
            this.lblCaptionLogger.Text = "Dest";
            // 
            // lblCaptionLevel
            // 
            this.lblCaptionLevel.AutoSize = true;
            this.lblCaptionLevel.Location = new System.Drawing.Point(4, 33);
            this.lblCaptionLevel.Margin = new System.Windows.Forms.Padding(4, 1, 15, 1);
            this.lblCaptionLevel.Name = "lblCaptionLevel";
            this.lblCaptionLevel.Padding = new System.Windows.Forms.Padding(6);
            this.lblCaptionLevel.Size = new System.Drawing.Size(56, 30);
            this.lblCaptionLevel.TabIndex = 2;
            this.lblCaptionLevel.Text = "Size";
            // 
            // lblCaptionDateTime
            // 
            this.lblCaptionDateTime.AutoSize = true;
            this.lblCaptionDateTime.Location = new System.Drawing.Point(4, 65);
            this.lblCaptionDateTime.Margin = new System.Windows.Forms.Padding(4, 1, 15, 1);
            this.lblCaptionDateTime.Name = "lblCaptionDateTime";
            this.lblCaptionDateTime.Padding = new System.Windows.Forms.Padding(6);
            this.lblCaptionDateTime.Size = new System.Drawing.Size(56, 30);
            this.lblCaptionDateTime.TabIndex = 4;
            this.lblCaptionDateTime.Text = "Date";
            // 
            // lblCaptionThread
            // 
            this.lblCaptionThread.AutoSize = true;
            this.lblCaptionThread.Location = new System.Drawing.Point(4, 97);
            this.lblCaptionThread.Margin = new System.Windows.Forms.Padding(4, 1, 15, 1);
            this.lblCaptionThread.Name = "lblCaptionThread";
            this.lblCaptionThread.Padding = new System.Windows.Forms.Padding(6);
            this.lblCaptionThread.Size = new System.Drawing.Size(56, 30);
            this.lblCaptionThread.TabIndex = 6;
            this.lblCaptionThread.Text = "Type";
            // 
            // lblCaptionMessage
            // 
            this.lblCaptionMessage.AutoSize = true;
            this.lblCaptionMessage.Location = new System.Drawing.Point(4, 129);
            this.lblCaptionMessage.Margin = new System.Windows.Forms.Padding(4, 1, 15, 1);
            this.lblCaptionMessage.Name = "lblCaptionMessage";
            this.lblCaptionMessage.Padding = new System.Windows.Forms.Padding(6);
            this.lblCaptionMessage.Size = new System.Drawing.Size(83, 30);
            this.lblCaptionMessage.TabIndex = 8;
            this.lblCaptionMessage.Text = "Message";
            // 
            // txtDest
            // 
            this.txtDest.BackColor = System.Drawing.SystemColors.Window;
            this.txtDest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDest.Location = new System.Drawing.Point(106, 6);
            this.txtDest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 1);
            this.txtDest.Name = "txtDest";
            this.txtDest.ReadOnly = true;
            this.txtDest.Size = new System.Drawing.Size(495, 21);
            this.txtDest.TabIndex = 1;
            // 
            // txtSize
            // 
            this.txtSize.BackColor = System.Drawing.SystemColors.Window;
            this.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSize.Location = new System.Drawing.Point(106, 38);
            this.txtSize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 1);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(495, 21);
            this.txtSize.TabIndex = 3;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDate.Location = new System.Drawing.Point(106, 70);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 1);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(495, 21);
            this.txtDate.TabIndex = 5;
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.SystemColors.Window;
            this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType.Location = new System.Drawing.Point(106, 102);
            this.txtType.Margin = new System.Windows.Forms.Padding(4, 6, 4, 1);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(495, 21);
            this.txtType.TabIndex = 7;
            // 
            // txtDataMessage
            // 
            this.txtDataMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtDataMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataMessage.Location = new System.Drawing.Point(104, 134);
            this.txtDataMessage.Margin = new System.Windows.Forms.Padding(2, 6, 4, 1);
            this.txtDataMessage.Multiline = true;
            this.txtDataMessage.Name = "txtDataMessage";
            this.txtDataMessage.ReadOnly = true;
            this.txtDataMessage.Size = new System.Drawing.Size(497, 136);
            this.txtDataMessage.TabIndex = 9;
            // 
            // hexBox1
            // 
            this.hexBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hexBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.hexBox1.Location = new System.Drawing.Point(5, 324);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(635, 447);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 2;
            this.hexBox1.VScrollBarVisible = true;
            // 
            // Socks5DetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hexBox1);
            this.Controls.Add(this.LogMessagePanel);
            this.Controls.Add(this.logDetailToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Socks5DetailsControl";
            this.Size = new System.Drawing.Size(645, 775);
            this.logDetailToolStrip.ResumeLayout(false);
            this.logDetailToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyThread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopyLogger)).EndInit();
            this.LogMessagePanel.ResumeLayout(false);
            this.LogMessagePanel.PerformLayout();
            this.tblLogMessage.ResumeLayout(false);
            this.tblLogMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Couchcoding.Logbert.Gui.Controls.ToolStripEx logDetailToolStrip;
    private System.Windows.Forms.ToolStripButton tsbZoomIn;
    private System.Windows.Forms.ToolStripButton tsbZoomOut;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbCopy;
    private System.Windows.Forms.TableLayoutPanel tblLogMessage;
    private Gui.Controls.InfoPanel LogMessagePanel;
    private System.Windows.Forms.Label lblCaptionLogger;
    private System.Windows.Forms.Label lblCaptionLevel;
    private System.Windows.Forms.Label lblCaptionDateTime;
    private System.Windows.Forms.Label lblCaptionThread;
    private System.Windows.Forms.Label lblCaptionMessage;
    private System.Windows.Forms.TextBox txtDest;
    private System.Windows.Forms.TextBox txtSize;
    private System.Windows.Forms.TextBox txtDate;
    private System.Windows.Forms.TextBox txtType;
    private System.Windows.Forms.TextBox txtDataMessage;
    private Gui.Controls.PictureBoxEx pbxCopyLogger;
    private Gui.Controls.PictureBoxEx pbxCopyMessage;
    private Gui.Controls.PictureBoxEx pbxCopyThread;
    private Gui.Controls.PictureBoxEx pbxCopyDateTime;
    private Gui.Controls.PictureBoxEx pbxCopyLevel;
    private System.Windows.Forms.ToolTip tltTip;
    private Be.Windows.Forms.HexBox hexBox1;
  }
}
