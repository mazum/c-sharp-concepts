using System;

namespace SoapSerializationOfProperty
{
    [Serializable]
    public class Car
    {
        public bool IsHatchBack;

        //To prove Property are not serialized. Only the underlying private variable is serialized. This is fine.
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}