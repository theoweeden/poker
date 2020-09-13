using System;
using System.Collections.Generic;
using System.IO;

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

            var pp = MonteCarlo.CalculateAllProbabilities(100);
            using StreamWriter sw = new StreamWriter("results.csv");
            foreach(var (h, r) in pp)
            {
                sw.WriteLine($"{h[0].ToString()}, {h[1].ToString()}, {r},");
            }
        }

        static void TestHand()
        {
            var table = new List<Card>()
            {
                new Card(Number.Ace, Suit.Diamonds),
                new Card(Number.Two, Suit.Diamonds),
                new Card(Number.Queen, Suit.Diamonds),
                new Card(Number.Three, Suit.Diamonds),
                new Card(Number.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Number.Four, Suit.Diamonds),
                    new Card(Number.Ten, Suit.Diamonds),
                }
            };

            TestHand(table, hands);
        }

        static void TestHand(List<Card> Table, List<List<Card>> Hands)
        {
            var winner = WinChecker.WinCheck(Table, Hands);

            Console.WriteLine(winner.WinType);
            foreach (var h in winner.Hands)
            {
                foreach (var c in h)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine();
            }
            foreach (var c in Table)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine();
        }
    }
}
