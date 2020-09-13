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

        public override string ToString()
        {
            return $"{Number} of {Suit}";
        }
    }

    public enum Number
    {
        Two = 2,
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
        Ace,
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}
