using System;
using System.Collections.Generic;

namespace Game
{
    public class CardDeck
    {
        public List<Card> Deck = new();
        public CardDeck()
        {
            for (int i = 0; i < 52; i++)
                Deck.Add(MakeCard(i));
        }

        private Card MakeCard(int value)
        {
            int rValue;
            string deckName = " of Hearts";

            //Make 4 stock of cards
            if (value >= 39)
            {
                value -= 39;
                deckName = " of Diamonds";
            }
            else if (value >= 26)
            {
                value -= 26;
                deckName = " of Spades";
            }
            else if (value >= 13)
            {
                value -= 13;
                deckName = " of Clubs";
            }

            //Make sure no card is higher value than 10 (ace is special case to be added)
            if (value is (int)Cards.Jack or (int)Cards.Queen or (int)Cards.King)
                rValue = 10;
            else if (value is 1)
                rValue = 11;
            else rValue = value;

            var rName = Enum.GetNames(typeof(Cards))[value] + deckName;

            return new Card(rName, rValue + 1);
        }
        private void RemoveCard(int index)
        {
            if(index <= Deck.Count)
                Deck.RemoveAt(index);
        }
        public Card GetCard()
        {
            var randomCard = new Random().Next(0, Deck.Count - 1);

            RemoveCard(randomCard);
            return Deck[randomCard];
        }
    }
}
