namespace BlackJack
{
    class Game
    {
        readonly Deck deck = new();
        readonly Dealer dealer = new();
        readonly Player player = new("Player");
        bool Gameover;

        public void Start()
        {
            // Shuffle the deck
            deck.Shuffle();

            // deals two cards to the player
            player.Hit(deck.Pop());
            player.Hit(deck.Pop());

            // deals two cards to himself
            dealer.Hit(deck.Pop());
            dealer.Hit(deck.Pop());

            DisplayHands();

            if (player.CheckBlackJack())
            {
                Console.WriteLine("Player has BlackJack");
                player.IsPlaying = false;
            }

            if (dealer.CheckBlackJack())
            {
                Console.WriteLine("Dealer has BlackJack");
                dealer.IsPlaying = false;
            }

            while (!Gameover)
            {
                if (!player.IsPlaying && !dealer.IsPlaying)
                {
                    ShowResult();
                    break;
                }

                if (player.IsPlaying)
                {
                    ConsoleKeyInfo key = GetInput();
                    if (key.Key == ConsoleKey.H)
                    {
                        PlayerHit();
                        continue;
                    }
                    if (key.Key == ConsoleKey.S)
                    {
                        player.IsPlaying = false;
                    }
                }

                if (dealer.IsPlaying)
                {
                    Console.WriteLine("Dealer's turn");
                    Thread.Sleep(2000); // wait 2 seconds
                    if (dealer.OverOrEqual17())
                    {
                        Console.WriteLine("Dealer stands at 17 or higher");
                        dealer.IsPlaying = false;
                    }
                    else
                    {
                        DealerHit();
                    }
                    if (dealer.CheckBlackJack())
                    {
                        Console.WriteLine("Dealer has BlackJack");
                        Console.WriteLine("Dealer wins");
                        break;
                    }
                }
            }
        }

        private void DealerHit()
        {
            Console.WriteLine("Dealer hits");
            dealer.Hit(deck.Pop());
            DisplayHands();

            if (dealer.CheckBusted())
            {
                Console.WriteLine("Dealer busted");
                Console.WriteLine("Player wins");
                Gameover = true;
            }
            if (dealer.CheckBlackJack())
            {
                Console.WriteLine("Dealer has BlackJack");
                dealer.IsPlaying = false;
            }
        }

        private void PlayerHit()
        {
            player.Hit(deck.Pop());
            DisplayHands();

            if (player.CheckBusted())
            {
                Console.WriteLine("Player busted");
                Console.WriteLine("Dealer wins");
                Gameover = true;
            }
            if (player.CheckBlackJack())
            {
                Console.WriteLine("Player has BlackJack");
                player.IsPlaying = false;
            }
        }

        private void ShowResult()
        {
            System.Console.WriteLine($"Player has {player.GetPoints()} points and dealer has {dealer.GetPoints()} points");
            if (player.GetPoints() > dealer.GetPoints())
            {
                Console.WriteLine("Player wins");
            }
            else if (player.GetPoints() == dealer.GetPoints())
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine("Dealer wins");
            }
        }

        private ConsoleKeyInfo GetInput()
        {
            while (true)
            {
                Console.WriteLine("Hit or Stand? (H/S)");
                // ConsoleKeyInfo key = Console.ReadKey();
                ConsoleKeyInfo key = Console.ReadKey();
                bool validKey = IsKeyValid(key);
                Console.WriteLine();
                if (!validKey)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                return key;
            }
        }

        private bool IsKeyValid(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.H || key.Key == ConsoleKey.S;
        }

        private void DisplayHands()
        {
            Console.Clear();
            // Show the dealer's hand
            dealer.ShowHand();
            dealer.ShowPoints();

            // Show the player's hand
            player.ShowHand();
            player.ShowPoints();
        }
    }
}