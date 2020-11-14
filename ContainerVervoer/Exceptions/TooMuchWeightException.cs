using System;

namespace ContainerVervoer.Exceptions
{
    public class TooMuchWeightException : Exception 
    {
        public TooMuchWeightException() : base("Ship would weigh too much")
        {
            
        }
    }
}