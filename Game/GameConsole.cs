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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);

            Console.ResetColor();
        }

        public void DisplayScore(IPlayers player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
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

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var card in player.GetDeck())
                Console.Write(card.Name + " | ");
                
            Console.ResetColor();
        }
    }
}
