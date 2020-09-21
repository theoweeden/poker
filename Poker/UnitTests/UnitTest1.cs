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
        public void TestStraight1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Queen, Suit.Clubs),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Four, Suit.Spades),
                    new Card(Rank.Ten, Suit.Diamonds),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.Straight, winner.WinType);
        }

        [TestMethod]
        public void TestFlush1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Three, Suit.Diamonds),
                new Card(Rank.King, Suit.Diamonds),
                new Card(Rank.Nine, Suit.Diamonds),
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
            Assert.AreEqual(WinType.Flush, winner.WinType);
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

        [TestMethod]
        public void TestFourOfAKind1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Queen, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Ace, Suit.Clubs),
                    new Card(Rank.Ace, Suit.Spades),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.FourOfAKind, winner.WinType);
        }

        [TestMethod]
        public void TestFullHouse1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Seven, Suit.Clubs),
                    new Card(Rank.Ace, Suit.Spades),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.FullHouse, winner.WinType);
        }

        [TestMethod]
        public void TestThreeOfAKind1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Ace, Suit.Hearts),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Six, Suit.Clubs),
                    new Card(Rank.Ace, Suit.Spades),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.ThreeOfAKind, winner.WinType);
        }

        [TestMethod]
        public void TestTwoPair1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Seven, Suit.Clubs),
                    new Card(Rank.Ace, Suit.Spades),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.TwoPair, winner.WinType);
        }

        [TestMethod]
        public void TestPair1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Seven, Suit.Clubs),
                    new Card(Rank.Two, Suit.Spades),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.Pair, winner.WinType);
        }

        [TestMethod]
        public void TestHighCard1()
        {
            var table = new List<Card>()
            {
                new Card(Rank.Ace, Suit.Diamonds),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hands = new List<List<Card>>()
            {
                new List<Card>()
                {
                    new Card(Rank.Three, Suit.Clubs),
                    new Card(Rank.Two, Suit.Spades),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(WinType.HighCard, winner.WinType);
        }


    }
}
