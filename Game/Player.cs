using System;
using System.Collections.Generic;

namespace Game
{
    public class Player : IPlayers
    {
<<<<<<< HEAD
        public string Name { get; set; }
        public  int Score { get; set; }
        public ConsoleColor Color { get; set; }
        public bool Playing { get; set; }
        private List<Card> Hand;
        private Game _game;

        public Player(string name, Game game)
        {
            Hand = new List<Card>();
            _game = game;
            Score = 0;
            Playing = true;
=======
        public string Name { get; private set; }
        public int Score { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool IsBusted { get; private set; }

        private List<Card> _deck = new();
        private CardDeck _tableDeck;
>>>>>>> 4493fed432615976ebc3fbf94251b049d35736ff

        public Player(string name, CardDeck tableDeck)
        {
            if (name.Length > 1)
                Name = name;
            else Name = "Unknown Player";

            _tableDeck = tableDeck;
            IsPlaying = true;
            IsBusted = false;
        }

        public Card Hit()
        {
            var card = _tableDeck.GetCard();
            _deck.Add(card);
            Score += card.Value;

            if (Score > 21)
            {
                IsPlaying = false;
                IsBusted = true;
            }
                

            return card;
        }

        public void Stand()
        {
            IsPlaying = false;
        }


        public List<Card> GetDeck()
        {
            return _deck;
        }
    }
}
