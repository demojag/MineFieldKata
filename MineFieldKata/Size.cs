using MineFieldKata.Exceptions;
using MineFieldKata.Tests;

namespace MineFieldKata
{
    public class Size : ISizeValidator
    {
        private readonly int _value;

        public int Value
        {
            get { return _value; }
        }

        public Size(int value)
        {
            _value = value;
            Validate();
        }

        public void Validate()
        {
            if (_value <= 0)
                throw new InvalidInputException("Size must be non negative and above zero");
        }
    }
}