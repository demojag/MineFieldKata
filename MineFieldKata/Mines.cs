using System.Collections.Generic;
using System.Linq;
using MineFieldKata.Exceptions;

namespace MineFieldKata
{
    public class Mines
    {
        private readonly IList<Mine> _minesList;
        public int MineCount { get { return _minesList.Count(); } }

        public IList<Mine> Value
        {
            get { return new List<Mine>(_minesList); }
        }

        public Mines(int numberOfMines)
        {
            if (numberOfMines <= 0)
                throw new InvalidInputException("Mines cannot be less or equal to Zero");

            _minesList = new List<Mine>();
            for (var i = 0; i < numberOfMines; i++)
            {
                _minesList.Add(new Mine());
            }
        }

        public int GetUnexplodedMines()
        {
            return _minesList.Count(x => x.Exploded == false);
        }
    }
}