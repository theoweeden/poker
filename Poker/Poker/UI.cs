using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class UI
    {
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

            var suit = (Suit)InputNumber("What Suit is the card?");
            var rank = (Number)InputNumber("What Rank is the card?");
            
            Console.WriteLine("");

            return new Card(rank, suit);
        }
    }
}
