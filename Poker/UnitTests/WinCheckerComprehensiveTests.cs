using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class WinCheckerComprehensiveTests
    {
        public void TestStraightCheck(int straightSize, bool assertTrue = true)
        {
            var lowestCards = new List<Card>() { new Card(Rank.Ace, Suit.Diamonds) };
            for (var r = Rank.Two; r < Rank.Two + straightSize - 1; r++)
            {
                lowestCards.Add(new Card(r, Suit.Diamonds));
            }
            Assert.IsTrue(WinChecker.StraightCheck(lowestCards).straight == assertTrue);

            for (var r = Rank.Two; r <= Rank.Ace - straightSize + 1; r++)
            {
                var cards = new List<Card>();
                for (var r2 = r; r2 < r + straightSize; r2++)
                {
                    cards.Add(new Card(r2, Suit.Diamonds));
                }
                Assert.IsTrue(WinChecker.StraightCheck(cards).straight == assertTrue);
            }
        }

        [TestMethod]
        public void TestAllCorrectStraights()
        {
            TestStraightCheck(5);
        }

        [TestMethod]
        public void TestAllLengthFourStraights()
        {
            TestStraightCheck(4, false);
        }

        [TestMethod]
        public void TestAllLengthThreeStraights()
        {
            TestStraightCheck(3, false);
        }

        [TestMethod]
        public void TestAllLengthSixStraights()
        {
            TestStraightCheck(6);
        }
    }
}
