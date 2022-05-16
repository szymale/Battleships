using System.ComponentModel;

namespace Battleships.Library
{
    public enum OccupationType
    {
        [Description("o")]
        Empty,

        [Description("m")]
        Miss,

        [Description("x")]
        Hit,

        [Description("s")]
        Ship
    }

    public enum ShotResult
    {
        Miss,
        Hit
    }
}
