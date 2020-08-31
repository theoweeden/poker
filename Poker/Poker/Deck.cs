using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    class Deck
    {
        public Stack<Card> Cards { get; set; }
        public Deck()
        {
            Cards = new Stack<Card>();
            foreach (var suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                foreach (var n in (Number[])Enum.GetValues(typeof(Number)))
                {
                    Cards.Push(new Card(n, suit));
                }
            }
        }

        public void Shuffle()
        {
            Random r = new Random();
            var tempCards = Cards.ToList();
            Cards.Clear();
            foreach (var c in tempCards.OrderBy(x => r.Next())) Cards.Push(c);
        }
    }
}
