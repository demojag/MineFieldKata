using System;
using System.Collections.Generic;
using System.Linq;

namespace MineFieldKata
{
    public class MineField
    {
        public Size Height;
        public Size Width;

        public int CellCount
        {
            get { return Height.Value * Width.Value; }
        }

        private Dictionary<IPosition, Mine> _mines;

        public MineField(Size height, Size width)
        {
            if (height == null)
                throw new ArgumentNullException("height");
            if (width == null)
                throw new ArgumentNullException("width");

            Height = height;
            Width = width;
        }

        public void Populate(Mines mines)
        {
            if (mines == null)
                throw new ArgumentNullException("mines");

            ValidateMinesCount(mines);

            _mines = new Dictionary<IPosition, Mine>();

            foreach (var mine in mines.Value)
            {
                var rand = new Random();

                var hasKey = false;
                while (!hasKey)
                {
                    var x = rand.Next(0, Height.Value);
                    var y = rand.Next(0, Width.Value);
                    if (!_mines.ContainsKey(new Position(x, y)))
                    {
                        _mines.Add(new Position(x, y), mine);
                        hasKey = true;
                    }
                }
               
            }

        }

        private void ValidateMinesCount(Mines mines)
        {
            var unexplodedMines = mines.MineCount;
            if (unexplodedMines > CellCount)
                throw new MineOwerflowException(
                    String.Format("The field cell count is : {0} and the desired mines are :{1} this operation cannot be done ", CellCount, unexplodedMines));
        }

        public int ActiveMines
        {
            get { return _mines.Count(x => x.Value.Exploded == false); }
        }

    }

    public class Position : IPosition 
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Position;
            return other != null && (other.X == X) && (other.Y == Y);
        }
    }

    internal interface IPosition
    {
    }

    public interface ICell
    {

    }

    public class Cell : ICell
    {

    }

    public class MineOwerflowException : Exception
    {
        public MineOwerflowException(string message)
            : base(message)
        {
        }
    }
}