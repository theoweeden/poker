﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public class Deck
    {
        public Stack<Card> Cards { get; set; }
        public Deck()
        {
            Cards = new Stack<Card>();
            foreach (var suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                foreach (var n in (Rank[])Enum.GetValues(typeof(Rank)))
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

        public List<Card> DealHand(int size)
        {
            var hand = new List<Card>();
            for (int i = 0; i < size; i++)
            {
                hand.Add(Cards.Pop());
            }
            return hand;
        }

        public List<List<Card>> DealHands(int number, int size)
        {
            var hands = new List<List<Card>>();

            for (int i = 0; i < number; i++)
            {
                hands.Add(DealHand(size));
            }

            return hands;
        }

        public void Remove(Card card)
        {
            var tempCards = Cards.Where(x => x.Number != card.Number || x.Suit != card.Suit).ToList();

            Cards.Clear();
            foreach (var c in tempCards) Cards.Push(c);
        }
    }
}
