using MineFieldKata.Exceptions;

namespace MineFieldKata
{
    public class Mine : IMine, ICell
    {
        public bool Exploded { get; private set; }
       
        public bool Blast()
        {
            if (Exploded)
                throw new InvalidMineStateException("An exploded mine cannot blast twice");
            return Exploded = true;
        }

    }
}