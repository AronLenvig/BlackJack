namespace BlackJack
{
    internal class Dealer
    {
        public bool IsPlaying { get; set; } = true;

        public List<Card> Hand { get; } = new();

        public void Hit(Card card)
        {
            Hand.Add(card);
        }

        public void ShowHand()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Dealer's hand:");
            foreach (Card card in Hand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine("----------------");
        }

        internal void ShowPoints()
        {
            int points = GetPoints();
            Console.WriteLine($"Dealer has {points} points");
            Console.WriteLine("----------------");
        }

        internal bool CheckBusted()
        {
            return GetPoints() > 21;
        }

        internal bool CheckBlackJack()
        {
            return GetPoints() == 21;
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

        internal bool OverOrEqual17()
        {
            return GetPoints() >= 17;
        }
    }
}