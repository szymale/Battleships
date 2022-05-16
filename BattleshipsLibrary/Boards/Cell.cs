namespace Battleships.Library.Boards
{
    public class Cell
    {
        public OccupationType OccupationType { get; set; }
        public Coordinates Coordinates { get; set; }

        public Cell(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.O;
        }

        public string Status
        { 
            get { return OccupationType.ToString(); }
        }

        public bool IsOccupied
        {
            get { return OccupationType == OccupationType.S; }
        }

        public bool IsRandomAvailable
        {
            get
            {
                return (Coordinates.Row % 2 == 0 && Coordinates.Column % 2 == 0)
                    || (Coordinates.Row % 2 == 1 && Coordinates.Column % 2 == 1);
            }
        }
    }
}
