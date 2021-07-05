using System;

namespace Game
{
    class Program
    {
        static void Main()
        {
            var game = new GameTable();
            Console.WriteLine("Before the game beings we need some player(s)!");
            Console.WriteLine("What's our first players name?");
            game.AddPlayer(new Player(Console.ReadLine(), game.Deck));

            bool addingPlayers = true;
            while(addingPlayers)
            {
                Console.WriteLine("\nEnter name for next player: (or leave blank to start playing)");
                var playerName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(playerName))
                    game.AddPlayer(new Player(playerName, game.Deck));
                else addingPlayers = false;
            }
           
            game.StartGame();
        }
    }
}
