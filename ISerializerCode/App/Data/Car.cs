using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    [Serializable]
    class Car : ISerializable
    {
        public string Type;
        public int Model;

        public Radio _Radio;
        public Wheel _Wheel;

        public Car()
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", Type);
            info.AddValue("Model", Model);

            info.AddValue("Radio", _Radio);
            info.AddValue("Wheel", _Wheel);

        }

        protected Car(SerializationInfo info, StreamingContext context)
        {
            Type = info.GetString("Type");
            Model = info.GetInt32("Model");

            _Radio = (Radio) info.GetValue("Radio", typeof(Radio));
            _Wheel = (Wheel) info.GetValue("Wheel", typeof(Wheel));
        }
    }
}
