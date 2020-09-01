using System;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                var deck = new Deck();

                deck.Shuffle();

                var table = deck.DealHand(5);
                var hands = deck.DealHands(7, 2);
                var winner = WinChecker.WinCheck(table, hands);

                Console.WriteLine(winner.WinType);
                foreach (var c in winner.Hand)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine();
                foreach (var c in table)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
