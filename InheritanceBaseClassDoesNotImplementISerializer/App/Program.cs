using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.IsHatchback = false;
            car.Model = 2014;
            car.Type = "Chev";

            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, car);

            ms.Position = 0;

            Car car1 = (Car) formatter.Deserialize(ms);

            Console.ReadLine();
        }
    }
}
