using Battleships.Library.Extensions;
using System.ComponentModel;

namespace Battleships.Library.Boards
{
    public class Cell
    {
        public OccupationType OccupationType { get; set; }
        public Coordinates Coordinates { get; set; }

        public Cell(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.Empty;
        }

        public string Status
        { 
            get { return OccupationType.GetAttributeOfType<DescriptionAttribute>().Description; }
        }

        public bool IsOccupied
        {
            get
            {
                return OccupationType == OccupationType.Battleship
                    || OccupationType == OccupationType.Destroyer
                    || OccupationType == OccupationType.Cruiser
                    || OccupationType == OccupationType.Submarine
                    || OccupationType == OccupationType.PatrolBoat
                    || OccupationType == OccupationType.Carrier;

            }
        }
    }
}
