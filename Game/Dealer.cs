namespace Game
{
    public partial class GameTable
    {
        public class Dealer : Player
        {
            public Dealer(CardDeck deck): base("Dealer", deck)
            {
                Hit();
                Hit();
            }
        }
    }
}
