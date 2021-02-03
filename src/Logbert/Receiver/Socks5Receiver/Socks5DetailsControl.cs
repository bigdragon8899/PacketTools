﻿#region Copyright © 2015 Couchcoding

// File:    Log4NetDetailsControl.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2015 Couchcoding
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Be.Windows.Forms;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Theme.Palettes;
using Couchcoding.Logbert.Interfaces;
using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Properties;
using Couchcoding.Logbert.Receiver.Socks5Receiver;
using Couchcoding.Logbert.Theme.Interfaces;
using Couchcoding.Logbert.Theme;
using Couchcoding.Logbert.Theme.Themes;

namespace Couchcoding.Logbert.Controls
{
  /// <summary>
  /// Implements a <see cref="UserControl"/> to display details of a selected <see cref="LogMessage"/>.
  /// </summary>
  public partial class Socks5DetailsControl : UserControl, ILogPresenter, IThemable
  {
    #region Private Consts

    /// <summary>
    /// Defines the minimum font size (em) for the <see cref="LogMessage"/> list.
    /// </summary>
    private const int MIN_ZOOM_LEVEL = 6;

    /// <summary>
    /// Defines the maximum font size (em) for the <see cref="LogMessage"/> list.
    /// </summary>
    private const int MAX_ZOOM_LEVEL = 60;

    #endregion

    #region Private Fields

    /// <summary>
    /// The bold <see cref="Font"/> for the caption area.
    /// </summary>
    Font mBoldCaptionFont;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the count of currently displayed <see cref=LogMessage"/>s.
    /// </summary>
    public int DisplayedLogMessagesCount
    {
      get
      {
        return 0;
      }
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <returns>The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.</returns>
    public sealed override Font Font
    {
      get
      {
        return base.Font;
      }
      set
      {
        base.Font = value;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the Click event of the zoom in <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbZoomInClick(object sender, EventArgs e)
    {
      bool futherZoomInPossible = ZoomIn();

      tsbZoomIn.Enabled  = futherZoomInPossible;
      tsbZoomOut.Enabled = true;
    }

    /// <summary>
    /// Handles the Click event of the zoom out <see cref="ToolStripButton"/>.
    /// </summary>
    private void TsbZoomOutClick(object sender, EventArgs e)
    {
      bool futherZoomOutPossible = ZoomOut();

      tsbZoomIn.Enabled  = true;
      tsbZoomOut.Enabled = futherZoomOutPossible;
    }

    /// <summary>
    /// Handles the Click event of the copy content <see cref="ToolStripButton"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TsbCopyClick(object sender, EventArgs e)
    {
      StringBuilder sBuilder = new StringBuilder();

      sBuilder.AppendLine("Ip:        " + txtDest.Text);
      sBuilder.AppendLine("Port:         " + txtSize.Text);
      sBuilder.AppendLine("Date and Time: " + txtDate.Text);
      sBuilder.AppendLine("Type:        " + txtType.Text);
      sBuilder.AppendLine("Message:       " + txtDataMessage.Text);

      this.CopyToClipboard(sBuilder.ToString());
    }

    /// <summary>
    /// Handles the CellPaint event of the <see cref="TableLayoutPanel"/>.
    /// </summary>
    private void TblLogMessageCellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
      if (e.Row > 0)
      {
        e.Graphics.DrawLine(
            GdiCache.GetPenFromColor(ThemeManager.CurrentApplicationTheme.ColorPalette.DividerColor)
          , new Point(e.CellBounds.Left,  e.CellBounds.Top)
          , new Point(e.CellBounds.Right, e.CellBounds.Top));
      }
    }

    /// <summary>
    /// Handles the Click event of the copy logger details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the logger details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyLoggerClick(object sender, EventArgs e)
    {
      pbxCopyLogger.CopyToClipboard(txtDest.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy level details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the level details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyLevelClick(object sender, EventArgs e)
    {
      pbxCopyLevel.CopyToClipboard(txtSize.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy date and time details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the date and time details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyDateTimeClick(object sender, EventArgs e)
    {
      pbxCopyDateTime.CopyToClipboard(txtDate.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy thread details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the thread details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyThreadClick(object sender, EventArgs e)
    {
      pbxCopyThread.CopyToClipboard(txtType.Text);
    }

    /// <summary>
    /// Handles the Click event of the copy message details <see cref="PictureBox"/>.
    /// <para>
    /// Copies the message details to the <see cref="Clipboard"/>.
    /// </para>
    /// </summary>
    private void PbxCopyMessageClick(object sender, EventArgs e)
    {
      pbxCopyMessage.CopyToClipboard(txtDataMessage.Text);
    }


    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();

        SelectLogMessage(null);

        if (mBoldCaptionFont != null)
        {
          mBoldCaptionFont.Dispose();
        }
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Handles the size changed event of the <see cref="Control"/>.
    /// </summary>
    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);

      txtDataMessage.AdjustHeightToContent();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Updates the visible <see cref="LogMessage"/>s.
    /// </summary>
    /// <param name="messages">The list of <see cref="LogMessage"/>s to display.</param>
    /// <param name="delta">The count of new <see cref="LogMessage"/>s.</param>
    public void LogMessagesChanged(List<LogMessage> messages, int delta)
    {
      // Nothing to do here.
    }

    /// <summary>
    /// Selects the <see cref="LogMessage"/> on the given <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="LogMessage"/> to select.</param>
    public bool SelectLogMessage(int index)
    {
      // Nothing to do here.
      return true;
    }
    
    /// <summary>
    /// Updates the <see cref="LogLevel"/> to display.
    /// </summary>
    /// <param name="level">The new <see cref="LogLevel"/> to display.</param>
    public void LogLevelChanged(LogLevel level)
    {
      // Nothing to do here.
    }

    /// <summary>
    /// Selects the given <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="LogMessage"/> o select</param>
    public bool SelectLogMessage(LogMessage message)
    {
      LogMessageSocks5 logMessage = message as LogMessageSocks5;

      try
      {
        this.SuspendDrawing();

        if (logMessage != null)
        {
          txtDest.Text    = logMessage.IpEndPoint.Address.ToString() +":"+ logMessage.IpEndPoint.Port;
          txtSize.Text     = logMessage.Size.ToString();
          txtDate.Text  = logMessage.Timestamp.Add(logMessage.TimeShiftOffset).ToString(Settings.Default.TimestampFormat);
          txtType.Text    =  logMessage.MessageType.ToString();

          if (logMessage.TimeShiftOffset.Milliseconds != 0)
          {
            txtDate.Text += string.Format(
                Resources.strLoggerDetailsCtrlOffset
              , logMessage.TimeShiftOffset.Milliseconds);
          }

          _resetHexBox(logMessage.Buffer);
          txtDataMessage.Text = byteToHexStr(logMessage.Buffer);
        }
        else
        {
          _resetHexBoxEmpty();
          txtDest.Text     = string.Empty;
          txtSize.Text      = message != null ? message.Level.ToString() : string.Empty;
          txtDate.Text   = message != null ? message.Timestamp.ToString(Settings.Default.TimestampFormat) : string.Empty;
          txtType.Text     = string.Empty;
          txtDataMessage.Text    = message != null ? message.Message.Trim() : string.Empty;
        }

        pbxCopyLogger.Visible     = !string.IsNullOrEmpty(txtDest.Text);
        pbxCopyLevel.Visible      = !string.IsNullOrEmpty(txtSize.Text);
        pbxCopyThread.Visible     = !string.IsNullOrEmpty(txtType.Text);
        pbxCopyDateTime.Visible   = !string.IsNullOrEmpty(txtDate.Text);
        pbxCopyMessage.Visible    = !string.IsNullOrEmpty(txtDataMessage.Text);
      }
      finally
      {
        txtDataMessage.AdjustHeightToContent();

        this.ResumeDrawing();
      }

      return true;
    }

    /// <summary>
    /// Clears all shown <see cref="LogMessage"/>s.
    /// </summary>
    public void ClearAll()
    {
      SelectLogMessage(null);
    }

    /// <summary>
    /// Increases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further increasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomIn()
    {
      if (tblLogMessage.Font.Size < MAX_ZOOM_LEVEL)
      {
        try
        {
          this.SuspendDrawing();

          tblLogMessage.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , tblLogMessage.Font.Size + 1
            , FontStyle.Regular);

          mBoldCaptionFont = FontCache.GetFontFromIdentifier(
              Font.Name
            , mBoldCaptionFont.Size + 1
            , FontStyle.Bold);

          lblCaptionLogger.Font     = mBoldCaptionFont;
          lblCaptionLevel.Font      = mBoldCaptionFont;
          lblCaptionThread.Font     = mBoldCaptionFont;
          lblCaptionDateTime.Font   = mBoldCaptionFont;
          lblCaptionMessage.Font    = mBoldCaptionFont;

          return tblLogMessage.Font.Size < MAX_ZOOM_LEVEL;
        }
        finally
        {
          this.ResumeDrawing();
        }
      }

      return false;
    }

    /// <summary>
    /// Decreases the size of the <see cref="ILogPresenter"/> content.
    /// </summary>
    /// <returns><c>True</c> if further decreasing is possible, otherwise <c>false</c>.</returns>
    public bool ZoomOut()
    {
      if (tblLogMessage.Font.Size > MIN_ZOOM_LEVEL)
      {
        try
        {
          this.SuspendDrawing();

          tblLogMessage.Font = FontCache.GetFontFromIdentifier(
              Font.Name
            , tblLogMessage.Font.Size - 1
            , FontStyle.Regular);

          mBoldCaptionFont = FontCache.GetFontFromIdentifier(
              Font.Name
            , mBoldCaptionFont.Size - 1
            , FontStyle.Bold);

          lblCaptionLogger.Font     = mBoldCaptionFont;
          lblCaptionLevel.Font      = mBoldCaptionFont;
          lblCaptionThread.Font     = mBoldCaptionFont;
          lblCaptionDateTime.Font   = mBoldCaptionFont;
          lblCaptionMessage.Font    = mBoldCaptionFont;

          return tblLogMessage.Font.Size > MIN_ZOOM_LEVEL;
        }
        finally
        {
          this.ResumeDrawing();
        }
      }

      return false;
    }

    /// <summary>
    /// Applies the current theme to the <see cref="Control"/>.
    /// </summary>
    /// <param name="theme">The <see cref="BaseTheme"/> instance to apply.</param>
    public void ApplyTheme(BaseTheme theme)
    {
      tsbZoomIn.Image  = theme.Resources.Images["FrmMainTbZoomIn"];
      tsbZoomOut.Image = theme.Resources.Images["FrmMainTbZoomOut"];
      tsbCopy.Image    = theme.Resources.Images["FrmScriptTbCopy"];

      pbxCopyLogger.Image     = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyLevel.Image      = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyThread.Image     = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyDateTime.Image   = theme.Resources.Images["FrmScriptTbCopy"];
      pbxCopyMessage.Image    = theme.Resources.Images["FrmScriptTbCopy"];

      LogMessagePanel.BackColor  = theme.ColorPalette.ContentBackground;
      LogMessagePanel.ForeColor  = theme.ColorPalette.ContentForeground;
      
      txtDest.BackColor     = theme.ColorPalette.ContentBackground;
      txtDest.ForeColor     = theme.ColorPalette.ContentForeground;
      txtSize.BackColor      = theme.ColorPalette.ContentBackground;
      txtSize.ForeColor      = theme.ColorPalette.ContentForeground;
      txtDate.BackColor   = theme.ColorPalette.ContentBackground;
      txtDate.ForeColor   = theme.ColorPalette.ContentForeground;
      txtType.BackColor     = theme.ColorPalette.ContentBackground;
      txtType.ForeColor     = theme.ColorPalette.ContentForeground;
      txtDataMessage.BackColor    = theme.ColorPalette.ContentBackground;
      txtDataMessage.ForeColor    = theme.ColorPalette.ContentForeground;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates anew instance of the <see cref="Log4NetDetailsControl"/> <see cref="Control"/>.
    /// </summary>
    public Socks5DetailsControl()
    {
      InitializeComponent();

      // Apply the current application theme to the control.
      ThemeManager.ApplyTo(this);

      mBoldCaptionFont = FontCache.GetFontFromIdentifier(
          Font.Name
        , Font.Size
        , FontStyle.Bold);

      lblCaptionLogger.Font    = mBoldCaptionFont;
      lblCaptionLevel.Font     = mBoldCaptionFont;
      lblCaptionThread.Font    = mBoldCaptionFont;
      lblCaptionDateTime.Font  = mBoldCaptionFont;
      lblCaptionMessage.Font   = mBoldCaptionFont;

      _resetHexBoxEmpty();
    }

    private void _resetHexBoxEmpty()
    {
      hexBox1.ByteProvider = new DynamicByteProvider(Encoding.ASCII.GetBytes("No Packet Loaded"));
      hexBox1.ReadOnly = true;
    }

    private void _resetHexBox(byte[] buffer)
    {
      hexBox1.ByteProvider = new DynamicByteProvider(buffer);
      hexBox1.ReadOnly = true;
    }


    public string byteToHexStr(byte[] bytes)
    {
      string returnStr = "";
      if (bytes != null)
      {
        for (int i = 0; i < bytes.Length; i++)
        {
          returnStr += bytes[i].ToString("X2") + " ";
        }
      }
      return returnStr;
    }
    #endregion
  }
}
