using System;
using System.Globalization;
using System.Net;
using Couchcoding.Logbert.Logging;
using Couchcoding.Logbert.Properties;

namespace Couchcoding.Logbert.Receiver.Socks5Receiver
{
  public class LogMessageSocks5: LogMessage
  {
    public LogMessageSocks5(
            byte[] rawData,
            int index,
            MessageType messageType, 
            IPEndPoint ipEndPoint) : base(rawData, index)
    {
      Level = LogLevel.Debug;
      MessageType = messageType;
      IpEndPoint = ipEndPoint;
      Message = rawData.ToString();
      Timestamp = DateTime.Now;
      Buffer = rawData;
    }

    public byte[] Buffer { get; }

    public int Size => Buffer.Length;

    public MessageType MessageType { get; }
    public IPEndPoint IpEndPoint { get; }
    public override DateTime Timestamp { get; }
    public override string Message { get; }
    public override LogLevel Level { get; }
    public override object GetValueForColumn(int columnIndex)
    {
      switch (columnIndex)
      {
        case 1:
          return mIndex;
        case 2:
          return MessageType.ToString();
        case 3:
          return Timestamp.Add(mTimeShiftOffset).ToString(
            Settings.Default.TimestampFormat
            , CultureInfo.InvariantCulture);
        case 4:
          return IpEndPoint.Address.ToString();
        case 5:
          return IpEndPoint.Port;
        case 6:
          return Size;
      }
      return null;
    }
  }
}
