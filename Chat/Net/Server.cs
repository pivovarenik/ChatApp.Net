using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Chat.Net.IO;
using System.Threading.Tasks;

namespace Chat.Net
{
    class Server
    {
        TcpClient _client;
        public PacketReader PacketReader;

        public event Action connectedEvent;
        public event Action msgReceivedEvent;
        public event Action disconnectedEvent;

        public Server()
        {
            _client = new TcpClient();
        }

        public void ConnectToServer(string username, string imageUri)
        {
            if (!_client.Connected)
            {
                _client.Connect("127.0.0.1", 7691);
                PacketReader = new PacketReader(_client.GetStream());
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(imageUri))
                {
                    var connectPacket = new PacketBuilder();
                    connectPacket.WriteOpCode(0);
                    connectPacket.WriteMsg(username);
                    connectPacket.WriteMsg(imageUri); 
                    _client.Client.Send(connectPacket.GetPacketBytes());
                }
                ReadPackets();
            }
        }
        private void ReadPackets()
        {
            Task.Run(() =>
            {
                while(true)
                {
                    var opcode = PacketReader.ReadByte();
                    switch (opcode)
                    {
                        case 0:break;
                        case 1:connectedEvent?.Invoke();
                            break;
                        case 5:msgReceivedEvent?.Invoke();
                            break;
                        case 10:disconnectedEvent?.Invoke();
                            break;
                        default:Console.WriteLine("непонятная операция");
                            break;
                    }
                }
            });
        }
        public void SendMessageToServer(string data,string username) 
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMsg(data);
            _client.Client.Send(messagePacket.GetPacketBytes());
        }
    }
}
