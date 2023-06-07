namespace BlackJack
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; } = new();
        public bool IsPlaying { get; set; } = true;

        public Player(string name)
        {
            Name = name;
        }

        internal void Hit(Card card)
        {
            Hand.Add(card);
        }

        internal void ShowHand()
        {
            Console.WriteLine("----------------");
            Console.WriteLine($"{Name}'s hand:");
            foreach (Card card in Hand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine("----------------");
        }

        internal void ShowPoints()
        {
            int points = GetPoints();
            Console.WriteLine($"{Name} has {points} points");
            Console.WriteLine("----------------");
        }

        internal bool CheckBlackJack()
        {
            return GetPoints() == 21;
        }

        internal bool CheckBusted()
        {
            return GetPoints() > 21;
        }

        internal int GetPoints()
        {
            int points = 0;
            foreach (Card card in Hand)
            {
                points += card.Points;
            }
            if (Hand.Any(card => card.Value == Value.Ace) && points <= 11)
            {
                points += 10;
            }
            return points;
        }
    }
}