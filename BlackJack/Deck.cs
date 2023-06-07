namespace BlackJack
{

    class Deck
    {
        private List<Card> cards = new();

        public Deck()
        {
            // Create a new deck of cards
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    cards.Add(new Card((Suit)i, (Value)j));
                }
            }
        }

        internal Card Pop()
        {
            if (cards.Count == 0)
            {
                throw new Exception("Deck is empty");
            }
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        internal void Shuffle()
        {
            Random random = new();
            for (int i = 0; i < cards.Count; i++)
            {
                int randomIndex = random.Next(cards.Count);
                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }
    }
}