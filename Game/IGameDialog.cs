namespace Game
{
    public interface IGameDialog
    {
        public void DisplayMessage(string message);
        public void DisplayError(string message);
        public void DisplayScore(IPlayers player);
        public void DisplayCardDraw(IPlayers player, Card card);
        public void DisplayCards(IPlayers player);
        public void Clear();
    }
}
