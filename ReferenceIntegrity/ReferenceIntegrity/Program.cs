using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceIntegrity
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream();

            Address manufacturingAddress = new Address {POBox = "11", PostalCode = "22"};

            Address assemblingAddress = manufacturingAddress;

            Car car = new Car() {IsHatchBack = false, Model = 2014, Type = "Chev"};
            car._ManufacturingAddress = manufacturingAddress;
            car._AssemblingAddress = assemblingAddress;

            Console.WriteLine(object.ReferenceEquals(car._ManufacturingAddress, car._AssemblingAddress));

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, car);

            ms.Position = 0;

            Car car1 = (Car) formatter.Deserialize(ms);

            Console.WriteLine(object.ReferenceEquals(car1._ManufacturingAddress, car1._AssemblingAddress));

            Console.ReadLine();
        }
    }
}
