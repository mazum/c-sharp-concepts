using System;

namespace TypeLib
{
    [Serializable]
    public abstract class Automobile
    {
        public string Type;
        public int Model;

        public Wheel _Wheel;
    }
}