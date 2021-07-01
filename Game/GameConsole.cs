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
            Console.ForegroundColor = player.Color;
            Console.WriteLine($"Player: {player.Name}\nScore: {player.Score}");

            Console.ResetColor();
        }

        public static void PlayerPick(Player player)
        {
            Console.ForegroundColor = player.Color;
            Console.WriteLine($"\n-{player.Name}");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Your current score is: ");

            Console.ForegroundColor = player.Color;
            Console.Write(player.Score + "\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Would you like to:");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hit (h)");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("   |   ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Stand (s)");
            Console.WriteLine();

            Console.ResetColor();
        }
    }
}