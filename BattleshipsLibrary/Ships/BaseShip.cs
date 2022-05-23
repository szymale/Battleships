using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Library.Ships
{
    public abstract class BaseShip
    {
        public string? Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public OccupationType OccupationType { get; set; }
        public bool IsSunk { get { return Hits >= Size; } }

    }
}
