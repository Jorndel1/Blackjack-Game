using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class Game
    {
        private readonly List<Player> _players = new List<Player>();
        private Dealer _dealer;

        //Constructor class
        public Game()
        {
            _dealer = new Dealer(this);

            Console.WriteLine("Welcome to BlackJack v1.0\n\n");
            Console.WriteLine("Add players: Name, Name2 (separate each name by comma ',')");

            CreatePlayers();
            Console.Clear();

            DealPlayerCards();

            //Start game and show cards/score
            StartGame();

            Console.WriteLine("Game has Ended!");
            _dealer.Hit();
            PrintEndGame();
        }

        /// <summary>
        /// Create Players from console input separated by ',' (comma)
        /// </summary>
        private void CreatePlayers()
        {
            //Add players with ','
            var playerNames = Console.ReadLine().Split(',');
            foreach (var playerName in playerNames)
            {
                Console.WriteLine("Name" + playerName);
                _players.Add(new Player(playerName, this));
            }
        }

        /// <summary>
        /// Players get to Hit/Stand and see their scores.
        /// Shows winner and ends game
        /// </summary>
        private void StartGame()
        {
            int playersPlaying = _players.Count;

            while (playersPlaying >= 0)
            {
                foreach (var player in _players)
                {
                    if (player.Playing)
                    {
                        Console.WriteLine($"---------{player.Name}----------");
                        Console.WriteLine("Your current score is: " + player.Score);
                        Console.WriteLine("Would you like to: Hit(h) or Stand(s)?");


                        if (player.Score > 21)
                        {
                            player.Stand();
                            Console.WriteLine("You're above 21 score, you've lost :(");
                        }
                        else
                        {
                            ConsoleKey userInput = Console.ReadKey(true).Key;
                            if (userInput == ConsoleKey.H)
                            {
                                var hitCard = player.Hit();
                                //Console.WriteLine("Drawing a new Card! " + hitCard.Name);
                                GameConsole.NewCard(hitCard);

                            }
                            else if (userInput == ConsoleKey.S)
                            {
                                Console.WriteLine("Your standing down, waiting for other players to finish");
                                player.Stand();
                            }
                        }
                    }
                    else
                    {
                        playersPlaying--;
                    }
                }
            }
        }

        /// <summary>
        ///  Generates a random card with Random.Next
        /// </summary>
        /// <returns></returns>
        public Card DealCard()
        {
            var ran = new Random();
            return new Card(ran.Next((int)Cards.Ace, (int)Cards.King + 1));
        }

        /// <summary>
        ///  Generate player cards and give dealer a card
        /// </summary>
        private void DealPlayerCards()
        {
            foreach (var player in _players)
            {
                player.Hit();
                player.Hit();
            }
            _dealer.Hit();
        }

        //Print cards and scores in console
        private void ShowCards()
        {
            Console.WriteLine("-----------||-----------");
            Console.WriteLine($"Dealers Card: {_dealer.ShowHand()[0].Name} ({_dealer.ShowHand()[0].Value})");
            Console.WriteLine("-----------||-----------\n\n");

            foreach (var player in _players)
            {
                foreach (var card in player.ShowHand())
                {
                    GameConsole.PlayerDetails(player);
                }
                Console.WriteLine("-----------------\n");
            }
        }

        private void PrintEndGame()
        {
            Console.Clear();
            Console.WriteLine($"Dealer: {_dealer.Score}");

            foreach (var player in _players)
            {
                Console.WriteLine($"{player.Name} : {player.Score}");
            }

            Player winner = _dealer;
            foreach (var player in _players)
            {
                if (player.Score <= 21 && player.Score > winner.Score)
                {
                    winner = player;
                }
            }

            if(winner.Score > _dealer.Score)
                Console.WriteLine("Winner is " + winner.Name);
            else Console.WriteLine("Winner is " + _dealer.Name);

            
        }
    }
}