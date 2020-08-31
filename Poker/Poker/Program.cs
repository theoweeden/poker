using System;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            
            deck.Shuffle();
            foreach (var c in deck.Cards)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine(deck.Cards.Count);
        }
    }
}
