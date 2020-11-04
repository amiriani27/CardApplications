using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardApps.Common;

namespace CardsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPlayers = 3;

            Casino game = new Casino(numOfPlayers);
            game.SelectedGame = Casino.GameType.casino;
            game.DealNewGame();

            Deck dCards = game.CurrentDeck;

            string playerHand1 = game.Player1.ToString();
            Console.WriteLine("Player 1:\n" + playerHand1);
            Console.ReadLine();

            string playerHand2 = game.Player2.ToString();
            Console.WriteLine("Player 2:\n" + playerHand2);
            Console.ReadLine();

            string playerHand3 = game.Player3.ToString();
            Console.WriteLine("Player 3:\n" + playerHand3);
            Console.ReadLine();

            string dealerHand = game.CardsOnTable.ToString();
            Console.WriteLine("Dealer:\n" + dealerHand);
            Console.ReadLine();
        }
    }
}
