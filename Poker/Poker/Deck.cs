﻿using System;
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

    }
}
