namespace BlackJack
{
    internal class Card
    {
        public readonly Suit Suit;
        public readonly Value Value;
        public readonly int Points;

        public Card(Suit suit, Value value)
        {
            this.Suit = suit;
            this.Value = value;
            this.Points = value switch
            {
                Value.Ace => 1,
                Value.Jack => 10,
                Value.Queen => 10,
                Value.King => 10,
                _ => (int)value
            };
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }

    internal enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    internal enum Value
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
}