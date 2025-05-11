using System;

namespace Animals.Models
{
    public class InvalidWeightException : Exception
    {
        public InvalidWeightException(string message) : base(message) { }
    }
}
