using System.Collections.Generic;
 
namespace CardApps.Common
{
    public class Pinnocle
    {
        #region Fields

        // private Deck and Player objects for the current deck, dealer, and player
        ////private const int EUCHRE_HAND = 5;
        ////private const int PINNOCLE_HAND = 12;
        ////private const int BRIDGE_HAND = 13;
        ////private const int CASINO_HAND = 4;

        private Deck deck;
        private Player[] player;
        private GameType _selectedGame;
        private int _numberOfCardsperHand;
        private int _currentPlayer = 0;
        private int _numberOfPlayers;
        #endregion

        #region Properties

        // public properties to return the current player and current deck
        public Player Player1 { get { return player[0]; } }
        public Player Player2 { get { return player[1]; } }
        public Player Player3 { get { return player[2]; } }
        public Player Player4 { get { return player[3]; } }
        //public Player CardsOnTable { get { return cardsOnTable; } }
        public Deck CurrentDeck { get { return deck; } }
        public GameType SelectedGame { get { return _selectedGame; } set { _selectedGame = value; } }

        #endregion

        # region Enums

        public enum GameType
        {
            euchre,
            pinnochle,
            bridge,
            casino
        }
        # endregion

        #region Main Game Constructor

        /// <summary>
        /// Main Constructor for BlackJack Game
        /// </summary>
        /// <param name="initBalance"></param>
        public Pinnocle()
        {
            // Create a dealer and one player with the initial balance.
            //dealer = new Player();
            //player = new Player(initNumofPlayers);
            player = new Player[4];
            player[0] = new Player();
            player[1] = new Player();
            player[2] = new Player();
            player[3] = new Player();

            _numberOfPlayers = 4;
        }

        public Pinnocle(int numOfPlayers)
        {
            player = new Player[numOfPlayers];
            for (int index = 0; index < numOfPlayers; index++)
            {
                player[index] = new Player();
            }

            _numberOfPlayers = numOfPlayers;
        }

        #endregion

        #region Game Methods

        /// <summary>
        /// Deals a new game.  This is invoked through the Deal button in BlackJackForm.cs
        /// </summary>
        public void DealNewGame()
        {
            // Create a new deck and then shuffle the deck
            switch (_selectedGame)
            {
                case (GameType.euchre):
                    deck = new Deck("Euchre");
                    _numberOfCardsperHand = CONSTANTS.EUCHRE_HAND;
                    break;
                case GameType.pinnochle:
                    deck = new Deck("Pinnochle");
                    _numberOfCardsperHand = CONSTANTS.PINNOCLE_HAND; 
                    break;
                case GameType.bridge:
                    deck = new Deck("Bridge");
                    _numberOfCardsperHand = CONSTANTS.BRIDGE_HAND; 
                    break;
                case GameType.casino:
                    deck = new Deck("Casino");
                    _numberOfCardsperHand = CONSTANTS.CASINO_HAND;
                    break;
            }

            deck.Shuffle();

            // Reset the player and the dealer's hands in case this is not the first game
            for (int i = 0; i < 4; i++)
            {
                player[i].NewHand();
            }

            // Deal five cards to each person's hand
            for (int i = 0; i < _numberOfCardsperHand; i++)
            {
                Card c1 = deck.Draw();
                player[0].Hand.Cards.Add(c1);
                Card c2 = deck.Draw();
                player[1].Hand.Cards.Add(c2);
                Card c3 = deck.Draw();
                player[2].Hand.Cards.Add(c3);
                Card c4 = deck.Draw();
                player[3].Hand.Cards.Add(c4);

                //Card d = deck.Draw();
                // Set the dealer's second card to be facing down
                //if (i == 1)
                //d.IsCardUp = false;

                //dealer.Hand.Cards.Add(d);
            }
        }

        /// <summary>
        /// Update the player's record with a loss
        /// </summary>
        public void PlayerLose()
        {
            //player.Losses += 1;
        }

        /// <summary>
        /// Update the player's record with a win
        /// </summary>
        public void PlayerWin()
        {
            //player.Balance += player.Bet * 2;
            //player.Wins += 1;
        }

        public void NextPlayer()
        {
            _currentPlayer += 1;
            if (_currentPlayer > _numberOfPlayers - 1)
                _currentPlayer = 0;
        }
        #endregion
    }
}
