using System;

namespace Game
{
    public class Card
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Amount { get; set; }

        public Card(int value)
        {
            Value = value;
            Amount = 4;

            foreach (var card in Enum.GetNames(typeof(Cards)))
            {
                var val = (Cards)Enum.Parse(typeof(Cards), card);
                if ((int)val == value)
                    Name = card;

                //All image cards has the value 10
                if (Name == "Jack" || Name == "Queen" || Name == "King")
                    Value = 10;
            }
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