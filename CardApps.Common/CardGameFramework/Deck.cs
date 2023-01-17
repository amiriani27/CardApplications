using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

    public class DeckCreator
    {
        public static Queue<Card2> CreateCards(GameType gameType)
        {
            int _startIndex = 2;    // Normal decks start at the 2 
            int _endIndex = 14;     // and goes through the Ace (J-11, Q-12, K-13, A-14)
            int _deckIndex = 1;     // Some games require double decks (this is the # of decks)

            switch (gameType)
            {
                case GameType.euchre:
                    _startIndex = 9;
                    break;
                case GameType.war:
                    _startIndex = 2;
                    break;
                case GameType.phase10:
                    _startIndex = 2;
                    _endIndex = 13;
                    _deckIndex = 2;
                    break;
                case GameType.pinnochle:
                    _startIndex = 9;
                    _deckIndex = 2;
                    break;
                case GameType.casino:
                    _startIndex = 2;
                    break;
                case GameType.bridge:
                    _startIndex = 2;
                    break;
                default:
                    break;
            }


            // Update to include deck type to allow the queue to reflect the game (standard, euchre, etc.)
            // Pass the ENUM for the deck type and change the range on the for loop below
            Queue<Card2> cards = new Queue<Card2>();

            for (int j = 0; j < _deckIndex; j++)
            {
                for (int i = _startIndex; i <= _endIndex; i++)
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        cards.Enqueue(new Card2()
                        {
                            Suit = suit,
                            Value = i,
                            DisplayName = GetShortName(i, suit)
                        });
                    }
                }

            }

            if (gameType== GameType.phase10)
            {
                Card2 _card = new Card2();

                // Add the 8 wild and 4 skip cards (special)
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    // Add two for each suit == 8. These cards are 'suited' to stay aligned to Cards2 structure
                    for (int index = 0; index < 2; index++)
                    {
                        cards.Enqueue(new Card2()
                        {
                            Suit = suit,
                            Value = CONSTANTS.WILD_VALUE,
                            DisplayName = GetShortName(CONSTANTS.WILD_VALUE, suit)
                        });
                    }

                    // Add one for each suit == 4. These cards are 'suited' to stay aligned to Cards2 structure
                    cards.Enqueue(new Card2()
                    {
                        Suit = suit,
                        Value = CONSTANTS.SKIP_VALUE,
                        DisplayName = GetShortName(CONSTANTS.SKIP_VALUE, suit)
                    });
                }
            }

            return Shuffle(cards);
        }

        private static Queue<Card2> Shuffle(Queue<Card2> cards)
        {
            // Shuffle the existing cards using Fisher-Yates Modern
            List<Card2> transformedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                // Step 2: Randomly pick a card which has not been shuffled
                int k = r.Next(n + 1);

                // Step 3: Swap the selected item 
                //        with the last "unselected" card in the collection
                Card2 temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Queue<Card2> shuffledCards = new Queue<Card2>();
            foreach (var card in transformedCards)
            {
                shuffledCards.Enqueue(card);
            }

            return shuffledCards;
        }

        private static string GetShortName(int value, Suit suit)
        {
            string valueDisplay = "";
            if (value >= 2 && value <= 10)
            {
                valueDisplay = value.ToString();
            }
            else if (value == 11)
            {
                valueDisplay = "J";
            }
            else if (value == 12)
            {
                valueDisplay = "Q";
            }
            else if (value == 13)
            {
                valueDisplay = "K";
            }
            else if (value == 14 || value == 1)
            {
                valueDisplay = "A";
            }
            else if (value == 15)
            {
                valueDisplay = "*";
            }
            else if (value == 16)
            {
                valueDisplay = "~";
            }

            return valueDisplay + Enum.GetName(typeof(Suit), suit)[0];
        }
    }
}
