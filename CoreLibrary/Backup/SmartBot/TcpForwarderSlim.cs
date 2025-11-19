// Decompiled with JetBrains decompiler
// Type: SmartBot.TcpForwarderSlim
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Net;
using System.Net.Sockets;

#nullable disable
namespace SmartBot;

public class TcpForwarderSlim
{
  private readonly Socket _mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

  public void Start(IPEndPoint local, IPEndPoint remote)
  {
    this._mainSocket.Bind((EndPoint) local);
    this._mainSocket.Listen(10);
    while (true)
    {
      Socket socket = this._mainSocket.Accept();
      TcpForwarderSlim tcpForwarderSlim = new TcpForwarderSlim();
      TcpForwarderSlim.State state = new TcpForwarderSlim.State(socket, tcpForwarderSlim._mainSocket);
      tcpForwarderSlim.Connect((EndPoint) remote, socket);
      socket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, new AsyncCallback(TcpForwarderSlim.OnDataReceive), (object) state);
    }
  }

  private void Connect(EndPoint remoteEndpoint, Socket destination)
  {
    TcpForwarderSlim.State state = new TcpForwarderSlim.State(this._mainSocket, destination);
    this._mainSocket.Connect(remoteEndpoint);
    this._mainSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, new AsyncCallback(TcpForwarderSlim.OnDataReceive), (object) state);
  }

  private static void OnDataReceive(IAsyncResult result)
  {
    TcpForwarderSlim.State asyncState = (TcpForwarderSlim.State) result.AsyncState;
    try
    {
      int size = asyncState.SourceSocket.EndReceive(result);
      if (size <= 0)
        return;
      asyncState.DestinationSocket.Send(asyncState.Buffer, size, SocketFlags.None);
      asyncState.SourceSocket.BeginReceive(asyncState.Buffer, 0, asyncState.Buffer.Length, SocketFlags.None, new AsyncCallback(TcpForwarderSlim.OnDataReceive), (object) asyncState);
    }
    catch
    {
      asyncState.DestinationSocket.Close();
      asyncState.SourceSocket.Close();
    }
  }

  private class State
  {
    public Socket SourceSocket { get; private set; }

    public Socket DestinationSocket { get; private set; }

    public byte[] Buffer { get; private set; }

    public State(Socket source, Socket destination)
    {
      this.SourceSocket = source;
      this.DestinationSocket = destination;
      this.Buffer = new byte[8192 /*0x2000*/];
    }
  }
}
