using System.ComponentModel;

namespace Battleships.Library
{
    public enum OccupationType
    {
        [Description("Empty")]
        O,

        [Description("Miss")]
        M,

        [Description("Hit")]
        X,

        [Description("Ship")]
        S
    }

    public enum ShotResult
    {
        Miss,
        Hit
    }
}
