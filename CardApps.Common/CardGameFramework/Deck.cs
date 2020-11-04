using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CardApps.Common
{
    public class Deck
    {
        // Creates a list of cards
        protected List<Card> cards = new List<Card>();

        // Returns the card at the given position
        public Card this[int position] { get { return (Card)cards[position]; } }

        /// <summary>
        /// One complete deck with every face value and suit
        /// </summary>
        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (FaceValue faceVal in Enum.GetValues(typeof(FaceValue)))
                {
                    cards.Add(new Card(suit, faceVal, true));
                }
            }
        }

        public Deck(string strType)
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                if (strType == "Euchre")
                {
                    foreach (FaceValue_Euchre faceVal in Enum.GetValues(typeof(FaceValue_Euchre)))
                    {
                        cards.Add(new Card(suit, faceVal, true));
                    }
                }
                else if (strType == "Pinnochle")
                {
                    foreach (FaceValue_Pinnochle faceVal in Enum.GetValues(typeof(FaceValue_Pinnochle)))
                    {
                        cards.Add(new Card(suit, faceVal, true));
                    }
                    foreach (FaceValue_Pinnochle faceVal in Enum.GetValues(typeof(FaceValue_Pinnochle)))
                    {
                        cards.Add(new Card(suit, faceVal, true));
                    }
                }
                else
                {
                    foreach (FaceValue faceVal in Enum.GetValues(typeof(FaceValue)))
                    {
                        cards.Add(new Card(suit, faceVal, true));
                    }
                }
            }
        }

        /// <summary>
        /// Draws one card and removes it from the deck
        /// </summary>
        /// <returns></returns>
        public Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        /// <summary>
        /// Draws one card and removes it from the deck
        /// </summary>
        /// <returns></returns>
        public List<Card> DrawMultiple(int numToDraw)
        {
            List<Card> cardsToReturn = new List<Card>();

            for (int index = 0; index < numToDraw; index++)
            {
                Card card = cards[0];
                cards.RemoveAt(0);

                cardsToReturn.Add(card);
            }

            return cardsToReturn;
        }

        /// <summary>
        /// Shuffles the cards in the deck
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int index1 = i;
                int index2 = random.Next(cards.Count);
                SwapCard(index1, index2);
            }
        }

        /// <summary>
        /// Swaps the placement of two cards
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        private void SwapCard(int index1, int index2)
        {
            Card card = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = card;
        }

        /// <summary>
        /// Return the current count of cards in the deck
        /// </summary>
        /// <returns>Number of cards remaining in deck as Int</returns>
        public int NumOfCardsInDeck()
        {
            return cards.Count;
        }
    }
}
