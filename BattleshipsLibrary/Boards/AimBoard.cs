namespace Battleships.Library.Boards
{
    public class AimBoard : Board
    {
        public List<Coordinates> GetOpenRandomCells { get; set; }
        public List<Coordinates> GetHitNeighbours { get; set; }
        //public List<Cell> GetNeighbours(Coordinates coordinates) { }
    }
}
