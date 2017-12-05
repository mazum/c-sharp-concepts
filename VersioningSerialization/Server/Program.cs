using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = ReceiveMessage();
            DeserializeV2(stream);

            Console.WriteLine("press enter to finish");
            Console.ReadLine();
        }

        static Stream ReceiveMessage()
        {
            using (var s = new NamedPipeServerStream("pipe1", PipeDirection.InOut, 1, PipeTransmissionMode.Message))
            {
                s.WaitForConnection();

                int counter = 1;
                StringBuilder message = new StringBuilder();
                string chunk = "";

                byte[] buffer = new byte[30]; //Read in blocks

                MemoryStream stream = new MemoryStream();

                do
                {
                    s.Read(buffer, 0, buffer.Length);

                    //pipestream does not support seaking
                    stream.Write(buffer, 0, buffer.Length);

                    chunk = Encoding.ASCII.GetString(buffer);
                    message.Append(chunk);
                    Console.WriteLine("chunk " + counter.ToString() + "read: " + chunk);

                    Array.Clear(buffer, 0, buffer.Length);

                    Thread.Sleep(1000);
                } while (!s.IsMessageComplete);

                stream.Position = 0;
                return stream;
            }
        }

        static void DeserializeV2(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Binder = new ServerBinder();

            LibV2.Car_V2 car = (LibV2.Car_V2) formatter.Deserialize(stream);
        }
    }
}
