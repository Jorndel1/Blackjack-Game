using System;
using System.Collections.Generic;

namespace Game
{
    public class GameConsole : IGameDialog
    {
        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + message);

            Console.ResetColor();
        }

        public void DisplayMessage(string message)
        {
<<<<<<< HEAD
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player: {player.Name}\nScore: {player.Score}");
=======
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
>>>>>>> 4493fed432615976ebc3fbf94251b049d35736ff

            Console.ResetColor();
        }

        public void DisplayScore(IPlayers player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
<<<<<<< HEAD
            Console.WriteLine($"\n-{player.Name}");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Score: ");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(player.Score + "\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Pick One:");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hit(h)");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" | ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Stand(s)");
            Console.WriteLine();
=======
            Console.WriteLine($"- {player.Name}s score is: {player.Score}");

            Console.ResetColor();
        }
        public void Clear()
        {
            Console.Clear();
        }

        public void DisplayCardDraw(IPlayers player, Card card)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{player.Name} received '{card.Name}' ({card.Value})");
            Console.WriteLine("----------------------------------------------------\n");

            Console.ResetColor();
        }

        public void DisplayCards(IPlayers player)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{player.Name} has the following cards:");
>>>>>>> 4493fed432615976ebc3fbf94251b049d35736ff

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var card in player.GetDeck())
                Console.Write(card.Name + " | ");
                
            Console.ResetColor();
        }
    }
}
