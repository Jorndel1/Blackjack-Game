using System;

namespace Game
{
    public class GameConsole
    {
        public static void NewCard(Card newCard)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"New card: {newCard.Name} ({newCard.Value})");

            Console.ResetColor();
        }

        public static void PlayerDetails(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player: {player.Name}\nScore: {player.Score}");

            Console.ResetColor();
        }

        public static void PlayerPick(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
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

            Console.ResetColor();
        }
    }
}