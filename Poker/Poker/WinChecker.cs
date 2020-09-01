using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    class WinChecker
    {
        public static bool WinCheck(List<Card> table, List<Card> playerHand, List<List<Card>> otherHands = null)
        {
            var hands = new List<List<Card>>();
            hands.AddRange(otherHands);
            hands.Add(playerHand);
            return WinCheck(table, hands).Hand == playerHand;
        }

        public static (List<Card> Hand, WinType WinType) WinCheck(List<Card> table, List<List<Card>> hands)
        {
            var highestWins = new List<(List<Card> Hand, WinType WinType)>();
            foreach(var hand in hands)
            {
                var pool = new List<Card>();
                pool.AddRange(table);
                pool.AddRange(hand);

                //combos test
                var combos = pool.GroupBy(x => x.Number).Select(x => (x.Key, count: x.Count())).OrderBy(x=>x.count).ThenBy(x => x.Key);
                WinType highestCombo = ComboCheck(pool);

                //suits test
                var suits = pool.GroupBy(x => x.Suit).OrderBy(x => x.Count()).ThenBy(x => x.Key);
                WinType highestSuits = WinType.HighCard;

                if (suits.Any(x => x.Count() >= 5))
                {
                    if (suits.Where(x => x.Count() >= 5).Any(x => { 
                        var s = StraightCheck(x.ToList());
                        if (s.highestValue == Number.Ace) return s.straight;
                        else return false;
                    })) highestCombo = WinType.RoyalFlush;
                    else if (suits.Where(x => x.Count() >= 5).Any(x => StraightCheck(x.ToList()).straight)) highestCombo = WinType.StraightFlush;
                    else highestSuits = WinType.Flush;
                }
                else if(StraightCheck(pool).straight)
                {
                    highestSuits = WinType.Straight;
                }

                var highest = ((int)highestSuits < (int)highestCombo) ? highestSuits : highestCombo;

                highestWins.Add((hand, highest));
            }

            if (!highestWins.Any()) return (null, WinType.HighCard);
            else return highestWins.OrderBy(x => x.WinType).First();
        }

        private static WinType ComboCheck(List<Card> pool)
        {
            var combos = pool.GroupBy(x => x.Number).Select(x => (x.Key, count: x.Count())).OrderBy(x => x.count).ThenBy(x => x.Key);

            if (combos.Any(x => x.count == 4)) return WinType.FourOfAKind;
            else if (combos.Any(x => x.count == 3) && combos.Any(x => x.count == 2)) return WinType.FullHouse;
            else if (combos.Any(x => x.count == 3)) return WinType.ThreeOfAKind;
            else if (combos.Count(x => x.count == 2) >= 2) return WinType.TwoPair;
            else if (combos.Any(x => x.count == 2)) return WinType.Pair;

            return WinType.HighCard;
        }

        public static (bool straight, Number highestValue) StraightCheck(List<Card> pool)
        {
            var orderedPool = pool.GroupBy(x=>x.Number).OrderBy(x => x.Key).ToList();
            var diffs = orderedPool.Zip(orderedPool.Skip(1), (a, b) => (diff: b.Key - a.Key, number: b.Key));
            
            var group = 0;
            var straightLengths = diffs.Select(diff =>
            {
                if (diff.diff != 1) group++;
                return (diff, group);
            }).GroupBy(x => x.group).Select(x => (count: x.Count(), value: x.Last().diff.number)).OrderBy(x=>x.count).ToList();

            if (straightLengths.Last().count >= 4 && straightLengths.Last().value == Number.King && pool.Any(x => x.Number == Number.Ace)) 
                return (true, Number.Ace);

            if (straightLengths.Any(x => x.count >= 5)) return (true, straightLengths.Last(x => x.count >= 5).value);

            return (false, pool.Max(x => x.Number));
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
