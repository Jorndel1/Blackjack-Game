using System;

namespace Game
{
    public class Card
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Card(int value)
        {
            if (value is 11 or 12 or 13)
                Value = 10;
            else Value = value;

            Name = Enum.GetNames(typeof(Cards))[value - 1];
        }
    }

    internal enum Cards
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack = 11,
        Queen = 12,
        King = 13
    }
}