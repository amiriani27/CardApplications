
namespace CardApps.Common
{
    /// <summary>
    /// Card suit values
    /// </summary>
    public enum Suit
    {
        Diamonds, Spades, Clubs, Hearts
    }

    /// <summary>
    /// Card face values for Standard Deck, Euchre Deck and Pinnochle Deck
    /// </summary>
    public enum FaceValue
    {
        Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8,
        Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14
    }
    public enum FaceValue_Euchre
    {
        Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14
    }
    public enum FaceValue_Pinnochle
    {
        Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14
    }

    /// <summary>
    /// Deck Type - Standard, Euchre, Pinnochle
    /// </summary>
    public enum DeckType
    {
        Standard = 1, Euchre = 2, Pinnochle = 3, Custom = 4
    }

    public class Card
    {
        // Objects for card information
        private readonly Suit suit;
        private readonly FaceValue faceVal;
        private readonly FaceValue_Euchre faceVal_Euchre;
        private readonly FaceValue_Pinnochle faceVal_Pinnochle;
        private bool isCardUp;
        private DeckType _DeckType;

        public Suit Suit { get { return suit; } }
        public FaceValue FaceVal { get { return faceVal; } }
        public FaceValue_Euchre FaceVal_Euchre { get { return faceVal_Euchre; } }
        public FaceValue_Pinnochle FaceVal_Pinnochle { get { return faceVal_Pinnochle; } }
        public bool IsCardUp { get { return isCardUp; } set { isCardUp = value; } }

        /// <summary>
        /// Constructor for a new card.  Assign the card a suit, face value, and if the card is facing up or down
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="faceVal"></param>
        /// <param name="isCardUp"></param>
        public Card(Suit suit, FaceValue faceVal, bool isCardUp)
        {
            this.suit = suit;
            this.faceVal = faceVal;
            this.isCardUp = isCardUp;
            _DeckType = DeckType.Standard;  
        }

        public Card(Suit suit, FaceValue_Euchre faceVal_Euchre, bool isCardUp)
        {
            this.suit = suit;
            this.faceVal_Euchre = faceVal_Euchre;
            this.faceVal = (FaceValue)faceVal_Euchre;
            this.isCardUp = isCardUp;
            _DeckType = DeckType.Euchre;  
        }

        public Card(Suit suit, FaceValue_Pinnochle faceVal_Pinnochle, bool isCardUp)
        {
            this.suit = suit;
            this.faceVal_Pinnochle = faceVal_Pinnochle;
            this.isCardUp = isCardUp;
            _DeckType = DeckType.Pinnochle; 
        }

        /// <summary>
        /// Return the card as a string (i.e. "The Ace of Spades")
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (_DeckType == DeckType.Pinnochle)
                return suit.ToString().ToUpper() + ": " + faceVal_Pinnochle.ToString();
            else if  (_DeckType == DeckType.Euchre)
                return suit.ToString().ToUpper() + ": " + faceVal_Euchre.ToString();
            else
                return suit.ToString().ToUpper() + ": " + faceVal.ToString();
        }
    }
}
