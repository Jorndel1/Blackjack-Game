#nullable enable
using System;

namespace Game
{
    public class GameConsole : IGameDialog
    {
        public void Clear() => Console.Clear();
        public void DisplayError(string message)
        {
            PrintMessage("ERROR: " + message, ConsoleColor.Red);
        }
        public void DisplayMessage(string message)
        {
            PrintMessage(message, ConsoleColor.White);
        }


        public void DisplayScore(IPlayers player)
        {
            PrintMessage($"- {player.Name}s score is: {player.Score}", ConsoleColor.Yellow);
        }
        public void DisplayCardDraw(IPlayers player, Card card)
        {
            PrintMessage($"{player.Name} received ", ConsoleColor.Gray, false);
            PrintMessage($"'{card.Name}' ({card.Value})", ConsoleColor.Magenta);
        }
        public void DisplayCards(IPlayers player)
        {
            PrintMessage($"{player.Name} has the following cards:");

            foreach (var card in player.GetDeck())
                PrintMessage(card.Name + " | ", ConsoleColor.Magenta, false);
        }


        public void PrintMessage(string message, ConsoleColor color = ConsoleColor.Gray, bool newLine = true)
        {
            Console.ForegroundColor = color;
            if (newLine)
                message += "\n";
            Console.Write(message);

            Console.ResetColor();
        }
    }
}
