using CardApps.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardApps.WindowsApp
{
    public partial class Form2 : Form
    {
        private PictureBox[] gameCards;
        private string cardSkinLocation = Properties.Settings.Default.CardGameImageSkinPath;

        #region CONSTANTS
        private int FORM_WIDTH = 1500;
        private int FORM_HEIGHT = 700;


        #endregion
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            SetupGameSpace();
        }

        private void SetupGameSpace()
        {
            GameManager.GameDeck = DeckCreator.CreateCards(GameManager.TypeOfGame); //Returns a shuffled set of cards

            Panel pnl = new Panel();
           // pnl.pos
            pnl.Size = new Size(FORM_WIDTH-300, FORM_HEIGHT-100);
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Location = new Point(100, 100);

            this.Controls.Add(pnl);

            Button btnExit = new Button();
            btnExit.Text = "EXIT";
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Size = new Size(90, 25);
            btnExit.Location = new Point(pnl.Width - btnExit.Size.Width - 10, pnl.Height - btnExit.Size.Height - 10);
            btnExit.Click += BtnExit_Click;

            pnl.Controls.Add(btnExit);
            PictureBox pBox = new PictureBox();

            StringBuilder sb = new StringBuilder();
            foreach (Card2 crd2 in GameManager.GameDeck)
            {
                sb.Append($"::{crd2.DisplayName}");
            }
            sb.Append($"::TotalCards-{GameManager.GameDeck.Count}");
            sb.AppendLine();

            Label lbl = new Label();
            lbl.Text = sb.ToString();
            lbl.Location = new Point(10, 10);
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.AutoSize = true;
            pnl.Controls.Add(lbl);

            //frm.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
