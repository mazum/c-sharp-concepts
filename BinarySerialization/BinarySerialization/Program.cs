using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TypeLib;

namespace BinarySerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = Serialize();

            Console.WriteLine(new StreamReader(stream).ReadToEnd());

            stream.Position = 0;

            Deserialize(stream);

            Console.ReadLine();
        }

        private static Stream Serialize()
        {
            Car car = new Car { Type = "Chev", Model = 2015, IsHatchBack = false };
            car._Wheel = new Wheel { Diameter = 40 };

            Truck truck = new Truck { Type = "Toyota", Model = 2015, IsSemi = false };
            truck._Wheel = new Wheel { Diameter = 80 };

            MemoryStream stream = new MemoryStream();

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, car);
            formatter.Serialize(stream, truck);

            stream.Position = 0;

            return stream;
        }

        private static void Deserialize(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Car car = (Car)formatter.Deserialize(stream);
            Truck truck = (Truck)formatter.Deserialize(stream);
        }
    }
}
