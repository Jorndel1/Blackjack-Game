using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class Game
    {
        private readonly List<Player> _players = new List<Player>();
        private Dealer _dealer;
        public Game()
        {
            Console.WriteLine("Welcome to BlackJack v1.0\n\n");
            Console.WriteLine("Add players: Name, Name2 (separate each name by comma ',')");

            _dealer = new Dealer(this);

            
            CreatePlayers();
            Console.Clear();

            _players[0].Hit();

            //Start game and show cards/score
            StartGame();
            ShowCards();

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
                                Console.WriteLine("Drawing a new Card!");
                                player.Hit();
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

            Console.WriteLine("Game has Ended!");
            _dealer.Hit();
            PrintEndGame();
        }


        private void CreatePlayers()
        {
            //Add players with ','
            var playerNames = Console.ReadLine()?.Split(',');
            foreach (var playerName in playerNames)
            {
                Console.WriteLine("Name" + playerName);
                _players.Add(new Player(playerName, this));
            }
        }

        //Deal Cards
        private void StartGame()
        {
            foreach (var player in _players)
            {
                player.GiveCard(DealCard());
                player.GiveCard(DealCard());
            }
            _dealer.GiveCard(DealCard());
        }

        //Deal Cards by Random Number
        public Card DealCard()
        {
            var ran = new Random();
            return new Card(ran.Next((int)Cards.Ace, (int)Cards.King + 1));
        }

        //Print cards and scores in console
        private void ShowCards()
        {
            Console.WriteLine("-----------||-----------");
            Console.WriteLine($"Dealers Card: {_dealer.ShowHand()[0].Name} ({_dealer.ShowHand()[0].Value})");
            Console.WriteLine("-----------||-----------\n\n");

            foreach (var player in _players)
            {
                player.Score = 0;
                foreach (var card in player.ShowHand())
                {
                    player.Score += card.Value;
                    Console.WriteLine($"{player.Name} Card(s): {card.Name} ({card.Value})");
                }

                Console.WriteLine("Player Score: " + player.Score);
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