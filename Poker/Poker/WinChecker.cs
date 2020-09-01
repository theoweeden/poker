using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            foreach(var hand in hands)
            {
                var pool = new List<Card>();
                pool.AddRange(table);
                pool.AddRange(hand);

                //combos test
                var combos = pool.GroupBy(x => x.Number).Select(x => (x.Key, count: x.Count())).OrderBy(x=>x.count).ThenBy(x => x.Key);
                WinType highestCombo = ComboCheck(pool);

                //suits test
                var suits = pool.GroupBy(x => x.Suit).Select(x => (x.Key, count: x.Count())).OrderBy(x => x.count).ThenBy(x => x.Key);
                WinType highestSuits;

                if (suits.Any(x => x.count == 5)) highestCombo = WinType.Flush;

                //straight test
            }

            return (null, WinType.HighCard);
        }

        private WinType ComboCheck(List<Card> pool)
        {
            var combos = pool.GroupBy(x => x.Number).Select(x => (x.Key, count: x.Count())).OrderBy(x => x.count).ThenBy(x => x.Key);

            if (combos.Any(x => x.count == 4)) return WinType.FourOfAKind;
            else if (combos.Any(x => x.count == 3) && combos.Any(x => x.count == 2)) return WinType.FullHouse;
            else if (combos.Any(x => x.count == 3)) return WinType.ThreeOfAKind;
            else if (combos.Count(x => x.count == 2) >= 2) return WinType.TwoPair;
            else if (combos.Any(x => x.count == 2)) return WinType.Pair;

            return WinType.HighCard;
        }

        private bool StraightCheck(List<Card> pool)
        {
            var orderedPool = pool.OrderBy(x => x.Number).ToList();
            int counter = 1;
            Number last = pool.First().Number;
            for (int i = 1; i < orderedPool.Count; i++)
            {
                var diff = orderedPool[i].Number - last;
                if (diff == 0) continue;
                else if (diff == 1)
                {
                    counter++;
                }
                else if (diff != 1)
                {
                    counter = 1;
                }
                last = orderedPool[i].Number;
            }

            if (counter >= 5) return true;

            if (counter >= 4 && orderedPool.Last().Number == Number.King && orderedPool.Any(x => x.Number == Number.Ace)) return true;

            return false;
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
