using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    [Serializable]
    class Car : Automobile
    {
        public bool IsHatchback;

        public Car()
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("IsHatchback", IsHatchback);
        }

        protected Car(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            IsHatchback = info.GetBoolean("IsHatchback");
        }
    }
}
