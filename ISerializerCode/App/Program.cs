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
            MemoryStream ms = new MemoryStream();

            Car car = new Car {Model = 2014, Type = "Chev"};
            car._Radio = new Radio {Type = "Sony"};
            car._Wheel = new Wheel {Diameter = 50};

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, car);

            ms.Position = 0;

            Car car1 = (Car) formatter.Deserialize(ms);

            Console.ReadLine();
        }
    }
}
