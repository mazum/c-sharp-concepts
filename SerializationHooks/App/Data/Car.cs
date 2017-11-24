using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    [Serializable]
    class Car
    {
        public string RentedBy;
        public int RentDays;

        [NonSerialized] private int RentalRate;

        [NonSerialized] private int TotalRent;

        public Car()
        {
            //Read rate from a web service
            RentalRate = 50;
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            //For some reason, this is secret stuff!
            RentedBy = "encrypted";
        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            RentedBy = "decrypted";
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            //Read rate from a web service
            RentalRate = 50;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            TotalRent = RentalRate * RentDays;
        }
    }
}
