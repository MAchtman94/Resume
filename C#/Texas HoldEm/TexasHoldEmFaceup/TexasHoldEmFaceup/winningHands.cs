using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldEmFaceup;



namespace TexasHoldEmFaceup
{
    class winningHands
    {



        // Chance function for AI ----> Never completely got them working properly

        public bool chance(Card[] computerHand, Card[] cardDeck)
        {

            double totalOdds = 0;
            double differentHands = 9;

            totalOdds += 3 * checkLikeValues(computerHand, cardDeck);   // For pair, three/four of a kind, you're still looking for cards of the same value, so my understanding 
                                                                        // is the odds are the same for each

            totalOdds += checkTwoPair(computerHand, cardDeck);
            totalOdds += checkFullHouse(computerHand, cardDeck);
            totalOdds += checkFlush(computerHand, cardDeck);
            totalOdds += checkStraight(computerHand, cardDeck);
            totalOdds += StraightFlush(computerHand, cardDeck);
            totalOdds += checkRoyalFlush(computerHand, cardDeck);

            totalOdds /= differentHands;                                // Average is taken of the odds

            if (totalOdds >= 50.0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // These two functions are unfinished; It was planned that they would operate similarly, but I wasn't able to figure them out
        public double checkTwoPair(Card[] computerHand, Card[] cardDeck)
        {


            // Using the same logic as the pair function, but havent figured it out at the moment
            double odds = 0.0;
            double wins = 0.0;
            double losers = 0.0;

            for (int outerIndex = 0; outerIndex < cardDeck.Length; outerIndex++)
            {
                for (int innerIndex = 0; innerIndex < computerHand.Length; innerIndex++)
                {
                    // Ensures the values are the same but NOT the suits, since that would mean they are they same card.
                    if (Convert.ToString(cardDeck[outerIndex].cardType) == Convert.ToString(computerHand[innerIndex].cardType) && (Convert.ToString(cardDeck[outerIndex].cardSuits) != Convert.ToString(computerHand[innerIndex].cardSuits)))
                    {
                        wins += 1.0;
                    }
                    else
                    {
                        losers += 1.0;
                    }
                }
            }
            odds = (wins / losers) * 100;
            return odds;

        }
        public double checkFullHouse(Card[] computerHand, Card[] cardDeck)
        {
            double wins = 0.0;
            double odds = 0.0;

            double cardsInDeck = 52.0;

            for (int outerIndex = 0; outerIndex < cardDeck.Length; outerIndex++)
            {
                for (int innerIndex = 0; innerIndex < computerHand.Length; innerIndex++)
                {
                    if ((cardDeck[outerIndex].cardSuits != computerHand[innerIndex].cardSuits) && cardDeck[outerIndex].cardType == cardDeck[innerIndex].cardType)
                    {
                        wins += 1.0;
                    }
                }

            }

            odds = (wins / cardsInDeck) * 100;
            return odds;
        }

        public double checkLikeValues(Card[] computerHand, Card[] cardDeck)
        {
            // One function for pair, three of a kind, and four of a kind since you're looking for cards with the same value for all three hands
            double odds = 0.0;
            double wins = 0.0;
            double cardsInDeck = 50.0;
            for (int outerIndex = 0; outerIndex < cardDeck.Length; outerIndex++)
            {
                for (int innerIndex = 0; innerIndex < computerHand.Length; innerIndex++)
                {
                    // Ensures the values are the same but NOT the suits, since that would mean they are they same card.
                    if ((cardDeck[outerIndex].cardType == computerHand[innerIndex].cardType) && (cardDeck[outerIndex].cardSuits != computerHand[innerIndex].cardSuits))
                    {
                        wins += 1.0;
                    }
                }
            }
            odds = (wins / cardsInDeck) * 100;
            return odds;
        }
        public double checkStraight(Card[] computerHand, Card[] cardDeck)
        {

            double wins = 0.0;
            double cardsInDeck = 50;
            double odds = 0.0;

            for (int index = 0; index < cardDeck.Length; index++)
            {
                if ((cardDeck[index] != computerHand[0]) && (cardDeck[index] != computerHand[1]))
                {
                    for (int innerIndex = 0; innerIndex < computerHand.Length; innerIndex++)
                    {
                        // For a straight, the min and max will at most have a difference of 4, 
                        // so the method checks for all cards that are within that range that would enable a straight in either direction
                        if (Math.Abs(cardDeck[index].cardType - computerHand[innerIndex].cardType) <= 4)
                        {
                            wins += 1.0;
                        }
                    }

                }
            }

            odds = (wins / cardsInDeck) * 100;

            return odds;

        }
        public double checkFlush(Card[] computerHand, Card[] cardDeck)
        {


            double odds = 0.0;
            double wins = 0.0;
            double cardsInDeck = 50.0;

            for (int outerIndex = 0; outerIndex < cardDeck.Length; outerIndex++)
            {
                for (int innerIndex = 0; innerIndex < computerHand.Length; innerIndex++)
                {
                    // Checks for suits, and ignores the the card if it's the same the player has in their hand
                    if (Convert.ToString(cardDeck[outerIndex].cardSuits) == Convert.ToString(computerHand[innerIndex].cardSuits) && (Convert.ToString(cardDeck[outerIndex].cardType) != Convert.ToString(computerHand[innerIndex].cardType)))
                    {
                        wins += 1.0;
                    }
                }
            }

            odds = (wins / cardsInDeck) * 100;



            return odds;
        }
        public double StraightFlush(Card[] computerHand, Card[] cardDeck)
        {


            double wins = 0.0;
            double cardsInDeck = 50;
            double odds = 0.0;

            for (int index = 0; index < cardDeck.Length; index++)
            {
                if ((cardDeck[index] != computerHand[0]) && (cardDeck[index] != computerHand[1]))
                {
                    for (int innerIndex = 0; innerIndex < computerHand.Length; innerIndex++)
                    {
                        // Combines the check for straight and flush: Same suit, and within range for a straight
                        if ((Math.Abs(cardDeck[index].cardType - computerHand[innerIndex].cardType) <= 4) && (cardDeck[index].cardSuits == computerHand[innerIndex].cardSuits && (cardDeck[index].cardType) != computerHand[innerIndex].cardType))

                        {
                            wins += 1.0;
                        }
                    }

                }
            }

            odds = (wins / cardsInDeck) * 100;

            return odds;
        }
        public double checkRoyalFlush(Card[] computerHand, Card[] cardDeck)
        {


            double wins = 0.0;
            double cardsInDeck = 50;
            double odds = 0.0;
            int deckMin = 10; // Lowest value in a royal flush

            for (int index = 0; index < cardDeck.Length; index++)
            {
                if ((cardDeck[index] != computerHand[0]) && (cardDeck[index] != computerHand[1]) && Convert.ToInt32(cardDeck[index].cardType) >= deckMin)
                {
                    for (int innerIndex = 0; innerIndex < computerHand.Length; innerIndex++)
                    {
                        if ((Math.Abs(cardDeck[index].cardType - computerHand[innerIndex].cardType) <= 4) && (cardDeck[index].cardSuits == computerHand[innerIndex].cardSuits && (cardDeck[index].cardType) != computerHand[innerIndex].cardType))

                        {
                            wins += 1.0;
                        }
                    }

                }
            }

            odds = (wins / cardsInDeck) * 100;

            return odds;

        }

    }
}
