using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using CardApps.Common;

namespace CardApps.WindowsApp
{
    partial class Form1 : Form
    {
        #region Fields

        private GameManger gameManager = null;

        private int PLAYER_HAND;
        const int DECK_SIZE = 4;
        private PictureBox[] playerCards;
        Euchre game = new Euchre();
        
        
        public delegate void myDelegate();
        static bool endPlay = false;
        static GameStates gameStates;

        private string sMessage = "";
        private bool _hideDecisions = false;

        #endregion
        public Form1()
        {
            InitializeComponent();
            
        }
# region Enums
        public enum GameType
        {
            euchre,
            pinnochle,
            bridge,
            casino
        }
        # endregion

        private void cmdExit_Click(object sender, EventArgs e)
        {
            if (gameManager.MainThread != null)
            {
                if (gameManager.MainThread.IsAlive)
                    gameManager.MainThread.Abort();
            }
            
            Application.Exit();
        }

        private void cmdShuffle_Click(object sender, EventArgs e)
        {

            if (optEuchre.Checked == true)
            {
                game.SelectedGame = Euchre.GameType.euchre;
                PLAYER_HAND = 5;
            }
            else if (optPinnochle.Checked == true)
            {
                game.SelectedGame = Euchre.GameType.pinnochle;
                PLAYER_HAND = 12;
            }
            else if (optCasino.Checked == true)
            {
                game.SelectedGame = Euchre.GameType.casino;
                PLAYER_HAND = 4;
            }
            else
            {
                game.SelectedGame = Euchre.GameType.bridge;
                PLAYER_HAND = 13;
            }
            game.DealNewGame();

            UpdateUIPlayerCards(); //Show the cards

            playOrPass1.Visible = true;
            playOrPass2.Visible = true;
            playOrPass3.Visible = true;
            playOrPass4.Visible = true;

            if (!StartGame())
                MessageBox.Show("FAILED TO INITIALIZE", "Start", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Load the Deck Card Images
        /// </summary>
        private void LoadCardSkinImages()
        {
            try
            {
                string cardSkinLocation = Properties.Settings.Default.CardGameImageSkinPath;

                if (cardSkinLocation != string.Empty)
                {
                    // Load the card skin image from file
                    Image cardSkin = Image.FromFile(cardSkinLocation);
                    // Set the three cards on the UI to the card skin image
                    pbCards.Image = cardSkin;
                }
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Card skin images are not loading correctly.  Make sure the card skin images are in the correct location.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Exception: " + ex.Message);
            }

            playerCards = new PictureBox[] { pbCards };
        }

        private void UpdateUIPlayerCards()
        {
            lstPlayer1.Items.Clear();
            lstPlayer2.Items.Clear();
            lstPlayer3.Items.Clear();
            lstPlayer4.Items.Clear();
            lstDeck.Items.Clear();

            lstPlayer1.Sorted = true;
            lstPlayer2.Sorted = true;
            lstPlayer3.Sorted = true;
            lstPlayer4.Sorted = true;
            lstDeck.Sorted = true;

            List<Card> p1cards = game.Player1.Hand.Cards;
            for (int i = 0; i < PLAYER_HAND; i++)
            {
                lstPlayer1.Items.Add(p1cards[i].ToString());
                // Load each card from file
                //LoadCard(playerCards[i], p1cards[i]);
                //playerCards[i].Visible = true;
                //playerCards[i].BringToFront();
            }

            LoadCard(p1Card1, p1cards[0]);
            p1Card1.Visible = true;
            p1Card1.BringToFront();

            LoadCard(p1Card2, p1cards[1]);
            p1Card2.Visible = true;
            p1Card2.BringToFront();

            LoadCard(p1Card3, p1cards[2]);
            p1Card3.Visible = true;
            p1Card3.BringToFront();

            LoadCard(p1Card4, p1cards[3]);
            p1Card4.Visible = true;
            p1Card4.BringToFront();

            if (PLAYER_HAND != 4)
            {
                LoadCard(p1Card5, p1cards[4]);
                p1Card5.Visible = true;
                p1Card5.BringToFront();
            }


            List<Card> p2cards = game.Player2.Hand.Cards;
            for (int i = 0; i < PLAYER_HAND; i++)
            {
                lstPlayer2.Items.Add(p2cards[i].ToString());
                // Load each card from file
                //LoadCard(pcards[i], pcards[i]);
                //playerCards[i].Visible = true;
                //playerCards[i].BringToFront();
            }
            
            LoadCard(p2Card1, p2cards[0]);
            p2Card1.Visible = true;
            p2Card1.BringToFront();

            LoadCard(p2Card2, p2cards[1]);
            p2Card2.Visible = true;
            p2Card2.BringToFront();

            LoadCard(p2Card3, p2cards[2]);
            p2Card3.Visible = true;
            p2Card3.BringToFront();

            LoadCard(p2Card4, p2cards[3]);
            p2Card4.Visible = true;
            p2Card4.BringToFront();

            if (PLAYER_HAND != 4)
            {
                LoadCard(p2Card5, p2cards[4]);
                p2Card5.Visible = true;
                p2Card5.BringToFront();
            }

            List<Card> p3cards = game.Player3.Hand.Cards;
            for (int i = 0; i < PLAYER_HAND; i++)
            {
                lstPlayer3.Items.Add(p3cards[i].ToString());
                // Load each card from file
                //LoadCard(pcards[i], pcards[i]);
                //playerCards[i].Visible = true;
                //playerCards[i].BringToFront();
            }
            LoadCard(p3Card1, p3cards[0]);
            p3Card1.Visible = true;
            p3Card1.BringToFront();

            LoadCard(p3Card2, p3cards[1]);
            p3Card2.Visible = true;
            p3Card2.BringToFront();

            LoadCard(p3Card3, p3cards[2]);
            p3Card3.Visible = true;
            p3Card3.BringToFront();

            LoadCard(p3Card4, p3cards[3]);
            p3Card4.Visible = true;
            p3Card4.BringToFront();

            if (PLAYER_HAND != 4)
            {
                LoadCard(p3Card5, p3cards[4]);
                p3Card5.Visible = true;
                p3Card5.BringToFront();
            }

            List<Card> p4cards = game.Player4.Hand.Cards;
            for (int i = 0; i < PLAYER_HAND; i++)
            {
                lstPlayer4.Items.Add(p4cards[i].ToString());
                // Load each card from file
                //LoadCard(pcards[i], pcards[i]);
                //playerCards[i].Visible = true;
                //playerCards[i].BringToFront();
            }

            LoadCard(p4Card1, p4cards[0]);
            p4Card1.Visible = true;
            p4Card1.BringToFront();

            LoadCard(p4Card2, p4cards[1]);
            p4Card2.Visible = true;
            p4Card2.BringToFront();

            LoadCard(p4Card3, p4cards[2]);
            p4Card3.Visible = true;
            p4Card3.BringToFront();

            LoadCard(p4Card4, p4cards[3]);
            p4Card4.Visible = true;
            p4Card4.BringToFront();

            if (PLAYER_HAND != 4)
            {
                LoadCard(p4Card5, p4cards[4]);
                p4Card5.Visible = true;
                p4Card5.BringToFront();
            }

            if (PLAYER_HAND != 4)
            {
                Deck dcards = game.CurrentDeck;
                if (game.SelectedGame == Euchre.GameType.euchre)
                {
                    for (int i = 0; i < DECK_SIZE; i++)
                    {
                        lstDeck.Items.Add(dcards[i].ToString());
                        // Load each card from file
                        //LoadCard(pcards[i], pcards[i]);
                        //playerCards[i].Visible = true;
                        //playerCards[i].BringToFront();
                    }
                    txtTrump.Text = dcards[0].ToString();
                }

                LoadCard(dCard1, dcards[0]);
                dCard1.Visible = true;
                dCard1.BringToFront();

                LoadCard(dCard2, dcards[1]);
                dCard2.Visible = false;

                LoadCard(dCard3, dcards[2]);
                dCard3.Visible = false;

                LoadCard(dCard4, dcards[3]);
                dCard4.Visible = false;
            }
        }
        /// <summary>
        /// Takes the card value and loads the corresponding card image from file
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="c"></param>
        private void LoadCard(PictureBox pb, CardApps.Common.Card c)
        {
            try
            {
                StringBuilder image = new StringBuilder();

                switch (c.Suit)
                {
                    case Suit.Diamonds:
                        image.Append("di");
                        break;
                    case Suit.Hearts:
                        image.Append("he");
                        break;
                    case Suit.Spades:
                        image.Append("sp");
                        break;
                    case Suit.Clubs:
                        image.Append("cl");
                        break;
                }

                switch (c.FaceVal)
                {
                    case FaceValue.Ace:
                        image.Append("1");
                        break;
                    case FaceValue.King:
                        image.Append("k");
                        break;
                    case FaceValue.Queen:
                        image.Append("q");
                        break;
                    case FaceValue.Jack:
                        image.Append("j");
                        break;
                    case FaceValue.Ten:
                        image.Append("10");
                        break;
                    case FaceValue.Nine:
                        image.Append("9");
                        break;
                    case FaceValue.Eight:
                        image.Append("8");
                        break;
                    case FaceValue.Seven:
                        image.Append("7");
                        break;
                    case FaceValue.Six:
                        image.Append("6");
                        break;
                    case FaceValue.Five:
                        image.Append("5");
                        break;
                    case FaceValue.Four:
                        image.Append("4");
                        break;
                    case FaceValue.Three:
                        image.Append("3");
                        break;
                    case FaceValue.Two:
                        image.Append("2");
                        break;
                }

                image.Append(Properties.Settings.Default.CardGameImageExtension);
                string cardGameImagePath = Properties.Settings.Default.CardGameImagePath;
                string cardGameImageSkinPath = Properties.Settings.Default.CardGameImageSkinPath;
                image.Insert(0, cardGameImagePath);
                
                //check to see if the card should be faced down or up;
                if (!c.IsCardUp)
                    image.Replace(image.ToString(), cardGameImageSkinPath);

                pb.Image = new Bitmap(image.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Card images are not loading correctly.  Make sure all card images are in the right location.");
            }
        }

        private void LoadConfiguration()
        {
   

        }

        private void LoadGame()
        {
            gameManager = new GameManger();
        }

        private bool StartGame()
        {
            try
            {
                gameStates = GameStates.Idle;

                gameManager.MainThread = new Thread(new ThreadStart(GamePlay));
                gameManager.MainThread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return true;
        }

        private void lstPlayer1_DoubleClick(object sender, EventArgs e)
        {
            lstPlayer1.Items.Clear();  
        }

        private void lstPlayer4_DoubleClick(object sender, EventArgs e)
        {
            lstPlayer4.Items.Clear();
        }

        private void lstPlayer2_DoubleClick(object sender, EventArgs e)
        {
            lstPlayer2.Items.Clear();
        }

        private void lstPlayer3_DoubleClick(object sender, EventArgs e)
        {
            lstPlayer3.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCardSkinImages();
            LoadConfiguration();
            LoadGame();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void cmdShowDealer_Click(object sender, EventArgs e)
        {
            if (dCard2.Visible == true)
            {
                dCard2.Visible = false;
                dCard3.Visible = false;
                dCard4.Visible = false;
            }
            else
            {
                dCard2.Visible = true;
                dCard3.Visible = true;
                dCard4.Visible = true;
            }

        }

        private void UpdateGUI()
        {
            if (label1.InvokeRequired)
            {
                //Invoke the Label for update
                label1.Invoke(new myDelegate(UpdateGUI));
            }
            else
            {
                label1.Text = sMessage;

                if (_hideDecisions == true)
                {
                    _hideDecisions = false;

                    playOrPass1.Visible = false;
                    playOrPass2.Visible = false;
                    playOrPass3.Visible = false;
                    playOrPass4.Visible = false;
                }
            }
        }

        private void optCasino_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GamePlay()
        {
            int iCardsPlayed = 0;

            while (!endPlay)
            {
                switch (gameStates)
                {
                    case GameStates.Idle:
                        gameStates = GameStates.PlayerDecisions;
                        break;

                    case GameStates.PlayerDecisions:
                        //After a Player Orders it Up, Set all other players to Pass
                        if ((game.Player1.GetPlayerDecision != PlayerDecision.NoDecision) &&
                            (game.Player2.GetPlayerDecision != PlayerDecision.NoDecision) &&
                            (game.Player3.GetPlayerDecision != PlayerDecision.NoDecision) &&
                            (game.Player4.GetPlayerDecision != PlayerDecision.NoDecision))
                        {
                            //Will Still need to check if all players passed and move to calling it up
                            if ((game.Player1.GetPlayerDecision != PlayerDecision.Pass) &&
                                (game.Player2.GetPlayerDecision != PlayerDecision.Pass) &&
                                (game.Player3.GetPlayerDecision != PlayerDecision.Pass) &&
                                (game.Player4.GetPlayerDecision != PlayerDecision.Pass))
                            {
                                
                                sMessage = "Players Decided";
                                UpdateGUI();
                                gameStates = GameStates.PlayCards;
                            }
                            else
                            {
                                game.Player1.GetPlayerDecision = PlayerDecision.NoDecision;
                                game.Player2.GetPlayerDecision = PlayerDecision.NoDecision;
                                game.Player3.GetPlayerDecision = PlayerDecision.NoDecision;
                                game.Player4.GetPlayerDecision = PlayerDecision.NoDecision;

                                sMessage = "Players Need to Decide Trump";
                                UpdateGUI();
                                gameStates = GameStates.PlayerCallsTrump;
                            }
                        }
                        break;

                    case GameStates.PlayerCallsTrump:
                        //After a Player Names Trump, Set all other players to Pass
                        if ((game.Player1.GetPlayerDecision != PlayerDecision.NoDecision) &&
                            (game.Player2.GetPlayerDecision != PlayerDecision.NoDecision) &&
                            (game.Player3.GetPlayerDecision != PlayerDecision.NoDecision) &&
                            (game.Player4.GetPlayerDecision != PlayerDecision.NoDecision))
                        {
                            sMessage = "Players Decided";
                            _hideDecisions = true;
                            UpdateGUI();
                            gameStates = GameStates.PlayCards;
                        }
                        break;
                        

                    case GameStates.PlayCards:
                        if ((game.Player1.CardPlayed) &&
                            (game.Player2.CardPlayed) &&
                            (game.Player3.CardPlayed) &&
                            (game.Player4.CardPlayed))
                        {
                            game.Player1.CardPlayed = false;
                            game.Player2.CardPlayed = false;
                            game.Player3.CardPlayed = false;
                            game.Player4.CardPlayed = false;

                            iCardsPlayed += 1;

                            sMessage = "Cards Played";
                            UpdateGUI();
                            gameStates = GameStates.HandDecision;
                        }
                        
                        break;

                    case GameStates.HandDecision:
                        if (!(iCardsPlayed < 5))
                        {
                            sMessage = "Hand Completed";
                            UpdateGUI();
                            gameStates = GameStates.EndHand;
                        
                        }
                        else
                        {
                            //May need to clear board of played cards
                            sMessage = "Next Round Started";
                            UpdateGUI();
                            gameStates = GameStates.PlayCards;
                        }
                            
                        break;

                    case GameStates.EndHand:
                        endPlay = true;
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Player1.GetPlayerDecision = PlayerDecision.Pass;
            game.Player2.GetPlayerDecision = PlayerDecision.Pass;
            game.Player3.GetPlayerDecision = PlayerDecision.Pass;
            game.Player4.GetPlayerDecision = PlayerDecision.Pass;
        }

        private void button2_Click(object sender, EventArgs e)
        {
             game.Player1.CardPlayed = true;
             game.Player2.CardPlayed = true;
             game.Player3.CardPlayed = true;
             game.Player4.CardPlayed = true;
        }

        private int EnumerateOptionSelected(string optSelect)
        {
            int retValue = 0; // NoDecision, Pass, PickItUp, PickItUpGoingAlone

            switch (optSelect)
            {
                case "PASS":
                    retValue = 1;
                    break;
                case "PICK":
                    retValue = 2;
                    break;
                case "ALONE":
                    retValue = 3;
                    break;
                default:
                    retValue = 0;
                    break;
            }

            return retValue;
        }

        private void playOrPass1_OptionClicked(string optSelected)
        {
            game.Player1.GetPlayerDecision = (PlayerDecision)EnumerateOptionSelected(optSelected);
        }

        private void playOrPass2_OptionClicked(string optSelected)
        {
            game.Player2.GetPlayerDecision = (PlayerDecision)EnumerateOptionSelected(optSelected);
        }

        private void playOrPass3_OptionClicked(string optSelected)
        {
            game.Player3.GetPlayerDecision = (PlayerDecision)EnumerateOptionSelected(optSelected);
        }

        private void playOrPass4_OptionClicked(string optSelected)
        {
            game.Player4.GetPlayerDecision = (PlayerDecision)EnumerateOptionSelected(optSelected);
        }

        //private void OptionClicked()
        //{
        //    MessageBox.Show("Hello ");
        //    this.Close();
        //}

        //private void playOrPass2_OptionClicked()
        //{
        //    MessageBox.Show("Hello ");
        //    //this.Close();
        //}
    }
}
