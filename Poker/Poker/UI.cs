using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class UI
    {
        const string askSuit = "What Suit is the card?"
                            + "\n{0}Clubs"
                            + "\n{1}Diamonds"
                            + "\n{2}Hearts"
                            + "\n{3}Spades";

        const string askRank = "What Rank is the card?"
                            + "\n{2}Two"
                            + "\n{3}Three"
                            + "\n..."
                            + "\n{10}Ten"
                            + "\n{11}Jack"
                            + "\n{12}Queen"
                            + "\n{13}King"
                            + "\n{14}Ace";
        public static void Run()
        {
            var otherPlayers = InputNumber("How many other players are there?");
            Console.WriteLine("");

            var hand = new List<Card>()
            {
                InputCard("Please give the details of your first card."),
                InputCard("Please give the details of your second card."),
            };

            var p = MonteCarlo.CalculateProbability(hand, otherPlayers, 10000);

            foreach (var c in hand) Console.WriteLine(c);
            Console.WriteLine(p);
        }

        static int InputNumber(string question)
        {
            int input;
            do
            {
                Console.WriteLine(question);
            } while (!Int32.TryParse(Console.ReadLine(), out input));
            return input;
        }

        static Card InputCard(string titleLine = null)
        {
            if (!string.IsNullOrEmpty(titleLine)) Console.WriteLine(titleLine);
            Console.WriteLine("");
            
            Suit suit;
            Rank rank;

            do
            {
                suit = (Suit)InputNumber(askSuit);
            } while (!Enum.IsDefined(typeof(Suit), suit));

            do
            {
                rank = (Rank)InputNumber(askRank);
            } while (!Enum.IsDefined(typeof(Rank), rank));
            
            Console.WriteLine("");

            return new Card(rank, suit);
        }
    }
}
