using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CardApps.Common
{
    public static class GameManager
    {
        private static Thread _mainThread = null;
        public static Thread MainThread { get { return _mainThread; } set { _mainThread = value; } }

        public static List<PictureBox> LoadCardSkinImages(string imageLocation)
        {
            PictureBox pbCards = new PictureBox();
            try
            {
                //string cardSkinLocation = Properties.Settings.Default.CardGameImageSkinPath;

                if (imageLocation != string.Empty)
                {
                    // Load the card skin image from file
                    System.Drawing.Image cardSkin = System.Drawing.Image.FromFile(imageLocation);
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

            return new PictureBox[] { pbCards }.ToList();
        }

        public static Queue<Card2> GameDeck { get; set; }
        public static GameType TypeOfGame { get; set; }
    }
}
