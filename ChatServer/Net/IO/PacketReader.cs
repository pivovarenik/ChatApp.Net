using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Net.IO
{
    class PacketReader : BinaryReader
    {
        private NetworkStream _stream;
        public PacketReader(NetworkStream input) : base(input)
        {
            _stream = input;
        }
        public string ReadMessage()
        {
            byte[] msgBuf;
            var length = ReadInt32();
            msgBuf = new byte[length];
            _stream.Read(msgBuf, 0, length);
            var message = Encoding.ASCII.GetString(msgBuf);
            return message;
        }
    }
}
