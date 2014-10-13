using System;
using NUnit.Framework;

namespace MineFieldKata.Tests
{
    [TestFixture]
    public class CreateMineFieldTest
    {
        [Test]
        public void InputWithProperSize()
        {
            const int expectedWidth = 3;
            const int expectedHeight = 4;

            var field = new MineField(new Size(expectedHeight),new Size(expectedWidth));

            Assert.AreEqual(expectedHeight, field.Height.Value);
            Assert.AreEqual(expectedWidth, field.Width.Value);
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(3, -1)]
        [TestCase(-3, 1)]
        [TestCase(0, 0)]
        [TestCase(-3, -3)]
        public void InputInvalidNumber(int expectedWidth, int expectedHeight)
        {
            Assert.Throws<InvalidInputException>(() => new MineField(new Size(expectedHeight), new Size(expectedWidth)));
        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(String message)
            : base(message)
        {

        }
    }
}
