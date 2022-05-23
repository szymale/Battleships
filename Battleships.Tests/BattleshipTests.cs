using Battleships.Library;
using Battleships.Library.Boards;
using Battleships.Library.Ships;
using System.Collections.Generic;
using Xunit;

namespace Battleships.Tests
{
    public class BattleshipTests
    {
        [Fact]
        public void CreatePlayerTestOkResult()
        {
            // Arrange
            string name = "TestName";

            // Act
            var actual = new Player(name);

            // Assert
            Assert.Equal(name, actual.Name);
        }

        [Fact]
        public void CreatePlayerTestNameNullOkResult()
        {
            // Arrange
            string name = string.Empty;

            // Act
            var actual = new Player(name);

            // Assert
            Assert.Equal(name, actual.Name);
        }

        [Fact]
        public void CreatePlayerShipsOkResult()
        {
            // Arrange
            string name = "TestName2";

            // Act
            var actual = new Player(name);

            // Assert
            Assert.IsType<List<BaseShip>>(actual.Ships);
        }

        [Fact]
        public void CreatePlayerBoardsOkResult()
        {
            // Arrange
            string name = "TestName3";

            // Act
            var actual = new Player(name);

            // Assert
            Assert.True(actual.Board != null);
            Assert.True(actual.AimBoard != null);
        }

        [Fact]
        public void FireShootOkResult()
        {
            // Arrange
            string name = "TestName3";
            var actual = new Player(name);

            // Act
            actual.PlaceShips();
            var result = actual.FireShoot();

            // Assert
            Assert.IsType<Coordinates>(result);
        }
    }
}
