using Battleships.Library;
using Battleships.Library.Gameplay;

int player1Wins = 0, player2Wins = 0;

Console.WriteLine("How many games do you want to play?");
int.TryParse(Console.ReadLine(),out int num);

for (int i = 0; i < num; i++)
{
    Game game = new();
    game.PlayToEnd();
    if (game.Player1.HasLost)
    {
        player2Wins++;
    }
    else if (game.Player2.HasLost)
    {
        player1Wins++;
    }
}

Console.WriteLine("Player 1 Wins: " + player1Wins.ToString());
Console.WriteLine("Player 2 Wins: " + player2Wins.ToString());
Console.ReadLine();
