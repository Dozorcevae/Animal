using System;

namespace Animals.Domain
{
    // Исключение для некорректного веса.
    public class InvalidWeightException : Exception
    {
        public InvalidWeightException(string message) : base(message) { }
    }
}

