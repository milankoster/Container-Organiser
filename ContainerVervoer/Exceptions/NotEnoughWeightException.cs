using System;

namespace ContainerVervoer.Exceptions
{
    public class NotEnoughWeightException : Exception
    {
        public NotEnoughWeightException() : base("Ship wouldn't weigh enough")
        {
            
        }
    }
}