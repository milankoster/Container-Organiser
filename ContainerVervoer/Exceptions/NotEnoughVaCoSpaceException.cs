using System;

namespace ContainerVervoer.Exceptions
{
    public class NotEnoughVaCoSpaceException : Exception
    {
        public NotEnoughVaCoSpaceException() : base("Not all valuable+cooled containers can be placed on the ship")
        {
            
        }
    }
}