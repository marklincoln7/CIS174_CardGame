using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame
{
    public enum SuitType { Clubs, Diamonds, Hearts, Spades };
    public enum PipType { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
    /*
        This is just my interpretation of how we could implement a playing card. Let me know what you guys think.
    */
    public class Card
    {
        public Card(SuitType suit, PipType pip, int imgIdx)
        {
            Suit = suit;
            Pip = pip;
            ImageIndex = imgIdx;
        }

        public SuitType Suit { get; private set; }
        public PipType Pip { get; private set; }
        public int ImageIndex { get; private set; }

        public override String ToString()
        {
            return Pip + " of " + Suit;
        }
    }
}