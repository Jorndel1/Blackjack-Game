using System;

namespace Game
{
    public class GameConsole
    {
        public static void NewCard(Card newCard)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("New card: " + newCard.Name);
            Console.ResetColor();
        }

        public static void PlayerDetails(Player player)
        {
            Console.ForegroundColor = (ConsoleColor)(new Random().Next(1, (int)ConsoleColor.White));
            Console.WriteLine($"Player: {player.Name}\nScore: {player.Score}");
            Console.ResetColor();
        }
    }
}