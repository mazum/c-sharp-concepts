using System;

namespace ReferenceIntegrity
{
    [Serializable]
    public class Car
    {
        public bool IsHatchBack;

        public string Type;

        public int Model;

        public Address _ManufacturingAddress;
        public Address _AssemblingAddress;
    }
}