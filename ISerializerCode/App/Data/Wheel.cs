using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    [Serializable]
    class Wheel : ISerializable
    {
        public int Diameter;

        public Wheel()
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Diameter", Diameter);
        }

        public Wheel(SerializationInfo info, StreamingContext context)
        {
            Diameter = info.GetInt32("Diameter");
        }
    }
}
