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
            return WinCheck(table, hands).Hands.Contains(playerHand);
        }

        public static (List<List<Card>> Hands, WinType WinType) WinCheck(List<Card> table, List<List<Card>> hands)
        {
            var highestWins = new List<(List<Card> Hand, WinType WinType, List<Rank> Kickers)>();
            foreach(var hand in hands)
            {
                highestWins.Add(GetHighestWin(table, hand));
            }

            return GetWinningHand(highestWins);
        }

        public static (List<Card> Hand, WinType WinType, List<Rank> Kickers) GetHighestWin(List<Card> table, List<Card> hand)
        {
            var pool = new List<Card>(table);
            pool.AddRange(hand);

            var (highestWin, kickers) = HighestNonComboWin(pool);
            var (highestCombo, comboKickers) = HighestComboWin(pool);

            if (highestWin >= highestCombo)
            {
                highestWin = highestCombo;
                kickers = comboKickers;
            }

            return (hand, highestWin, kickers);
        }

        public static (WinType HighestWin, List<Rank> Kickers) HighestNonComboWin(List<Card> pool)
        {
            var highestWin = WinType.HighCard;
            var kickers = new List<Rank>();

            var potentialFlushes = pool.GroupBy(x => x.Suit).Where(x => x.Count() >= 5).Select(x => x.OrderByDescending(y => y.Number));

            if (potentialFlushes.Any())
            {
                var straightChecks = potentialFlushes.Select(x => StraightCheck(x.ToList())).OrderByDescending(x => x.highestValue);

                if (straightChecks.Any(x => x.highestValue == Rank.Ace && x.straight))
                {
                    highestWin = WinType.RoyalFlush;
                    kickers = new List<Rank> { Rank.Ace };
                }
                else if (straightChecks.Any(x => x.straight))
                {
                    highestWin = WinType.StraightFlush;
                    kickers = new List<Rank> { straightChecks.First(x => x.straight).highestValue };
                }
                else
                {
                    highestWin = WinType.Flush;
                    kickers = new List<Rank> { potentialFlushes.First().First().Number };
                }
            }
            else
            {
                var straightCheck = StraightCheck(pool);
                if (straightCheck.straight)
                {
                    highestWin = WinType.Straight;
                    kickers = new List<Rank> { straightCheck.highestValue };
                }
            }

            return (highestWin, kickers);
        }

        public static (List<List<Card>> Hands, WinType WinType) GetWinningHand(List<(List<Card> Hand, WinType WinType, List<Rank> Kickers)> highestWins)
        {
            if (!highestWins.Any()) return (null, WinType.HighCard);

            highestWins = highestWins.GroupBy(x => x.WinType).OrderBy(x => x.Key).First().ToList();
            if (highestWins.Count == 1) return highestWins.Select(x => (new List<List<Card>> { x.Hand }, x.WinType)).Single();
            else
            {
                var kickerCount = highestWins.Max(x => x.Kickers.Count);
                for (int i = 0; i < kickerCount; i++)
                {
                    var highestKicker = highestWins.Max(x => x.Kickers[i]);
                    highestWins = highestWins.Where(x => x.Kickers[i] == highestKicker).ToList();

                    if (highestWins.Count == 1) return highestWins.Select(x => (new List<List<Card>> { x.Hand }, x.WinType)).Single();
                }
            }

            return (highestWins.Select(x => x.Hand).ToList(), highestWins.First().WinType);
        }

        private static (WinType WinType, List<Rank> Kickers) HighestComboWin(List<Card> pool)
        {
            var combos = pool.GroupBy(x => x.Number).Select(x => (x.Key, count: x.Count())).OrderByDescending(x => x.count).ThenByDescending(x => x.Key);

            Rank? FirstCombo(int count)
            {
                if (!combos.Any(x => x.count >= count)) return null;
                return combos.FirstOrDefault(x => x.count == count).Key;
            }

            Rank? SecondCombo(int count, Rank exclude)
            {
                if (!combos.Any(x => x.count >= count && x.Key != exclude)) return null;
                return combos.FirstOrDefault(x => x.count == count && x.Key != exclude).Key;
            }

            IEnumerable<Rank> TakeFromPool(int count, Rank exclude)
            {
                return pool.Where(x => x.Number != exclude).Select(x => x.Number).OrderBy(x => x).Take(count);
            }

            if (FirstCombo(4).HasValue)
            {
                var kickers = new List<Rank> { FirstCombo(4).Value };
                kickers.AddRange(TakeFromPool(1, kickers.First()));
                return (WinType.FourOfAKind, kickers);
            }
            else if (FirstCombo(3).HasValue)
            {
                var kickers = new List<Rank> { FirstCombo(3).Value };
                if (SecondCombo(2, kickers.First()).HasValue)
                {
                    kickers.Add(SecondCombo(2, kickers.First()).Value);
                    return (WinType.FullHouse, kickers);
                }
                else
                {
                    kickers.AddRange(TakeFromPool(2, kickers.First()));
                    return (WinType.ThreeOfAKind, kickers);
                }
            }
            else if (FirstCombo(2).HasValue)
            {
                var kickers = new List<Rank> { FirstCombo(2).Value };
                if (SecondCombo(2, kickers.First()).HasValue)
                {
                    kickers.Add(SecondCombo(2, kickers.First()).Value);
                    kickers.Add(pool.OrderBy(x => x.Number).First(x => !kickers.Contains(x.Number)).Number);
                    return (WinType.TwoPair, kickers);
                }
                else
                {
                    kickers.AddRange(TakeFromPool(3, kickers.First()));
                    return (WinType.Pair, kickers);
                }
            };

            return (WinType.HighCard, pool.OrderByDescending(x => x.Number).Select(x=>x.Number).Take(5).ToList());
        }

        public static (bool straight, Rank highestValue) StraightCheck(List<Card> pool)
        {
            var orderedPool = pool.GroupBy(x=>x.Number).OrderBy(x => x.Key).ToList();
            var diffs = orderedPool.Zip(orderedPool.Skip(1), (a, b) => (diff: b.Key - a.Key, number: b.Key)).ToList();
            diffs.Insert(0, (diff: 0, number: orderedPool[0].Key));

            var group = 0;
            var straightLengths = diffs.Select(diff =>
            {
                if (diff.diff != 1) group++;
                return (diff, group);
            }).GroupBy(x => x.group).Select(x => (count: x.Count(), value: x.Last().diff.number)).OrderBy(x=>x.count).ToList();

            if (straightLengths.Any(x => x.count >= 4 && x.value == Rank.Five) && pool.Any(x => x.Number == Rank.Ace)) 
                return (true, Rank.Five);

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
