using System;
using System.Collections.Generic;

namespace Game
{
    public partial class GameTable
    {
        public readonly CardDeck Deck;
        private readonly List<IPlayers> _players;
        private readonly Dealer _dealer;
        private readonly IGameDialog _dialog;
        public GameTable()
        {
            Deck = new CardDeck();
            _dialog = new GameConsole();
            _dealer = new Dealer(Deck);
            _players = new List<IPlayers>();
        }

        public void AddPlayer(IPlayers player)
        {
            _players.Add(player);
        }

        public List<IPlayers> GetPlayers()
        {
            return _players;
        }

        public void StartGame()
        {
            _dialog.Clear();
            _dialog.DisplayMessage("Welcome to BlackJack!");

            _dialog.DisplayMessage("Giving out cards:\n");
            foreach (var player in _players)
            {
                _dialog.DisplayCardDraw(player, player.Hit());
                _dialog.DisplayCardDraw(player, player.Hit());
            }
            _dialog.DisplayCardDraw(_dealer, _dealer.Hit());

            _dialog.DisplayMessage("\nReady to begin playing? (Y/N)");
            var playerChoice = Console.ReadKey().Key;
            if (playerChoice == ConsoleKey.Y)
                BeginPlaying();
            else _dialog.DisplayMessage("Another time maybe? :)");
            
        }

        private void BeginPlaying()
        {
            _dialog.Clear();
            foreach (var player in _players)
            {
                if (PlayerTurn(player))
                {
                    EndPlaying(true, player);
                    return;
                }
            }
            EndPlaying();
        }

        private bool PlayerTurn(IPlayers player)
        {
            _dialog.DisplayMessage($"{player.Name}s Turn!");
            while (player.IsPlaying)
            {

                _dialog.DisplayScore(player);
                _dialog.DisplayMessage("Would you like to:\n - Hit(h) or Stand(s) -\n");

                var playerChoice = Console.ReadKey(true).Key;
                if (playerChoice == ConsoleKey.H)
                {
                    var card = player.Hit();
                    _dialog.DisplayCardDraw(player, card);

                    if (player.Score > 21)
                    {
                        _dialog.Clear();
                        _dialog.DisplayCardDraw(player, card);
                        _dialog.DisplayScore(player);
                        _dialog.DisplayMessage("Busted! Score over 21!\n\n");
                        return false;
                    }
                    else if (player.Score == 21)
                    {
                        _dialog.DisplayScore(player);
                        _dialog.DisplayMessage("Blackjack!");
                        player.Stand();
                        return true;
                    }
                }
                else if (playerChoice == ConsoleKey.S)
                {
                    _dialog.DisplayMessage($"{player.Name} stands!");
                    player.Stand();
                    return false;
                }
                _dialog.DisplayMessage("");
                _dialog.DisplayMessage("");
            }
            return false;
        }
        private void EndPlaying(bool blackjack = false, IPlayers winner = null)
        {
            //If blackjack winner
            if (blackjack && winner != null)
                PrintWinner(winner);
            else
            {
                _dialog.DisplayMessage("All players are done!\nNow Dealers turn\n");
                _dialog.DisplayScore(_dealer);
                while (_dealer.Score <= 17)
                {
                    _dialog.DisplayCardDraw(_dealer, _dealer.Hit());
                    _dialog.DisplayScore(_dealer);
                }

                if (_dealer.Score > 21)
                {
                    _dialog.Clear();
                    _dialog.DisplayScore(_dealer);
                    _dialog.DisplayMessage("Dealer is Busted! Score over 21!");
                }

                _players.Add(_dealer);


                winner = new Player("placeholder", Deck);
                foreach (var player in _players)
                {
                    if (!player.IsBusted && player.Score > winner.Score)
                        winner = (Player)player;
                }

                if (winner.Name == "placeholder")
                    _dialog.DisplayError("No winners, everyone got busted!");
                else
                {
                    PrintWinner(winner);
                }
            }
        }
        private void PrintWinner(IPlayers winner)
        {
            _dialog.DisplayMessage("\n");
            foreach (var player in _players)
                _dialog.DisplayScore(player);

            _dialog.DisplayMessage($"\nWinner is: {winner.Name} with a score of {winner.Score}");
        }
    }
}
