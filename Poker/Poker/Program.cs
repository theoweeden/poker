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

            var p = MonteCarlo.CalculateProbability(hand, 1000);

            Console.WriteLine(p);
        }
    }
}
