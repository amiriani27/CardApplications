using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardApps.Common;

namespace CardApps.UnitTest
{
    [TestClass]
    public class DeckTests
    {
        #region -- Euchre --
        
        [TestMethod]
        public void InitializeEuchreGame()
        {
            Euchre game = new Euchre(4);
            game.SelectedGame = Euchre.GameType.euchre;

            game.DealNewGame();

            Deck dCards = game.CurrentDeck;
            dCards.Shuffle();

            Assert.IsNotNull(dCards);

        }

        [TestMethod]
        public void DealFirstEuchreHand_CountCardsRemaining()
        {
            int intNumOfPlayers = 4;
            int expectedCardsLeft = CONSTANTS.EUCHRE_DECK - (intNumOfPlayers * 5);
            Euchre game = new Euchre(intNumOfPlayers);

            game.SelectedGame = Euchre.GameType.euchre;
            game.DealNewGame();

            Deck dCards = game.CurrentDeck;
            Assert.IsNotNull(dCards);
            Assert.AreEqual(dCards.NumOfCardsInDeck(), expectedCardsLeft);

        }
        
        #endregion

        #region -- Casino --
        
        [TestMethod]
        public void InitializeCasinoGame()
        {
            Casino game = new Casino(4);
            game.SelectedGame = Casino.GameType.casino;

            game.DealNewGame();

            Deck dCards = game.CurrentDeck;
            dCards.Shuffle();

            Assert.IsNotNull(dCards);

        }

        [TestMethod]
        public void DealFirstCasinoHand_CountCardsRemaining()
        {
            int intNumOfPlayers = 3;
            int expectedCardsLeft = CONSTANTS.STANDARD_DECK - (intNumOfPlayers * 4);
            Casino game = new Casino(intNumOfPlayers);

            game.SelectedGame = Casino.GameType.casino;
            game.DealNewGame();

            Deck dCards = game.CurrentDeck;
            Assert.IsNotNull(dCards);
            Assert.AreEqual(game.CardsOnTable.Hand.NumCards, 4);
            Assert.AreEqual(dCards.NumOfCardsInDeck(), expectedCardsLeft - game.CardsOnTable.Hand.NumCards);

        }
        
        #endregion

        #region -- Pinnocle --
        
        [TestMethod]
        public void InitializePinnocleGame()
        {
            Pinnocle game = new Pinnocle(4);
            game.SelectedGame = Pinnocle.GameType.pinnochle;

            game.DealNewGame();

            Deck dCards = game.CurrentDeck;
            dCards.Shuffle();

            Assert.IsNotNull(dCards);

        }

        [TestMethod]
        public void DealFirstPinnocleHand_CountCardsRemaining()
        {
            int intNumOfPlayers = 4;
            int expectedCardsLeft = CONSTANTS.PINNOCLE_DECK - (intNumOfPlayers * 12);
            Pinnocle game = new Pinnocle(intNumOfPlayers);

            game.SelectedGame = Pinnocle.GameType.pinnochle;
            game.DealNewGame();

            Deck dCards = game.CurrentDeck;
            Assert.IsNotNull(dCards);
            Assert.AreEqual(dCards.NumOfCardsInDeck(), expectedCardsLeft);

        }
       
        #endregion
    }
}
