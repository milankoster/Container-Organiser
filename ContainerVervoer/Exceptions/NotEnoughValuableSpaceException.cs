using System;

namespace ContainerVervoer.Exceptions
{
    public class NotEnoughValuableSpaceException : Exception
    {
        public NotEnoughValuableSpaceException() : base("Not all valuable containers can be placed on the ship")
        {
            
        }
    }
}