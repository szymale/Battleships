using Battleships.Library.Boards;
using Battleships.Library.Ships;

namespace Battleships.Library
{
    public class Player
    {
        public string Name { get; set; }
        public Board Board { get; set; }
        public AimBoard AimBoard { get; set; }
        public List<BaseShip> Ships { get; set; }

        public bool HasLoast
        {
            get { return Ships.All(x => x.IsSunk); }
        }

        public Player(string name)
        {
            Name = name;
            Ships = new List<BaseShip>()
            {
                new Carrier(),
                new Battleship(),
                new Destroyer(),
                new Submarine(),
                new PatrolBoat()
            };
            Board = new Board();
            AimBoard = new AimBoard();
        }

    }
}
