using System;

namespace ContainerVervoer.Exceptions
{
    public class NotEnoughSpaceException : Exception
    {
        public NotEnoughSpaceException(string message) : base(message)
        {
            
        }
    }
}