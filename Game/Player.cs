using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class Player : IPlayers
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool IsBusted { get; private set; }

        private readonly List<Card> _deck = new();
        private readonly CardDeck _tableDeck;

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
            if (Score > 21 && _deck.Any(c => c.Name.Contains("Ace")))
                Score -= 10;

            if (Score <= 21)
                return card;

            //Player is Busted :(
            IsPlaying = false;
            IsBusted = true;
            return card;
        }

        public void Stand() => IsPlaying = false;
        public List<Card> GetDeck() => _deck;
    }
}
