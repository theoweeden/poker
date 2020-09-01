using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class WinChecker
    {
        public bool WinCheck(List<Card> table, List<Card> playerHand, List<List<Card>> otherHands = null)
        {
            var hands = new List<List<Card>>();
            hands.AddRange(otherHands);
            hands.Add(playerHand);
            return WinCheck(table, hands).Hand == playerHand;
        }

        public (List<Card> Hand, WinType WinType) WinCheck(List<Card> table, List<List<Card>> hands)
        {
            throw new NotImplementedException();
        }
    }

    public enum WinType
    {
        RoyalFlush,
        StraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        TwoPair,
        Pair,
        HighCard
    }
}
