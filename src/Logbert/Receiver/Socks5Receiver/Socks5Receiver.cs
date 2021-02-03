#region Copyright © 2015 Couchcoding

// File:    Log4NetUdpReceiver.cs
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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Couchcoding.Logbert.Interfaces;

using Couchcoding.Logbert.Controls;
using Couchcoding.Logbert.Helper;
using Couchcoding.Logbert.Logging;
using socks5;
using socks5.TCP;

namespace Couchcoding.Logbert.Receiver.Socks5Receiver
{
  /// <summary>
  /// Implements a <see cref="ILogProvider"/> for the Log4Net UDP service.
  /// </summary>
  public class Socks5Receiver : ReceiverBase
  {
    #region Private Fields

    private int _port;

    /// <summary>
    /// Counts the received messages;
    /// </summary>
    private int mLogNumber;

    #endregion

    #region Private Types

    /// <summary>
    /// Implements a state object for UDP communication.
    /// </summary>
    private class UdpState
    {
      #region Public Properties

      /// <summary>
      /// Gets the <see cref="UdpClient"/> that will receive messages.
      /// </summary>
      internal UdpClient Client
      {
        get;
        private set;
      }

      /// <summary>
      /// Gets the <see cref="IPEndPoint"/> to listen on.
      /// </summary>
      internal IPEndPoint EndPoint
      {
        get;
        private set;
      }

      #endregion

      #region Constructor

      /// <summary>
      /// Creates a new instance of the <see cref="UdpState"/> type.
      /// </summary>
      /// <param name="client">The <see cref="UdpClient"/> that will receive messages.</param>
      /// <param name="endPoint">The <see cref="IPEndPoint"/> to listen on.</param>
      internal UdpState(UdpClient client, IPEndPoint endPoint)
      {
        Client   = client;
        EndPoint = endPoint;
      }

      #endregion
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="ILogProvider"/>.
    /// </summary>
    public override string Name
    {
      get
      {
        return "Socks5";
      }
    }

    /// <summary>
    /// Gets the description of the <see cref="ILogProvider"/>
    /// </summary>
    public override string Description
    {
      get
      {
        return string.Format("Port:{0}",_port);
      }
    }

    /// <summary>
    /// Gets the filename for export of the received <see cref="LogMessage"/>s.
    /// </summary>
    public override string ExportFileName
    {
      get
      {
        return string.Format("Port:{0}", _port);
      }
    }

    /// <summary>
    /// Gets the settings <see cref="Control"/> of the <see cref="ILogProvider"/>.
    /// </summary>
    public override ILogSettingsCtrl Settings
    {
      get
      {
        return new Socks5ReceiverSettings();
      }
    }

    /// <summary>
    /// Gets the columns to display of the <see cref="ILogProvider"/>.
    /// </summary>
    public override Dictionary<int, LogColumnData> Columns
    {
      get
      {

        return new Dictionary<int, LogColumnData>
        {
          { 0, new LogColumnData("Id",    true, 40 )},
          { 1, new LogColumnData("Type",      true, 70 )},
          { 2, new LogColumnData("Timestamp",  true, 100) },
          { 3, new LogColumnData("IP",    true, 100) },
          { 4, new LogColumnData("Port",   true, 50) },
          { 5, new LogColumnData("Size", true, 50) },
        };
      }
    } 

    /// <summary>
    /// Determines whether this <see cref="ILogProvider"/> supports reloading of the content, ot not.
    /// </summary>
    public override bool SupportsReload
    {
      get
      {
        return false;
      }
    }

    /// <summary>
    /// Get the <see cref="Control"/> to display details about a selected <see cref="LogMessage"/>.
    /// </summary>
    public override ILogPresenter DetailsControl
    {
      get
      {
        return new Socks5DetailsControl();
      }
    }

	  /// <summary>
	  /// Gets or sets the active state if the <see cref="ILogProvider"/>.
	  /// </summary>
	  public override bool IsActive
    {
      get
      {
        return base.IsActive;
      }
      set
      {
        base.IsActive = value;

        if (!mIsActive)
        {
          Shutdown();
        }
        else
        {
          Initialize(mLogHandler);
        }
      }
    }

    #endregion

    #region Private Methods


    #endregion

    #region Public Methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return Name;
    }

    /// <summary>
    /// Intizializes the <see cref="ILogProvider"/>.
    /// </summary>
    /// <param name="logHandler">The <see cref="ILogHandler"/> that may handle incomming <see cref="LogMessage"/>s.</param>
    public override void Initialize(ILogHandler logHandler)
    {
      base.Initialize(logHandler);
    }

    /// <summary>
    /// Shuts down the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Shutdown()
    {

      base.Shutdown();
    }

    /// <summary>
    /// Gets the header used for the CSV file export.
    /// </summary>
    /// <returns></returns>
    public override string GetCsvHeader()
    {
      return "\"Id\","
           + "\"Type\","
           + "\"Timestamp\","
           + "\"Ip\","
           + "\"Port\","
           + "\"Size\","
           + Environment.NewLine;
    }

    /// <summary>
    /// Resets the <see cref="ILogProvider"/> instance.
    /// </summary>
    public override void Clear()
    {
      mLogNumber = 0;
    }

    /// <summary>
    /// Saves the current docking and collumn layout of the <see cref="ILogProvider"/> implementation.
    /// </summary>
    /// <param name="layout">The layout as string to save.</param>
    /// <param name="columnLayout">The current column layout to save.</param>
    public override void SaveLayout(string layout, List<LogColumnData> columnLayout)
    {
      Properties.Settings.Default.DockLayoutLog4NetUdpReceiver = layout ?? string.Empty;

      Properties.Settings.Default.ColumnVisibleLog4NetUdpReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5}"
        , columnLayout[0].Visible ? 1 : 0
        , columnLayout[1].Visible ? 1 : 0
        , columnLayout[2].Visible ? 1 : 0
        , columnLayout[3].Visible ? 1 : 0
        , columnLayout[4].Visible ? 1 : 0
        , columnLayout[5].Visible ? 1 : 0);

      Properties.Settings.Default.ColumnWidthLog4NetUdpReceiver = string.Format(
          "{0},{1},{2},{3},{4},{5}"
        , columnLayout[0].Width
        , columnLayout[1].Width
        , columnLayout[2].Width
        , columnLayout[3].Width
        , columnLayout[4].Width
        , columnLayout[5].Width);

      Properties.Settings.Default.SaveSettings();
    }

    /// <summary>
    /// Loads the docking layout of the <see cref="ReceiverBase"/> instance.
    /// </summary>
    /// <returns>The restored layout, or <c>null</c> if none exists.</returns>
    public override string LoadLayout()
    {
      return Properties.Settings.Default.DockLayoutLog4NetUdpReceiver;
    }

    #endregion

    #region Constructor

    private Socks5Server _socks5Server;

    /// <summary>
    /// Creates a new and empty instance of the <see cref="Log4NetUdpReceiver"/> class.
    /// </summary>
    public Socks5Receiver()
    {
    }

    /// <summary>
    /// Creates a new and configured instance of the <see cref="Log4NetUdpReceiver"/> class.
    /// </summary>
    /// <param name="multicastIp">The multicast IP address to listen for.</param>
    /// <param name="listenInterface">The network interface to listen on.</param>
    /// <param name="codePage">The codepage to use for encoding of the data to parse.</param>
    public Socks5Receiver(int port, int codePage, Socks5Server socks5Server) : base(codePage)
    {
      _port = port;
      _socks5Server = socks5Server;
      _socks5Server.OnDataSent += _onDataSent;
      _socks5Server.OnDataReceived += _onDataReceived;

    }

    private void _onDataReceived(DataEventArgs e)
    {
      var b = new byte[e.Count];
      Array.Copy(e.Buffer, b, e.Count);
      LogMessage newLogMsg = new LogMessageSocks5(
          b,
          ++mLogNumber,
          MessageType.Receive,
          new IPEndPoint(e.Request.IP,e.Request.Port)
        );
      mLogHandler?.HandleMessage(newLogMsg);
    }

    private void _onDataSent(DataEventArgs e)
    {
      var b = new byte[e.Count];
      Array.Copy(e.Buffer, b, e.Count);
      LogMessage newLogMsg = new LogMessageSocks5(
        b,
        ++mLogNumber,
        MessageType.Send,
        new IPEndPoint(e.Request.IP, e.Request.Port)
      );
      mLogHandler?.HandleMessage(newLogMsg);
    }

    #endregion
  }
}
