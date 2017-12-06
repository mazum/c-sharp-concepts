using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Type = "Chev";
            car.Model = 2015;
            car.IsHatchback = 0;

            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter=new BinaryFormatter();

            CarSurrogate carSurrogate = new CarSurrogate();

            SurrogateSelector surrogateSelector = new SurrogateSelector();
            surrogateSelector.AddSurrogate(typeof(Car), new StreamingContext(StreamingContextStates.All), carSurrogate);

            formatter.SurrogateSelector = surrogateSelector;

            formatter.Serialize(stream, car);

            stream.Position = 0;

            Car deserializedCar = (Car) formatter.Deserialize(stream);


        }
    }
}
