using Battleships.Library.Extensions;

namespace Battleships.Library.Boards
{
    public class AimBoard : Board
    {
        public List<Coordinates> GetOpenRandomCells()
        {
            return Cells.Where(x => x.OccupationType == OccupationType.Empty).Select(x => x.Coordinates).ToList();
        }
        public List<Coordinates> GetHitNeighbours()
        {
            List<Cell> cells = new List<Cell>();
            var hits = Cells.Where(x => x.OccupationType == OccupationType.Hit);
            foreach (var hit in hits)
            {
                cells.AddRange(GetNeighbours(hit.Coordinates).ToList());
            }
            return cells.Distinct()
                        .Where(x => x.OccupationType == OccupationType.Empty)
                        .Select(x => x.Coordinates)
                        .ToList();
        }
        public List<Cell> GetNeighbours(Coordinates coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Cell> cells = new List<Cell>();
            if (column > 1)
            {
                cells.Add(Cells.At(row, column - 1));
            }
            if (row > 1)
            {
                cells.Add(Cells.At(row - 1, column));
            }
            if (row < 10)
            {
                cells.Add(Cells.At(row + 1, column));
            }
            if (column < 10)
            {
                cells.Add(Cells.At(row, column + 1));
            }
            return cells;
        }
    }
}
