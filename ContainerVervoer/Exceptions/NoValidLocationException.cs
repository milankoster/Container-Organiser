using System;

namespace ContainerVervoer.Exceptions
{
    public class NoValidLocationException : Exception
    {
        public string ErrorMessage { get; }

        public NoValidLocationException()
        {
            ErrorMessage = "Error: Unable to place all locations on the ship";
        }

    }
}