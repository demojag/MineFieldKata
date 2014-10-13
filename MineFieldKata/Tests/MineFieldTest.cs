using System;
using MineFieldKata.Exceptions;
using NUnit.Framework;

namespace MineFieldKata.Tests
{
    [TestFixture]
    public class MineFieldTest
    {
        const int ExpectedWidth = 3;
        const int ExpectedHeight = 4;
        const int ExpectedMines = 3;

        [Test]
        public void CreateWithInputOfProperSize()
        {
            const int expectedWidth = 3;
            const int expectedHeight = 4;

            var field = new MineField(new Size(expectedHeight), new Size(expectedWidth));

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
        public void CreateWithInputOfInvalidNumber(int width, int height)
        {
            Assert.Throws<InvalidInputException>(() => new MineField(new Size(height), new Size(width)));
        }

        [Test]
        public void CreateWithInputNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MineField(null, null));
        }

        [Test]
        public void AssignNumberOfMines()
        {
            var field = new MineField(new Size(ExpectedHeight), new Size(ExpectedWidth));
            field.Populate(new Mines(ExpectedMines));

            Assert.AreEqual(ExpectedMines, field.ActiveMines);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void AssignInvalidNumberOfMines(int expectedMines)
        {
            const int expectedWidth = 3;
            const int expectedHeight = 4;

            var field = new MineField(new Size(expectedHeight), new Size(expectedWidth));
            Assert.Throws<InvalidInputException>(() => field.Populate(new Mines(expectedMines)));

        }

        [Test]
        public void AssignNumberOfMinesAboveFieldSize()
        {
            const int invalidNumberOfMines = 100;

            var field = new MineField(new Size(ExpectedHeight), new Size(ExpectedWidth));
            Assert.Throws<MineOwerflowException>(() => field.Populate(new Mines(invalidNumberOfMines)));
        }

        [Test]
        public void AssignNullMines()
        {
            var field = new MineField(new Size(3), new Size(3));
            Assert.Throws<ArgumentNullException>(() => field.Populate(null));

        }
    }
}
