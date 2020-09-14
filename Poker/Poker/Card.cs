using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Card
    {
        public Rank Number { get; set; }
        public Suit Suit { get; set; }
        public Card(Rank number, Suit suit)
        {
            Number = number;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Number} of {Suit}";
        }
    }

    public enum Rank
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
