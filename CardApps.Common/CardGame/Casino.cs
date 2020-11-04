using System;
using System.Collections.Generic;
using System.Linq;
 
namespace CardApps.Common
{
    public class Casino
    {
        #region Fields

        private Deck deck;
        private Player[] player;
        private Player cardsOnTable;
        private List<Player> playerList = new List<Player>();

        private GameType _SelectedGame;
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
        public Player CardsOnTable {  get { return cardsOnTable; } }
        public Deck CurrentDeck { get { return deck; } }
        public GameType SelectedGame { get { return _SelectedGame; } set { _SelectedGame = value; } }

        public List<Player> PlayerList { get { return playerList; } }

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
        /// Main Constructor
        /// </summary>
        public Casino()
        {
            _numberOfPlayers = 0;
        }

        public Casino(int numOfPlayers)
        {
            player = new Player[numOfPlayers];
            for (int index = 0; index < numOfPlayers; index++)
            {
                player[index] = new Player();
            }

            _numberOfPlayers = numOfPlayers;

            cardsOnTable = new Player();
        }
        #endregion

        #region Game Methods

        /// <summary>
        /// Deals a new game.  This is invoked through the Deal button in BlackJackForm.cs
        /// </summary>
        public void DealNewGame()
        {
            // Create a new deck and then shuffle the deck
            switch (_SelectedGame)
            {
                case (GameType.euchre):
                    deck = new Deck("Euchre");
                    _numberOfCardsperHand = Constants.EUCHRE_HAND;
                    break;
                case GameType.pinnochle:
                    deck = new Deck("Pinnochle");
                    _numberOfCardsperHand = Constants.PINNOCLE_HAND; 
                    break;
                case GameType.bridge:
                    deck = new Deck("Bridge");
                    _numberOfCardsperHand = Constants.BRIDGE_HAND; 
                    break;
                case GameType.casino:
                    deck = new Deck("Casino");
                    _numberOfCardsperHand = Constants.CASINO_HAND;
                    break;
            }

            deck.Shuffle();

            // Reset the player and the dealer's hands in case this is not the first game
            ////for (int i = 0; i < _numberOfPlayers; i++)
            ////{
            ////    player[i].NewHand();
            ////}

            for (int j = 0; j < _numberOfPlayers; j++)
            {
                player[j].NewHand();

                for (int i = 0; i < _numberOfCardsperHand; i++)
                {
                    Card c1 = deck.Draw();
                    player[j].Hand.Cards.Add(c1);
                }

                //player[j].Hand.Cards.OrderBy(o => o.FaceVal);
            }

            // TODO Upon Dealing, remember to deal four cards to the Table (only once - first deal)
            for (int i = 0; i < Constants.CASINO_TABLE_CARDS; i++)
            {
                Card card = deck.Draw();
                cardsOnTable.Hand.Cards.Add((card));
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
