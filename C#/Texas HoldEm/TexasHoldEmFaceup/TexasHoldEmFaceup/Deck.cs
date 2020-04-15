using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TexasHoldEmFaceup.TypesOfWinningHands;
using static TexasHoldEmFaceup.Card;

namespace TexasHoldEmFaceup
{
    //Call  me once turn is done.  Do not want to be referenced until current round is over
 
    class Deck  : IComparable<Deck>
    {
        public Card[] cardDeck; //List<Card> cardDeck = new List<Card>();
        //List<Card> cardFaces = new List<Card>();
        //List<Card> cardValues = new List<Card>();

        // Player and AI's hands, and table cards
        public Card[] playerHand;
        public Card[] computerHand;
        public Card[] tableCards;
        public Card[] sortedPlayerHand;
        public Card[] sortedComputerHand;

        Random randomCard;

        private const int NUMBER_OF_CARDS = 52;

        public int playerAmount { get; set; }
        public int computerAmount { get; set; }
        public int potAmount { get; set; }
        public bool isNewGame { get; set; }
        public int winningHand { get; set; }

        private const int cardsInHand = 2;
        private const int cardsOnTable = 5;
        private int currentCard { get; set; }

        
        public Deck()
        {
            this.currentCard = 0;
            randomCard = new Random();

            playerHand = new Card[cardsInHand];
            computerHand = new Card[cardsInHand];
            tableCards = new Card[cardsOnTable];

            sortedComputerHand = new Card[7];
            sortedPlayerHand = new Card[7];

            cardDeck = new Card[NUMBER_OF_CARDS];

            int indexValue = 0;
            foreach (CardSuits cardSuit in Enum.GetValues(typeof(CardSuits)))
            {
                foreach (CardValues cardAmounts in Enum.GetValues(typeof(CardValues)))
                {
                    cardDeck[indexValue] = new Card { cardSuits = cardSuit, cardType = cardAmounts };
                    indexValue++;
                }
            }
        }

        private Card[] sortPlayerHand()
        {
            sortedPlayerHand[0] = playerHand[0];
            sortedPlayerHand[1] = playerHand[1];
            sortedPlayerHand[2] = tableCards[0];
            sortedPlayerHand[3] = tableCards[1];
            sortedPlayerHand[4] = tableCards[2];
            sortedPlayerHand[5] = tableCards[3];
            sortedPlayerHand[6] = tableCards[4];

            //Sorting the array cardValues, this will help recognize winning hands easier
            //Found to use order by method from following link: https://mybroadband.co.za/forum/threads/sorting-an-array-of-objects-in-c-noob.803723/
            sortedPlayerHand = sortedPlayerHand.OrderBy(thisCard => thisCard.cardType).ToArray();

            return sortedPlayerHand;
        }

        private Card[] sortComputerHand()
        {
            sortedComputerHand[0] = computerHand[0];
            sortedComputerHand[1] = computerHand[1];
            sortedComputerHand[2] = tableCards[0];
            sortedComputerHand[3] = tableCards[1];
            sortedComputerHand[4] = tableCards[2];
            sortedComputerHand[5] = tableCards[3];
            sortedComputerHand[6] = tableCards[4];

            //Sorting the array cardValues, this will help recognize winning hands easier
            //Found to use order by method from following link: https://mybroadband.co.za/forum/threads/sorting-an-array-of-objects-in-c-noob.803723/
            sortedComputerHand = sortedComputerHand.OrderBy(thisCard => thisCard.cardType).ToArray();

            return sortedComputerHand;
        }

        private void shuffleCard()
        {
            //currentCard = 0;
            for (int firstCard = 0; firstCard < NUMBER_OF_CARDS; firstCard++)
            {
                int secondCard = randomCard.Next(13);
                Card tempCard = cardDeck[firstCard];
                cardDeck[firstCard] = cardDeck[secondCard];
                cardDeck[secondCard] = tempCard;
            }
        }

        public void gameStart()
        {
            controlAmount();

            shuffleCard();

            playerHand[0] = DealCard();
            playerHand[1] = DealCard();

            computerHand[0] = DealCard();

            //Getting index out fo bounds error when referencing computerHand[2]
            computerHand[1] = DealCard();

            for (int index = 0; index < 5; index++)
            {
                tableCards[index] = DealCard();
            }

            sortPlayerHand();
            sortComputerHand();
        }

        //Only giving out one card at a time
        public Card DealCard()
        {
            if (currentCard < cardDeck.Length)
            {
                return cardDeck[currentCard++];
            }
            else
            {
                return null;
            }
        }

        private void controlAmount()
        {
            playerAmount = playerAmount - 10;
            computerAmount = computerAmount - 10;
            potAmount = 20;
        }

        public void evaluateHands()
        {
            if(winningHand == 1)
            {
                playerAmount = playerAmount + potAmount;
                potAmount = 0;
            }
            else if (winningHand == -1)
            {
                computerAmount = computerAmount + potAmount;
                potAmount = 0;
            }
            else
            {
                computerAmount += potAmount / 2;
                playerAmount += potAmount / 2;
                potAmount = 0;
            }
        }

        public int CompareTo(Deck otherHand)
        {
            TypesOfWinningHands playerHands = new TypesOfWinningHands(sortedPlayerHand);
            TypesOfWinningHands computerHands = new TypesOfWinningHands(sortedComputerHand);

            //looking at a winning hand
            winningHandValues playerHandCardWin = playerHands.evaluatedHand();
            winningHandValues computerHandCardWin = computerHands.evaluatedHand();

            if (playerHandCardWin > computerHandCardWin)
            {
                return winningHand = 1;
            }
            else if (playerHandCardWin < computerHandCardWin)
            {
                return winningHand = -1;
            }
            else
            {
                if (playerHand[1].cardType > computerHand[1].cardType)
                {
                    return winningHand = 1;
                }
                else if (playerHand[1].cardType < computerHand[1].cardType)
                {
                    return winningHand = -1;
                }
                else
                {
                    return winningHand = 0;
                }
            }
        }

       
    }
}
