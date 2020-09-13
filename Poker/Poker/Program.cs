using System;
using System.Collections.Generic;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (int i = 0; i < 5000; i++)
            {
                var deck = new Deck();

                deck.Shuffle();

                var table = deck.DealHand(5);
                var hands = deck.DealHands(7, 2);
                var winner = WinChecker.WinCheck(table, hands);

                Console.WriteLine(winner.WinType);
                foreach (var h in winner.Hands)
                {
                    foreach (var c in h)
                    {
                        Console.WriteLine(c.ToString());
                    }
                    Console.WriteLine();
                }
                foreach (var c in table)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine();
            }
            
            //var table2 = new List<Card>()
            //{
            //    new Card(Number.Ace, Suit.Diamonds),
            //    new Card(Number.Six, Suit.Clubs),
            //    new Card(Number.Seven, Suit.Clubs),
            //    new Card(Number.Eight, Suit.Clubs),
            //    new Card(Number.Three, Suit.Diamonds),
            //};

            //var hands2 = new List<List<Card>>()
            //{
            //    new List<Card>()
            //    {
            //        new Card(Number.Five, Suit.Diamonds),
            //        new Card(Number.Nine, Suit.Spades),
            //    }
            //};
            
            var table2 = new List<Card>()
            {
                new Card(Number.Ace, Suit.Diamonds),
                new Card(Number.King, Suit.Diamonds),
                new Card(Number.Queen, Suit.Diamonds),
                new Card(Number.Three, Suit.Hearts),
                new Card(Number.Five, Suit.Spades),
            };

            var hands2 = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Number.Jack, Suit.Diamonds),
                    new Card(Number.Ten, Suit.Diamonds),
                }
            };

            var winner2 = WinChecker.WinCheck(table2, hands2);

            Console.WriteLine(winner2.WinType);
            foreach (var h in winner2.Hands)
            {
                foreach (var c in h)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine();
            }
            foreach (var c in table2)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine();
        }
    }
}
