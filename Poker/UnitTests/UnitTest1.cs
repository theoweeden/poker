using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStraightFlush1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Four, Suit.Diamonds),
                    new Card(Rank.Ten, Suit.Diamonds),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.StraightFlush, winner.WinType);
        }

        [TestMethod]
        public void TestRoyalFlush()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Four, Suit.Diamonds),
                    new Card(Rank.Ten, Suit.Diamonds),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.RoyalFlush, winner.WinType);
        }
    }
}
