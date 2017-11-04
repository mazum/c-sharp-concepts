using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace SoapSerializationOfAutomaticProperty
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
            Car car = new Car { IsHatchBack = false, Price = 20000 };
            
            MemoryStream stream = new MemoryStream();

            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, car);
            
            stream.Position = 0;

            return stream;
        }

        private static void Deserialize(Stream stream)
        {
            SoapFormatter formatter = new SoapFormatter();
            Car car = (Car)formatter.Deserialize(stream);
        }
    }
}
