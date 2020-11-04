
namespace CardApps.Common
{
    /// <summary>
    /// EndResult maintains the game result state
    /// </summary>
    public enum EndResult
    {
        DealerBlackJack, PlayerBlackJack, PlayerBust, DealerBust, Push, PlayerWin, DealerWin
    }

    public enum PlayerDecision
    {
        NoDecision, Pass, PickItUp, PickItUpGoingAlone
    }

    public enum GameStates
    {
        Idle, PlayerDecisions, PlayCards, HandDecision, EndHand, PlayerCallsTrump
    }

    public enum TrumpSuit
    {
        Clubs, Diamonds, Hearts, Spades
    }
}
