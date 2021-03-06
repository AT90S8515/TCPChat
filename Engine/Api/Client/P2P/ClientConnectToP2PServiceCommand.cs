﻿using System;
using System.Net;
using System.Security;
using Engine.Model.Client;
using ThirtyNineEighty.BinarySerializer;

namespace Engine.Api.Client.P2P
{
  [SecurityCritical]
  class ClientConnectToP2PServiceCommand :
    ClientCommand<ClientConnectToP2PServiceCommand.MessageContent>
  {
    public const long CommandId = (long)ClientCommandId.ConnectToP2PService;

    public override long Id
    {
      [SecuritySafeCritical]
      get { return CommandId; }
    }

    [SecuritySafeCritical]
    protected override void OnRun(MessageContent content, CommandArgs args)
    {
      var address = ClientModel.Client.RemotePoint.Address;
      var endPoint = new IPEndPoint(address, content.Port);

      ClientModel.Peer.ConnectToService(endPoint);
    }

    [Serializable]
    [BinType("ClientConnectToP2PService")]
    public class MessageContent
    {
      [BinField("p")]
      public int Port;
    }
  }
}
