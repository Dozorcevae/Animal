using System;

namespace Animals.Models{
    public class InvalidWeigthException : Exception {
        public InvalidWeigthException(string message) : base(message) { }
    }
}