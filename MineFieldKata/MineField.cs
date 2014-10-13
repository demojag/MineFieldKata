using System;

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

        private Mines _mines;

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
            _mines = mines;
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
            get { return _mines.GetUnexplodedMines(); }
        }
    }

    public class MineOwerflowException : Exception
    {
        public MineOwerflowException(string message)
            : base(message)
        {
        }
    }
}