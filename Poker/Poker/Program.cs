using System;
using System.Collections.Generic;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            var hand = new List<Card>()
            {
                new Card(Number.Ace, Suit.Diamonds),
                new Card(Number.Ace, Suit.Hearts),
            };

            var p = MonteCarlo.CalculateProbability(hand, 10000);

            Console.WriteLine(p);
        }

        static void TestHand()
        {
            var table2 = new List<Card>()
            {
                new Card(Number.Ace, Suit.Diamonds),
                new Card(Number.Two, Suit.Diamonds),
                new Card(Number.Queen, Suit.Diamonds),
                new Card(Number.Three, Suit.Diamonds),
                new Card(Number.Five, Suit.Diamonds),
            };

            var hands2 = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Number.Four, Suit.Diamonds),
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
