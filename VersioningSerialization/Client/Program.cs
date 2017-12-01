using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using LibV1;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = Serialize();
            TransmitMessage(stream);

            Console.ReadLine();
        }

        private static Stream Serialize()
        {
            Car_V1 car = new Car_V1
            {
                Type = "Chev",
                Model = 2015,
                IsHatchback = false
            };

            MemoryStream stream = new MemoryStream();

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, car);

            stream.Position = 0;

            return stream;
        }

        static void TransmitMessage(Stream stream)
        {
            using (var s = new NamedPipeClientStream("pipe1"))
            {
                Console.WriteLine("press enter to write message to pipe");
                Console.ReadLine();

                s.Connect();

                byte[] msg = ((MemoryStream)stream).ToArray();
                s.Write(msg, 0, msg.Length);

                Console.WriteLine("message written to pipe");
            }
        }
    }
}
