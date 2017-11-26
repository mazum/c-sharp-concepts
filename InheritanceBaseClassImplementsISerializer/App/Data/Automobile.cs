using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    [Serializable]
    class Automobile : ISerializable
    {
        public string Type;
        public int Model;

        public Automobile()
        {
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", Type);
            info.AddValue("Model", Model);
        }

        protected Automobile(SerializationInfo info, StreamingContext context)
        {
            Type = info.GetString("Type");
            Model = info.GetInt16("Model");
        }
    }
}
