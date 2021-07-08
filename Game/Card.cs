namespace Game
{
    public class Card
    {
        public string Name { get; private set; }
        public int Value { get; private set; }

        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
    internal enum Cards
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
}
