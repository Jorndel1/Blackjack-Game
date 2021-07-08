using System;
using System.Collections.Generic;
using System.Linq;

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
            Deck = new();
            _players = new();

            _dialog = new GameConsole();
            _dealer = new Dealer(Deck);
            
        }

        public void AddPlayer(IPlayers player)
        {
            _players.Add(player);
        }


        public void StartGame()
        {
            _dialog.Clear();
            _dialog.DisplayMessage("Welcome to BlackJack!");

            _dialog.DisplayMessage("Dealing cards:\n");
            foreach (var player in _players)
            {
                _dialog.DisplayCardDraw(player, player.Hit());
                _dialog.DisplayCardDraw(player, player.Hit());
                _dialog.DisplayScore(player);
                _dialog.DisplayMessage("-------------------------------");

                //Check if player has Blackjack, end game if so
                if (player.Score == 21)
                {
                    EndPlaying(true, player);
                    return;
                }
            }

            //Deal a card to the dealer and show it
            _dialog.DisplayCardDraw(_dealer, _dealer.Hit());

            _dialog.DisplayMessage("\nReady to begin playing? (Y/N)");
            var playerChoice = Console.ReadKey().Key;
            if (playerChoice == ConsoleKey.Y)
                BeginPlaying();
            else _dialog.DisplayMessage("Another time maybe? :)");
            
        }

        /// <summary>
        /// Player loop to play the game
        /// </summary>
        private void BeginPlaying()
        {
            _dialog.Clear();
            foreach (var player in _players)
            {
                if (PlayerTurn(player))
                {
                    EndPlaying(true, player); //If player get's blackjack during the game, end game and say as winner.
                    return;
                }
            }
            EndPlaying();
        }

        /// <summary>
        /// Game logic for player to hit/stand and check if score is still play-able
        /// </summary>
        /// <param name="player">The player which is playing</param>
        /// <returns>If player has blackjack or not</returns>
        private bool PlayerTurn(IPlayers player)
        {
            _dialog.DisplayMessage($"{player.Name}s Turn!");
            while (player.IsPlaying)
            {
                if (player.Score == 21)
                    return true;

                _dialog.DisplayScore(player);
                _dialog.DisplayCards(player);
                _dialog.DisplayMessage("\nWould you like to:\n - Hit(h) or Stand(s) -\n");

                var playerChoice = Console.ReadKey(true).Key;
                if (playerChoice == ConsoleKey.S)
                {
                    _dialog.DisplayScore(player);
                    _dialog.DisplayMessage($"{player.Name} stands!\n");
                    player.Stand();
                    return false;
                }
                if (playerChoice == ConsoleKey.H)
                {
                    var card = player.Hit();
                    _dialog.DisplayCardDraw(player, card);


                    //Game Logic
                    switch (player.Score)
                    {
                        case > 21:
                            _dialog.Clear();
                            _dialog.DisplayCardDraw(player, card);
                            _dialog.DisplayScore(player);
                            _dialog.DisplayMessage("Busted! Score over 21!\n\n");
                        break;
                        
                        case 21:
                            _dialog.DisplayScore(player);
                            _dialog.DisplayMessage("Blackjack!");
                            player.Stand();
                        return true;
                    }
                }

                _dialog.DisplayMessage("");
                _dialog.DisplayMessage("");
            }
            return false;
        }

        /// <summary>
        /// End the game and say who won or if dealer won
        /// </summary>
        /// <param name="blackjack">If a player got Blackjack, we end the game and say as winner</param>
        /// <param name="winner">The player who got Blackjack and won the game</param>
        private void EndPlaying(bool blackjack = false, IPlayers winner = null)
        {
            //If blackjack winner
            if (blackjack && winner != null)
                PrintWinner(winner);
            else
            {
                _dialog.DisplayMessage("All players are done!\nNow Dealers turn\n");
                _dialog.DisplayScore(_dealer);

                //Game Logic for the Dealer
                while (_dealer.Score <= 17)
                {
                    _dialog.DisplayCardDraw(_dealer, _dealer.Hit());
                    _dialog.DisplayScore(_dealer);
                }

                if (_dealer.Score > 21)
                {
                    _dialog.Clear();
                    _dialog.DisplayMessage("Dealer is Busted! Score over 21!");
                }

                _players.Add(_dealer);


                //Find the winner of the game
                winner = new Player("placeholder", Deck);
                foreach (var player in _players)
                {
                    if (!player.IsBusted && player.Score > winner.Score)
                        winner = player;
                }

                if (winner.Name == "placeholder")
                    _dialog.DisplayError("No winners, everyone got busted!");
                else
                {
                    bool draw = _players.Any(p => p.Score == winner.Score && p.Name != winner.Name);
                    if(draw)
                        _dialog.DisplayError("It's a draw, two winners!");
                    else PrintWinner(winner);
                }
            }
        }

        /// <summary>
        /// Prints the winner and display everyone score
        /// </summary>
        /// <param name="winner">The winner we have from EndPlaying method</param>
        private void PrintWinner(IPlayers winner)
        {
            _dialog.DisplayMessage("\n");
            foreach (var player in _players)
                _dialog.DisplayScore(player);

            _dialog.DisplayMessage($"\nWinner is: {winner.Name} with a score of {winner.Score}");
            _dialog.DisplayScore(winner);
        }
    }
}
