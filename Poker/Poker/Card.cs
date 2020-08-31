using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Card
    {
        public Number Number { get; set; }
        public Suit Suit { get; set; }
        public Card(Number number, Suit suit)
        {
            Number = number;
            Suit = suit;
        }
    }

    public enum Number
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}
