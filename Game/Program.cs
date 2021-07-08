using System;

namespace Game
{
    class Program
    {
        static void Main()
        {

            var keepPlaying = true;
            while (keepPlaying)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                var game = new GameTable();
                Console.WriteLine("Before the game beings we need some player(s)!");
                game.AddPlayer(new Player("Janna", game.Deck));
                game.AddPlayer(new Player("Nick", game.Deck));
                

                Console.WriteLine("What's our first players name?");
                game.AddPlayer(new Player(Console.ReadLine(), game.Deck));

                bool addingPlayers = true;
                while (addingPlayers)
                {
                    Console.WriteLine("\nEnter name for next player: (or leave blank to start playing)");
                    var playerName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(playerName))
                        game.AddPlayer(new Player(playerName, game.Deck));
                    else addingPlayers = false;
                }



                game.StartGame();



                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nWould you like to keep playing? Yes(y)");
                var keepPlayingGame = Console.ReadKey(true).Key;
                if (keepPlayingGame != ConsoleKey.Y)
                    keepPlaying = false;

                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}
