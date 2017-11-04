using System;

namespace SoapSerializationOfAutomaticProperty
{
    [Serializable]
    public class Car
    {
        public bool IsHatchBack;

        //Automatic Properties should never be deserialized. As we can't guarantee the deserialized property name. Random name is generated.
        public decimal Price { get; set; }
    }
}