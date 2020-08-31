using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Deck
    {
        public List<Card> Cards { get; set; }
        public Deck()
        {
            Cards = new List<Card>();
            foreach (var suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                foreach (var n in (Number[])Enum.GetValues(typeof(Number)))
                {
                    Cards.Add(new Card(n, suit));
                }
            }
        }

        public void Shuffle()
        {
            Shuffle(100);
        }
        public void Shuffle(int swaps)
        {
            Random r = new Random();
            for(int i = 0; i < swaps; i++)
            {
                var j = r.Next(Cards.Count);
                var k = r.Next(Cards.Count);

                var temp = Cards[j];
                Cards[j] = Cards[k];
                Cards[k] = temp;
            }
        }
    }
}
