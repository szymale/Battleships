using Battleships.Library.Boards;
using Battleships.Library.Ships;
using System.Linq;
using System.Collections;

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

        public void PlaceShips()
        {
            Random random = new Random();
            foreach ( var ship in Ships )
            {
                //
                bool proceed = true;
                while(proceed)
                {
                    var startColumn = random.Next(1,11);
                    var startRow = random.Next(1, 11);
                    int endRow = startRow;
                    int endColumn = startColumn;
                    var orientation = random.Next(1, 101) % 2;

                    List<int> cells = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Size; i++)
                        {
                            endRow++;
                        }
                    }
                    else
                    {
                        for (int j = 1; j < ship.Size; j++)
                        {
                            endColumn++;
                        }
                    }

                    if(endRow > 10 || endColumn > 10)
                    {
                        proceed = true;
                        continue;
                    }

                    var targetCells = Board.Cells.Where(x => x.Coordinates.Row >= startRow
                                                          && x.Coordinates.Column >= startColumn
                                                          && x.Coordinates.Row <= endRow
                                                          && x.Coordinates.Column <= endColumn).ToList();
                    
                    if (targetCells.Any(x => x.IsOccupied))
                    {
                        proceed = true;
                        continue;
                    }

                    foreach (var cell in targetCells)
                    {
                        cell.OccupationType = ship.OccupationType;
                    }

                    proceed = false;
                }
            }
        }
        
        public void PrintGameplayBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                                                           Enemy Board:");
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(Board.Cells.First(x => x.Coordinates.Row == i && x.Coordinates.Column == j).Status + "  ");
                }
                Console.Write("                                       ");
                for (int k = 1; k <= 10; k++)
                {
                    Console.Write(Board.Cells.First(x => x.Coordinates.Row == i && x.Coordinates.Column == k).Status + "  ");
                }
                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}
