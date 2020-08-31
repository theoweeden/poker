using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Deck
    {
        public List<Card> CardDeck { get; set; }
        public Deck()
        {
            foreach (var suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                foreach (var n in (Number[])Enum.GetValues(typeof(Number)))
                {
                    CardDeck.Add(new Card(n, suit));
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
                var j = r.Next(CardDeck.Count);
                var k = r.Next(CardDeck.Count);

                var temp = CardDeck[j];
                CardDeck[j] = CardDeck[k];
                CardDeck[k] = temp;
            }
        }
    }
}
