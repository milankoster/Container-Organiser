using System;

namespace ContainerVervoer.Exceptions
{
    public class NoValidLocationException : Exception
    {
        public NoValidLocationException() : base("Unable to place all containers on the ship")
        {
            
        }
    }
}