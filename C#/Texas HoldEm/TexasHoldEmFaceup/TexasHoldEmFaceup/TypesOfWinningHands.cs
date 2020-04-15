using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEmFaceup
{
    //Class is used to reference winning hand options.  Would take in the deck class and reference the card values of both player / computer hand and table
    //Each winning hand will have its own method with a switch statement to signify what the user's best hand option is
    public class TypesOfWinningHands
    {
        public enum winningHandValues { HighCard, Pair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush}

        public int winningHand { get; private set; }
        public int totalHand { get; set; }
        public int highCard { get; set; }
        public int highCardComputer { get; set; }
        private int heartSumPlayer;
        private int diamondSumPlayer;
        private int clubSumPlayer;
        private int spadesSumPlayer;
        private Deck deckClass;
        private Card[] cardValues;

        public TypesOfWinningHands(Card[] sortedHands)
        {
            this.winningHand = 0;
            this.highCard = 0;
            this.highCardComputer = 0;
            this.heartSumPlayer = 0;
            this.spadesSumPlayer = 0;
            this.diamondSumPlayer = 0;
            this.clubSumPlayer = 0;
            cardValues = sortedHands;
        }

        //Count suits when looking at Player hand and table
        private void getNumbersOfSuitsInHand()
        {
            foreach (var element in cardValues)
            {
                if (element.cardSuits == Card.CardSuits.Diamonds)
                {
                    diamondSumPlayer++;
                }
                else if (element.cardSuits == Card.CardSuits.Spades)
                {
                    spadesSumPlayer++;
                }
                else if (element.cardSuits == Card.CardSuits.Hearts)
                {
                    heartSumPlayer++;
                }
                else if (element.cardSuits == Card.CardSuits.Clubs)
                {
                    clubSumPlayer++;
                }
            }
        }

        public winningHandValues evaluatedHand()
        {
            //Get number of player hand suits
            getNumbersOfSuitsInHand();
            if (StraightFlush())
            {
                return winningHandValues.StraightFlush;
            }
            else if (FourOfAKind())
            {
                return winningHandValues.FourOfAKind;
            }
            else if (FullHouse())
            {
                return winningHandValues.FullHouse;
            }
            else if (Flush())
            {
                return winningHandValues.Flush;
            }
            else if (Straight())
            {
                return winningHandValues.Straight;
            }
            else if (ThreeOfAKind())
            {
                return winningHandValues.ThreeOfAKind;
            }
            else if (TwoPair())
            {
                return winningHandValues.TwoPair;
            }
            else if (Pair())
            {
                return winningHandValues.Pair;
            }
            return winningHandValues.HighCard;
        }

        private bool StraightFlush()
        {
            if (Flush() == true && Straight() == true)
            {
                return true;
            }
            return false;
        }

        private bool FourOfAKind()
        {
            //Looking at two cards in hand and first two cards in table
            if (cardValues[0].cardType == cardValues[1].cardType && cardValues[0].cardType == cardValues[2].cardType && cardValues[0].cardType == cardValues[3].cardType)
            {
                //Calculate the hand total
                totalHand = (int)cardValues[1].cardType * 4;
                return true;
            }
            else if (cardValues[1].cardType == cardValues[2].cardType && cardValues[1].cardType == cardValues[3].cardType && cardValues[1].cardType == cardValues[4].cardType)
            {
                //Calculate the hand total
                totalHand = (int)cardValues[1].cardType * 4;
                return true;
            }
            return false;
        }

        private bool FullHouse()
        {
            //Look at three cards first (two player hand cards and table cards on table accordingly)
            if ((cardValues[0].cardType == cardValues[1].cardType && cardValues[0].cardType == cardValues[2].cardType && cardValues[3].cardType == cardValues[4].cardType)
                || (cardValues[0].cardType == cardValues[1].cardType && cardValues[0] == cardValues[3] && cardValues[4] == cardValues[5]))
            {
                if (cardValues[0].cardType == cardValues[1].cardType && cardValues[2].cardType == cardValues[3].cardType && cardValues[2].cardType == cardValues[4].cardType)
                {
                    //I want the total to determine who has the greater full house
                    totalHand = (int)cardValues[0].cardType + (int)cardValues[1].cardType + (int)cardValues[2].cardType + (int)cardValues[3].cardType + (int)cardValues[4].cardType;
                }
                else
                {
                    //I want the total to determine who has the greater full house
                    totalHand = (int)cardValues[0].cardType + (int)cardValues[1].cardType + (int)cardValues[3].cardType + (int)cardValues[4].cardType + (int)cardValues[5].cardType;
                }
                return true;
            }
            //Look at two cards first (two player hand cards and table cards on table accordingly)
            else if ((cardValues[0].cardType == cardValues[1].cardType && cardValues[2].cardType == cardValues[3].cardType && cardValues[2].cardType == cardValues[4].cardType)
                || (cardValues[0].cardType == cardValues[1].cardType && cardValues[3].cardType == cardValues[4].cardType && cardValues[3].cardType == cardValues[5].cardType))
            {
                if (cardValues[0].cardType == cardValues[1].cardType && cardValues[3].cardType == cardValues[4].cardType && cardValues[3].cardType == cardValues[5].cardType)
                {
                    //I want the total to determine who has the greater full house
                    totalHand = (int)cardValues[0].cardType + (int)cardValues[1].cardType + (int)cardValues[3].cardType + (int)cardValues[4].cardType + (int)cardValues[5].cardType;
                }
                else
                {
                    //I want the total to determine who has the greater full house
                    totalHand = (int)cardValues[0].cardType + (int)cardValues[1].cardType + (int)cardValues[2].cardType + (int)cardValues[3].cardType + (int)cardValues[4].cardType;
                }
                return true;

            }
            return false;
        }

        private bool Flush()
        {
            if (heartSumPlayer >= 5 || diamondSumPlayer >= 5 || clubSumPlayer >= 5 || spadesSumPlayer >= 5)
            {
                return true;
            }

            return false;
        }

        private bool Straight()
        {
            //Looking for 5 cards in ascending length
            if ((cardValues[0].cardType + 1 == cardValues[1].cardType && cardValues[1].cardType + 1 == cardValues[2].cardType
                && cardValues[2].cardType + 1 == cardValues[3].cardType && cardValues[3].cardType + 1 == cardValues[4].cardType
                && cardValues[4].cardType + 1 == cardValues[5].cardType) || (cardValues[1].cardType + 1 == cardValues[2].cardType && cardValues[2].cardType + 1 == cardValues[3].cardType
                && cardValues[3].cardType + 1 == cardValues[4].cardType && cardValues[4].cardType + 1 == cardValues[5].cardType
                && cardValues[5].cardType + 1 == cardValues[6].cardType))
            {
                return true;
            }
            return false;
        }

        private bool ThreeOfAKind()
        {
            //Looking at first three cards
            if (cardValues[0].cardType == cardValues[1].cardType && cardValues[0].cardType == cardValues[2].cardType)
            {
                totalHand = (int)cardValues[0].cardType * 3;
                return true;
            }
            //Looking at cards 2-4
            else if (cardValues[1].cardType == cardValues[2].cardType && cardValues[1].cardType == cardValues[3].cardType)
            {
                totalHand = (int)cardValues[1].cardType * 3;
                return true;
            }

            //Looking at cards 3-5
            else if (cardValues[2].cardType == cardValues[3].cardType && cardValues[2].cardType == cardValues[4].cardType)
            {
                totalHand = (int)cardValues[2].cardType * 3;
                return true;
            }

            //Looking at cards 4-6
            else if (cardValues[3].cardType == cardValues[4].cardType && cardValues[3].cardType == cardValues[5].cardType)
            {
                totalHand = (int)cardValues[3].cardType * 3;
                return true;
            }

            //Looking at cards 5-7
            else if (cardValues[4].cardType == cardValues[5].cardType && cardValues[5].cardType == cardValues[6].cardType)
            {
                totalHand = (int)cardValues[4].cardType * 3;
                return true;
            }

            return false;
        }

        private bool TwoPair()
        {
            //If card 1 equals card 2 AND card 3 equals card 4
            if (cardValues[0].cardType == cardValues[1].cardType && cardValues[2].cardType == cardValues[3].cardType)
            {
                totalHand = ((int)cardValues[1].cardType * 2) + ((int)cardValues[2].cardType * 2);
                return true;
            }
            //If card 1 equals card 2 AND card 4 equals card 5
            else if (cardValues[0].cardType == cardValues[1].cardType && cardValues[3].cardType == cardValues[4].cardType)
            {
                totalHand = ((int)cardValues[1].cardType * 2) + ((int)cardValues[3].cardType * 2);
                return true;
            }
            //If card 1 equals card 2 AND card 5 equals card 6
            else if (cardValues[0].cardType == cardValues[1].cardType && cardValues[4].cardType == cardValues[5].cardType)
            {
                totalHand = ((int)cardValues[1].cardType * 2) + ((int)cardValues[4].cardType * 2);
                return true;
            }
            //If card 1 equals card 2 AND card 6 equals card 7
            else if (cardValues[0].cardType == cardValues[1].cardType && cardValues[5].cardType == cardValues[6].cardType)
            {
                totalHand = ((int)cardValues[1].cardType * 2) + ((int)cardValues[5].cardType * 2);
                return true;
            }
            //If card 2 equals card 3 AND card 4 equals card 5
            else if (cardValues[1].cardType == cardValues[2].cardType && cardValues[3].cardType == cardValues[4].cardType)
            {
                totalHand = ((int)cardValues[2].cardType * 2) + ((int)cardValues[3].cardType * 2);
                return true;
            }
            //If card 2 equals card 3 AND card 5 equals card 6
            else if (cardValues[1].cardType == cardValues[2].cardType && cardValues[4].cardType == cardValues[5].cardType)
            {
                totalHand = ((int)cardValues[2].cardType * 2) + ((int)cardValues[4].cardType * 2);
                return true;
            }
            //If card 2 equals card 3 AND card 6 equals card 7
            else if (cardValues[1].cardType == cardValues[2].cardType && cardValues[5].cardType == cardValues[6].cardType)
            {
                totalHand = ((int)cardValues[2].cardType * 2) + ((int)cardValues[5].cardType * 2);
                return true;
            }
            //If card 3 equals card 4 AND card 5 equals card 6
            else if (cardValues[2].cardType == cardValues[3].cardType && cardValues[4].cardType == cardValues[5].cardType)
            {
                totalHand = ((int)cardValues[2].cardType * 2) + ((int)cardValues[4].cardType * 2);
                return true;
            }
            //If card 3 equals card 4 AND card 6 equals card 7
            else if (cardValues[2].cardType == cardValues[3].cardType && cardValues[5].cardType == cardValues[6].cardType)
            {
                totalHand = ((int)cardValues[2].cardType * 2) + ((int)cardValues[5].cardType * 2);
                return true;
            }
            //If card 4 equals card 5 AND card 6 equals card 7
            else if (cardValues[3].cardType == cardValues[4].cardType && cardValues[5].cardType == cardValues[6].cardType)
            {
                totalHand = ((int)cardValues[3].cardType * 2) + ((int)cardValues[5].cardType * 2);
                return true;
            }

            return false;
        }

        private bool Pair()
        {
            //If card 1 equals to card 2
            if (cardValues[0].cardType == cardValues[1].cardType)
            {
                totalHand = (int)cardValues[0].cardType * 2;
                return true;
            }
            //If Card 2 equals to card 3
            if (cardValues[1].cardType == cardValues[2].cardType)
            {
                totalHand = (int)cardValues[1].cardType * 2;
                return true;
            }
            //If Card 3 equals to card 4
            if (cardValues[2].cardType == cardValues[3].cardType)
            {
                totalHand = (int)cardValues[2].cardType * 2;
                return true;
            }
            //If Card 4 equals to card 5
            if (cardValues[3].cardType == cardValues[4].cardType)
            {
                totalHand = (int)cardValues[3].cardType * 2;
                return true;
            }
            //If Card 5 equals to card 6
            if (cardValues[4].cardType == cardValues[5].cardType)
            {
                totalHand = (int)cardValues[4].cardType * 2;
                return true;
            }
            //If Card 6 equals to card 7
            if (cardValues[5].cardType == cardValues[6].cardType)
            {
                totalHand = (int)cardValues[5].cardType * 2;
                return true;
            }

            return false;
        }
    }
}
