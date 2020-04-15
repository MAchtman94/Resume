using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEmFaceup
{
    //Use me for each card that is in deck 
    public class Card
    {
        public enum CardSuits { Hearts = 1, Spades = 2, Clubs = 3, Diamonds = 4 };
        public enum CardValues { Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14 };


        public CardSuits cardSuits { get; set; }
        public CardValues cardType { get; set; }

        
    }
}
