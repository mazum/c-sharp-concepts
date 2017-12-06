using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace App
{
    class CarSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Car car = (Car) obj;

            info.AddValue("Model", car.Model);
            info.AddValue("Type", car.Type);
            info.AddValue("IsHatchback", car.IsHatchback);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context,
            ISurrogateSelector selector)
        {
            Car car = (Car)obj;

            car.Model = info.GetInt32("Model");
            car.Type = info.GetString("Type");
            car.IsHatchback = info.GetInt32("IsHatchback");

            return car;

            //or we could do the following to save "obj" and return null
            //((SurrogateLib.Car)obj).Model = info.GetInt32("Model");
            //((SurrogateLib.Car)obj).Type = info.GetString("Type");
            //((SurrogateLib.Car)obj).IsHatchback = info.GetInt32("IsHatchback");
            //return null;
        }
    }
}
