using Battleships.Library.Boards;
using Battleships.Library.Ships;
using System.Linq;
using System.Collections;
using Battleships.Library.Extensions;

namespace Battleships.Library
{
    public class Player
    {
        public string? Name { get; set; }
        public Board Board { get; set; }
        public AimBoard AimBoard { get; set; }
        public List<BaseShip> Ships { get; set; }

        public bool HasLost
        {
            get { return Ships.All(x => x.IsSunk); }
        }

        public Player(string? name)
        {
            if (name is null)
            {
                Console.WriteLine("Player Name should be different than null");
            }

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
            Random random = new (Guid.NewGuid().GetHashCode());
            foreach ( var ship in Ships )
            {
                bool proceed = true;
                while(proceed)
                {
                    int startColumn = random.Next(1, 11);
                    int startRow = random.Next(1, 11);
                    int endRow = startRow;
                    int endColumn = startColumn;
                    var orientation = random.Next(1, 101) % 2;

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

                    if (endRow > 10 || endColumn > 10)
                    {
                        proceed = true;
                        continue;
                    }

                    var targetCells = Board.Cells.Range(startRow, startColumn, endRow, endColumn);
                    
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
                    Console.Write(Board.Cells.At(i, j).Status + "  ");
                }
                Console.Write("                                       ");
                for (int k = 1; k <= 10; k++)
                {
                    Console.Write(AimBoard.Cells.At(i, k).Status + "  ");
                }
                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine);
        }

        public ShotResult ProcessShot(Coordinates coordinates)
        {
            var cell = Board.Cells.At(coordinates.Row, coordinates.Column);

            if (!cell.IsOccupied)
            {
                Console.WriteLine(Name + " says: Miss!");
                return ShotResult.Miss;
            }

            var ship = Ships.First(x => x.OccupationType == cell.OccupationType);

            ship.Hits++;

            Console.WriteLine(Name + " says: Hit!");

            if (ship.IsSunk)
            {
                Console.WriteLine(Name + " says: Ship " + ship.Name + " is destoryed!");
            }
            return ShotResult.Hit; 
        }

        public void ProcessShotResult(Coordinates coordinates, ShotResult shot)
        {
            var cell = AimBoard.Cells.At(coordinates.Row, coordinates.Column);

            if (shot == ShotResult.Hit)
            {
                cell.OccupationType = OccupationType.Hit;
            }
            else
            {
                cell.OccupationType = OccupationType.Miss;
            }
        }

        public Coordinates FireShoot()
        { 
            var hitNeighbours = AimBoard.GetHitNeighbours();
            Coordinates coordinates;

            if (hitNeighbours.Any())
            {
                coordinates = SearchingShoot();
            }
            else
            {
                coordinates = RandomShoot();
            }

            Console.WriteLine(Name + " says: \"Firing shoot at " + coordinates.Row.ToString() + ", " + coordinates.Column.ToString() + "\"");

            return coordinates;
        }

        private Coordinates RandomShoot()
        {
            var possibleCells = AimBoard.GetOpenRandomCells();
            Random random = new(Guid.NewGuid().GetHashCode());
            var cellId = random.Next(possibleCells.Count);
            return possibleCells[cellId];
        }

        private Coordinates SearchingShoot()
        { 
            Random random = new(Guid.NewGuid().GetHashCode());
            var hitNeighbours = AimBoard.GetHitNeighbours();
            var cellId = random.Next(hitNeighbours.Count);
            return hitNeighbours[cellId];
        }
    }
}
