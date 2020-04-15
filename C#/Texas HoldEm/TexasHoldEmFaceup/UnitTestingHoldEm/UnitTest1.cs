using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TexasHoldEmFaceup;
using static TexasHoldEmFaceup.TypesOfWinningHands;

namespace TexasHoldEmFaceupTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StraightFlush()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Three };
            var cardThree = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Four };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreEqual(winningHandValues.StraightFlush, playerHandCardWin);
        }

        [TestMethod]
        public void StraightFlushFalse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Three };
            var cardThree = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Four };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreNotEqual(winningHandValues.StraightFlush, playerHandCardWin);
        }

        [TestMethod]
        public void FourOfAKind()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Two };
            var cardThree = new Card { cardSuits = Card.CardSuits.Spades, cardType = Card.CardValues.Two };
            var cardFour = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Two };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreEqual(winningHandValues.FourOfAKind, playerHandCardWin);
        }

        [TestMethod]
        public void FourOFAKindFalse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Three };
            var cardThree = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Four };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreNotEqual(winningHandValues.FourOfAKind, playerHandCardWin);
        }

        [TestMethod]
        public void FullHouse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Two };
            var cardThree = new Card { cardSuits = Card.CardSuits.Spades, cardType = Card.CardValues.Two };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Five };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Six };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreEqual(winningHandValues.FullHouse, playerHandCardWin);
        }

        [TestMethod]
        public void FullHouseFalse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Three };
            var cardThree = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Four };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreNotEqual(winningHandValues.FullHouse, playerHandCardWin);
        }

        [TestMethod]
        public void Flush()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Jack };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Three };
            var cardThree = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Four };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreEqual(winningHandValues.Flush, playerHandCardWin);
        }

        [TestMethod]
        public void FlushFalse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Jack };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Three };
            var cardThree = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Four };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreNotEqual(winningHandValues.Flush, playerHandCardWin);
        }

        [TestMethod]
        public void Straight()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Three };
            var cardThree = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Four };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreEqual(winningHandValues.Straight, playerHandCardWin);
        }

        [TestMethod]
        public void StraightFalse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Jack };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Three };
            var cardThree = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Four };
            var cardFour = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Five };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreNotEqual(winningHandValues.Straight, playerHandCardWin);
        }

        [TestMethod]
        public void ThreeOfAKind()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Two };
            var cardThree = new Card { cardSuits = Card.CardSuits.Spades, cardType = Card.CardValues.Two };
            var cardFour = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Three };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreEqual(winningHandValues.ThreeOfAKind, playerHandCardWin);
        }

        [TestMethod]
        public void ThreeOfAKindFalse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Two };
            var cardThree = new Card { cardSuits = Card.CardSuits.Spades, cardType = Card.CardValues.Three };
            var cardFour = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Three };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreNotEqual(winningHandValues.ThreeOfAKind, playerHandCardWin);
        }

        [TestMethod]
        public void TwoPair()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Two };
            var cardThree = new Card { cardSuits = Card.CardSuits.Spades, cardType = Card.CardValues.Three };
            var cardFour = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Three };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreEqual(winningHandValues.TwoPair, playerHandCardWin);
        }

        [TestMethod]
        public void TwoPairFalse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Jack };
            var cardThree = new Card { cardSuits = Card.CardSuits.Spades, cardType = Card.CardValues.Three };
            var cardFour = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Three };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreNotEqual(winningHandValues.TwoPair, playerHandCardWin);
        }

        [TestMethod]
        public void Pair()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Jack };
            var cardThree = new Card { cardSuits = Card.CardSuits.Spades, cardType = Card.CardValues.Three };
            var cardFour = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Three };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreEqual(winningHandValues.Pair, playerHandCardWin);
        }

        [TestMethod]
        public void PairFalse()
        {
            //Arrange
            Card[] cardValues;
            cardValues = new Card[7];
            var cardOne = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Two };
            var cardTwo = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.Jack };
            var cardThree = new Card { cardSuits = Card.CardSuits.Spades, cardType = Card.CardValues.Three };
            var cardFour = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Queen };
            var cardFive = new Card { cardSuits = Card.CardSuits.Clubs, cardType = Card.CardValues.Six };
            var cardSix = new Card { cardSuits = Card.CardSuits.Hearts, cardType = Card.CardValues.King };
            var cardSeven = new Card { cardSuits = Card.CardSuits.Diamonds, cardType = Card.CardValues.Ace };

            cardValues[0] = cardOne;
            cardValues[1] = cardTwo;
            cardValues[2] = cardThree;
            cardValues[3] = cardFour;
            cardValues[4] = cardFive;
            cardValues[5] = cardSix;
            cardValues[6] = cardSeven;

            //Act
            TypesOfWinningHands typesOfWinningHands = new TypesOfWinningHands(cardValues);
            winningHandValues playerHandCardWin = typesOfWinningHands.evaluatedHand();
            //Assert
            Assert.AreNotEqual(winningHandValues.Pair, playerHandCardWin);
        }
    }
}
