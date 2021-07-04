using System.Collections.Generic;

namespace Game
{
    public interface IPlayers
    {
        public string Name { get; }
        public int Score { get; }
        public bool IsPlaying { get; }
        public bool IsBusted { get; }
        public List<Card> GetDeck();
        public Card Hit();
        public void Stand();
    }
}
