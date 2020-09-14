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

            var cardsOnTable = InputNumber("How many cards are revealed on the table?");

            var table = new List<Card>();

            for(int i = 0; i < cardsOnTable; i++)
            {
                table.Add(InputCard($"{i + 1}. Please give the details of a card on the table."));
            }

            Console.WriteLine("Hand:");
            foreach (var c in hand) Console.WriteLine(c);

            Console.WriteLine("");

            Console.WriteLine("Table:");
            foreach (var c in table) Console.WriteLine(c);

            Console.WriteLine("\nThinking...\n");

            var p = MonteCarlo.CalculateProbability(hand, table, otherPlayers, 10000);

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

        static T InputEnum<T>(string question) where T : Enum
        {
            T t;
            do
            {    
                t = (T)(object)InputNumber(question);
            } while (!Enum.IsDefined(typeof(T), t));
            return t;
        }

        static Card InputCard(string titleLine = null)
        {
            if (!string.IsNullOrEmpty(titleLine)) Console.WriteLine(titleLine);
            Console.WriteLine("");
            
            var suit = InputEnum<Suit>(askSuit);
            var rank = InputEnum<Rank>(askRank);
            
            Console.WriteLine("");

            return new Card(rank, suit);
        }
    }
}
