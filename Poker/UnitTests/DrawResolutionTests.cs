using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class DrawResolutionTests
    {
        [TestMethod]
        public void DrawCheck()
        {

            var table = new List<Card>()
            {
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hand1 = new List<Card>()
            {
                new Card(Rank.Seven, Suit.Spades),
                new Card(Rank.King, Suit.Hearts),
            };

            var hands = new List<List<Card>>()
            {
                hand1,
                new List<Card>()
                {
                    new Card(Rank.Seven, Suit.Clubs),
                    new Card(Rank.King, Suit.Spades),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(winner.Hands.Count, 2);
        }
        
        [TestMethod]
        public void KickerCheck()
        {

            var table = new List<Card>()
            {
                new Card(Rank.Four, Suit.Diamonds),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Diamonds),
                new Card(Rank.Jack, Suit.Diamonds),
                new Card(Rank.Five, Suit.Diamonds),
            };

            var hand1 = new List<Card>()
            {
                new Card(Rank.Seven, Suit.Spades),
                new Card(Rank.Ace, Suit.Hearts),
            };

            var hands = new List<List<Card>>()
            {
                hand1,
                new List<Card>()
                {
                    new Card(Rank.Seven, Suit.Clubs),
                    new Card(Rank.King, Suit.Spades),
                }
            };

            var winner = WinChecker.WinCheck(table, hands);
            Assert.AreEqual(winner.Hands.Count, 1);
            Assert.AreEqual(winner.Hands.Single(), hand1);
        }
    }
}
