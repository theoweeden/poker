﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.Run();
        }

        static void PrintToFile()
        {
            var pp = MonteCarlo.CalculateAllProbabilities(100);
            using StreamWriter sw = new StreamWriter("results.csv");
            foreach (var (h, r) in pp)
            {
                sw.WriteLine($"{h[0].ToString()}, {h[1].ToString()}, {r},");
            }
        }
        static void TestHand()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Four, Suit.Diamonds),
                    new Card(Rank.Ten, Suit.Diamonds),
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
