using System;

namespace MineFieldKata.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(String message)
            : base(message)
        {

        }
    }
}