using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Game
{
    public class Player
    {
        public string Name { get; set; }
        public  int Score { get; set; }
        public bool Playing { get; set; }
        private List<Card> Hand;
        private Game _game;

        public Player(string name, Game game)
        {
            Hand = new List<Card>();
            _game = game;
            Score = 0;
            Playing = true;


            if (name.Length >= 2)
                Name = name.Trim();
            else Name = "Unknown Player";
        }

        //Give player a card
        public void GiveCard(Card card) => Hand.Add(card);

        //Returns the hand of player as array
        public Card[] ShowHand() => Hand.ToArray();

        public void Hit()
        {
            var card = _game.DealCard();
            GiveCard(card);
            Score += card.Value;
        }

        public void Stand()
        {
            Playing = false;
        }
    }


    public class Dealer : Player
    {
        public Dealer(Game game):base("Dealer", game)
        {
            
        }
    }
}