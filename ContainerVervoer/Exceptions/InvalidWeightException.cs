using System;

namespace ContainerVervoer.Exceptions
{
    public class InvalidWeightException : Exception
    {
        public InvalidWeightException(string message) : base(message)
        {
            
        }
    }
}