using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class MonteCarlo
    {
        public static double CalculateProbability(List<Card> Hand, int iterations = 1000)
        {
            double total = 0;
            for(int i = 0; i < iterations; i++)
            {
                if (SimulateRound(Hand)) total++;
            }

            return total/iterations;
        }

        public static bool SimulateRound(List<Card> Hand)
        {
            var deck = new Deck();

            foreach (var c in Hand) deck.Remove(c);

            deck.Shuffle();

            var table = deck.DealHand(5);
            var hands = deck.DealHands(7, 2);
            
            return WinChecker.WinCheck(table, Hand, hands);
        }
    }
}
