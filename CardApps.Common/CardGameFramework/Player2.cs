using System.Collections.Generic;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace CardApps.Common
{
    public class PlayerObject
    {
        public string Name { get; set; }
        public Queue<Card2> Deck { get; set; }
        public PlayerObject() { }
        public PlayerObject(string name)
        {
            Name = name;
        }

        public Queue<Card2> Deal(Queue<Card2> cards)
        {
            Queue<Card2> player1cards = new Queue<Card2>();
            Queue<Card2> player2cards = new Queue<Card2>();

            int counter = 2;
            while (cards.Any())
            {
                if (counter % 2 == 0) //Card etiquette says the player who is NOT the dealer gets first card
                {
                    player2cards.Enqueue(cards.Dequeue());
                }
                else
                {
                    player1cards.Enqueue(cards.Dequeue());
                }
                counter++;
            }

            Deck = player1cards;
            return player2cards;
        }
    }
}
