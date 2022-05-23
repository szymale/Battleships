using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Library.Gameplay
{
    public class Game
    {
        private int rounds = 0;
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game() 
        {
            Player1 = new("Anto");
            Player2 = new("Bobby");

            Player1.PlaceShips();
            Player2.PlaceShips();

            Player1.PrintGameplayBoards();
            Player2.PrintGameplayBoards();
        }

        public void PlayRound() 
        {
            var coordinates = Player1.FireShoot();
            var result = Player2.ProcessShot(coordinates);
            Player1.ProcessShotResult(coordinates, result);

            if (!Player2.HasLost)
            {
                coordinates = Player2.FireShoot();
                result = Player1.ProcessShot(coordinates);
                Player2.ProcessShotResult(coordinates, result);
            }
            rounds++;
        }

        public void PlayToEnd() 
        {
            while (!Player1.HasLost && !Player2.HasLost)
            {
                PlayRound();

                Console.WriteLine("Rounds:" + rounds);
            }

            Player1.PrintGameplayBoards();
            Player2.PrintGameplayBoards();

            if (Player1.HasLost)
            {
                Console.WriteLine(Player2.Name + "has won this game!");
            }
            else if (Player2.HasLost)
            {
                Console.WriteLine(Player1.Name + "has won this game!");
            }
        }

    }
}
