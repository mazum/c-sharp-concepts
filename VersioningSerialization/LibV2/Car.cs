using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibV2
{
    [Serializable]
    public class Car_V2: ISerializable
    {
        public string Type;
        public int Model;
        public int IsHatchback;

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", Type);
            info.AddValue("Model", Model);
        }

        private Car_V2(SerializationInfo info, StreamingContext context)
        {
            Model = info.GetInt32("Model");

            if (info.GetString("Type") == "Chev")
                Type = "CH";
            else Type = info.GetString("Type");

            IsHatchback = info.GetInt32("IsHatchback");
        }
    }
}
