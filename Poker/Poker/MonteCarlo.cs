using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class MonteCarlo
    {
        public static List<(List<Card> hand, double probability)> CalculateAllProbabilities(int iterations = 1000)
        {
            var deck = new Deck();
            var output = new List<(List<Card> hand, double probability)>();
            foreach(var c1 in deck.Cards)
            {
                foreach (var c2 in deck.Cards)
                {
                    var hand = new List<Card>{ c1, c2 };
                    var p = CalculateProbability(hand, iterations);

                    Console.WriteLine($"{c1.ToString()}, {c2.ToString()} - {p}");

                    output.Add((hand, p));
                }
            }

            return output;
        }

        public static double CalculateProbability(List<Card> Hand, int otherPlayers, int iterations = 1000)
        {
            return CalculateProbability(Hand, new List<Card>(), otherPlayers, iterations);
        }

        public static double CalculateProbability(List<Card> Hand, List<Card> Table, int otherPlayers, int iterations = 1000)
        {
            double total = 0;
            for(int i = 0; i < iterations; i++)
            {
                if (SimulateRound(Hand, Table, otherPlayers)) total++;
            }

            return total/iterations;
        }

        public static bool SimulateRound(List<Card> Hand, int otherPlayers)
        {
            return SimulateRound(Hand, new List<Card>(), otherPlayers);
        }

        public static bool SimulateRound(List<Card> Hand, List<Card> Table, int otherPlayers)
        {
            var deck = new Deck();

            foreach (var c in Hand) deck.Remove(c);
            foreach (var c in Table) deck.Remove(c);

            deck.Shuffle();

            var table = new List<Card>(Table);

            if (Table.Count < 5) table.AddRange(deck.DealHand(5 - Table.Count));
            var hands = deck.DealHands(otherPlayers, 2);
            
            return WinChecker.WinCheck(table, Hand, hands);
        }
    }
}
