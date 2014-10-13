using System;

namespace MineFieldKata.Exceptions
{
    public class InvalidMineStateException : Exception
    {
        public InvalidMineStateException(string message)
            : base(message)
        {
        }
    }
}