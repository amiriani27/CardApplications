using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardApps.Common
{
    public class CONSTANTS
    {
        // private Deck and Player objects for the current deck, dealer, and player
        public const int EUCHRE_HAND = 5;
        public const int PINNOCLE_HAND = 12;
        public const int BRIDGE_HAND = 13;
        public const int CASINO_HAND = 4;
        public const int CASINO_TABLE_CARDS = 4;
        public const int PHASE_10_HAND = 10;

        // Deck Size
        public const int STANDARD_DECK = 52;
        public const int PINNOCLE_DECK = 48; // Includes only 9-A, x2
        public const int EUCHRE_DECK = 24; // Includes only 9-A

        // 2 of each value, 1 through 12 (Ace through Queen, or Two through King), in each of 4 colors (or suits)
        // Also includes 8 wild cards and 4 skip cards
        public const int PHASE_TEN_DECK = 108;

        public const int STANDARD_DECK_w_JOKERS = 54;

        // Card Values
        public const int WILD_VALUE = 15;
        public const int SKIP_VALUE = 16;
        public const int REVERSE_VALUE = 17;
        public const int DRAW_TWO_VALUE = 18;
        public const int DRAW_FOUR_WILD_VALUE = 19;
    }

    public enum GameType
    {
        euchre,
        pinnochle,
        bridge,
        casino,
        phase10,
        war
    }
}
