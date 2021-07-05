namespace Game
{
    public partial class GameTable
    {
<<<<<<< HEAD
        public Dealer(Game game):base("Dealer", game)
=======
        public class Dealer : Player
>>>>>>> 4493fed432615976ebc3fbf94251b049d35736ff
        {
            public Dealer(CardDeck deck): base("Dealer", deck)
            {
                Hit();
            }
        }
    }
}
