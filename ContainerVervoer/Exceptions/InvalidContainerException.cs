using System;

namespace ContainerVervoer.Exceptions
{
    public class InvalidContainerException : Exception
    {
        public InvalidContainerException(string message) : base(message)
        {
            
        }
    }
}