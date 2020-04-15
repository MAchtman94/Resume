using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TexasHoldEmFaceup.Deck;
using static TexasHoldEmFaceup.Card;
namespace TexasHoldEmFaceup
{
    public partial class Form1 : Form
    {
        Deck deckClass;
        winningHands winningHandsClass;
        public Form1()
        {
            InitializeComponent();
            deckClass = new Deck();
            winningHandsClass = new winningHands();
            nextHandButton.Enabled = false;
            deckClass.playerAmount = 100;
            deckClass.computerAmount = 100;
            deckClass.gameStart();
            populateCards();
            textBoxPlayerAmount.Text = deckClass.playerAmount.ToString();
            textBoxComputerAmount.Text = deckClass.computerAmount.ToString();
            textBoxPot.Text = deckClass.potAmount.ToString();
        }

        private void raiseButton_Click(object sender, EventArgs e)
        {
            //Decreasing playerAmount by 10 here and updating the text field
            deckClass.playerAmount = deckClass.playerAmount - 10;
            textBoxPlayerAmount.Text = deckClass.playerAmount.ToString();
            //Update conditional statement with returning true value for computer (probability is greater than or equal to 50%)
            if (winningHandsClass.chance(deckClass.sortedPlayerHand, deckClass.sortedComputerHand) == true)
            {
                //Updating computer and pot amount fields accordingly
                deckClass.computerAmount = deckClass.computerAmount - 10;
                textBoxComputerAmount.Text = deckClass.computerAmount.ToString();
                deckClass.potAmount = deckClass.potAmount + 20;
                textBoxPot.Text = deckClass.potAmount.ToString();

                //Using Compare method where our two hands will be compared with the Types Of Winning Hands
                deckClass.CompareTo(deckClass);
                deckClass.evaluateHands();
                //Updating text box fields according to winning hand
                textBoxPlayerAmount.Text = deckClass.playerAmount.ToString();
                textBoxComputerAmount.Text = deckClass.computerAmount.ToString();
                textBoxPot.Text = deckClass.potAmount.ToString();
                //Next hand button is now enabled since it is end of turn
                nextHandButton.Enabled = true;
                //Setting this button to false if it is used, this is to prevent a card evaluation to be called without new cards handed out
                buttonCheck.Enabled = false;
                raiseButton.Enabled = false;
                foldButton.Enabled = false;
                //Use this at end of hand
                determineWinner();
            }
            else
            {
                //Player wins automatically
                deckClass.potAmount = deckClass.potAmount + 10;
                deckClass.playerAmount = deckClass.playerAmount + deckClass.potAmount;
                textBoxPlayerAmount.Text = deckClass.playerAmount.ToString();
                //Hard coding to 0 to reset the pot amount
                deckClass.potAmount = 0;
                textBoxPot.Text = deckClass.potAmount.ToString();
                //Next hand button is now enabled since it is end of turn
                nextHandButton.Enabled = true;
                //Setting this button to false if it is used, this is to prevent a card evaluation to be called without new cards handed out
                buttonCheck.Enabled = false;
                raiseButton.Enabled = false;
                foldButton.Enabled = false;
            }
        }

        private void nextHandButton_Click(object sender, EventArgs e)
        {
            //Create new instance of deck class since it is a new hand
            deckClass = new Deck();
            //Store player and computer amount values here and use the values currently in the text box for next hand
            deckClass.playerAmount = Convert.ToInt32(textBoxPlayerAmount.Text);
            deckClass.computerAmount = Convert.ToInt32(textBoxComputerAmount.Text);
            //We are dealing cards and taking initial bets here
            deckClass.gameStart();
            populateCards();
            //Update the three text boxes from game start method
            textBoxPlayerAmount.Text = deckClass.playerAmount.ToString();
            textBoxComputerAmount.Text = deckClass.computerAmount.ToString();
            textBoxPot.Text = deckClass.potAmount.ToString();
            //Enabling all 3 buttons once a new hand is started so user can either fold, call, or raise current hand
            buttonCheck.Enabled = true;
            raiseButton.Enabled = true;
            foldButton.Enabled = true;
            //Prevent a new hand from starting until current hand is done
            nextHandButton.Enabled = false;
            //Prevent raise button from being enabled if computer or player hand is less than or equal to 0
            //Think of this as "final hand"
            if (deckClass.playerAmount <= 0 || deckClass.computerAmount <= 0)
            {
                raiseButton.Enabled = false;
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            //Using Compare method where our two hands will be compared with the Types Of Winning Hands
            deckClass.CompareTo(deckClass);
            deckClass.evaluateHands();
            //Updating text box fields according to winning hand
            textBoxPlayerAmount.Text = deckClass.playerAmount.ToString();
            textBoxComputerAmount.Text = deckClass.computerAmount.ToString();
            textBoxPot.Text = deckClass.potAmount.ToString();
            //Next hand button is now enabled since it is end of turn
            nextHandButton.Enabled = true;
            //Setting this button to false if it is used, this is to prevent a card evaluation to be called without new cards handed out
            buttonCheck.Enabled = false;
            raiseButton.Enabled = false;
            foldButton.Enabled = false;
            //Use this at end of hand
            determineWinner();
        }

        //Method will only be true if either hand is set to 0
        private void determineWinner()
        {
            if (deckClass.playerAmount <= 0)
            {
                labelWinner.Text = "Computer Wins";
                buttonCheck.Enabled = false;
                nextHandButton.Enabled = false;
            }
            else if (deckClass.computerAmount <= 0)
            {
                labelWinner.Text = "Player Wins";
                buttonCheck.Enabled = false;
                nextHandButton.Enabled = false;
            }
        }
        // The following image functions were based off of the code found from
        // https://stackoverflow.com/questions/8292710/c-sharp-winforms-drawimage-without-losing-animation
        void tableCardOneFace()
        {
            

            string cardValue = string.Empty;


            pictureBox1.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox1.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.tableCards[0].cardType);

            
                      if (Convert.ToString(deckClass.tableCards[0].cardSuits) == "Hearts")
                      {

                          if (cardValue == "Ace")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                          }

                          else if (cardValue == "Two")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }

                          else if (cardValue == "Three")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Four")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Five")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Six")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Seven")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Eight")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Nine")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Ten")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Jack")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Queen")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "King")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }


                      }


                      else if (Convert.ToString(deckClass.tableCards[0].cardSuits) == "Clubs")
                      {
                          if (cardValue == "Ace")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Two")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Three")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Four")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Five")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Six")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Seven")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Eight")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Nine")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Ten")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Jack")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Queen")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "King")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                      }
                      
                      else if (Convert.ToString(deckClass.tableCards[0].cardSuits) == "Spades")
                      {
                          if (cardValue == "Ace")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394/4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Two")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394/4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Three")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Four")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Five")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Six")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Seven")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Eight")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Nine")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Ten")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Jack")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "Queen")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }
                          else if (cardValue == "King")
                          {
                              cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                          }

                      }
                      
                      else if (Convert.ToString(deckClass.tableCards[0].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }
   


            pictureBox1.Refresh();
        }
        void tableCardTwoFace()
        {

            string cardValue = string.Empty;


            pictureBox2.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox2.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.tableCards[1].cardType);


            if (Convert.ToString(deckClass.tableCards[1].cardSuits) == "Hearts")
            {

                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                }

                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }


            }


            else if (Convert.ToString(deckClass.tableCards[1].cardSuits) == "Clubs")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
            }

            else if (Convert.ToString(deckClass.tableCards[1].cardSuits) == "Spades")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }

            else if (Convert.ToString(deckClass.tableCards[1].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }



            pictureBox2.Refresh();
        }
        void tableCardThreeFace()
        {

            string cardValue = string.Empty;


            pictureBox3.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox3.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.tableCards[2].cardType);


            if (Convert.ToString(deckClass.tableCards[2].cardSuits) == "Hearts")
            {

                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                }

                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }


            }


            else if (Convert.ToString(deckClass.tableCards[2].cardSuits) == "Clubs")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
            }

            else if (Convert.ToString(deckClass.tableCards[2].cardSuits) == "Spades")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }

            else if (Convert.ToString(deckClass.tableCards[2].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }



            pictureBox3.Refresh();
        }
        void TableCardFourFace()
        {

            string cardValue = string.Empty;


            pictureBox4.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox4.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.tableCards[3].cardType);


            if (Convert.ToString(deckClass.tableCards[3].cardSuits) == "Hearts")
            {

                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                }

                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }


            }


            else if (Convert.ToString(deckClass.tableCards[3].cardSuits) == "Clubs")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
            }

            else if (Convert.ToString(deckClass.tableCards[3].cardSuits) == "Spades")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }

            else if (Convert.ToString(deckClass.tableCards[3].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }



            pictureBox4.Refresh();
        }
        void TableCardFiveFace()
        {

            string cardValue = string.Empty;


            pictureBox5.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox5.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.tableCards[4].cardType);


            if (Convert.ToString(deckClass.tableCards[4].cardSuits) == "Hearts")
            {

                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                }

                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }


            }


            else if (Convert.ToString(deckClass.tableCards[4].cardSuits) == "Clubs")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
            }

            else if (Convert.ToString(deckClass.tableCards[4].cardSuits) == "Spades")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }

            else if (Convert.ToString(deckClass.tableCards[4].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }



            pictureBox5.Refresh();
        }

        void computerCardOneFace()
        {

            string cardValue = string.Empty;


            pictureBox6.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox6.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.computerHand[0].cardType);


            if (Convert.ToString(deckClass.computerHand[0].cardSuits) == "Hearts")
            {

                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                }

                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }


            }


            else if (Convert.ToString(deckClass.computerHand[0].cardSuits) == "Clubs")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
            }

            else if (Convert.ToString(deckClass.computerHand[0].cardSuits) == "Spades")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }

            else if (Convert.ToString(deckClass.computerHand[0].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }



            pictureBox6.Refresh();
        }
        void computerCardTwoFace()
        {

            string cardValue = string.Empty;


            pictureBox7.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox7.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.computerHand[1].cardType);


            if (Convert.ToString(deckClass.computerHand[1].cardSuits) == "Hearts")
            {

                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                }

                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }


            }


            else if (Convert.ToString(deckClass.computerHand[1].cardSuits) == "Clubs")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
            }

            else if (Convert.ToString(deckClass.computerHand[1].cardSuits) == "Spades")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }

            else if (Convert.ToString(deckClass.computerHand[1].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }



            pictureBox7.Refresh();
        }

        void playerCardOneFace()
        {

            string cardValue = string.Empty;


            pictureBox8.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox8.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.playerHand[0].cardType);


            if (Convert.ToString(deckClass.playerHand[0].cardSuits) == "Hearts")
            {

                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                }

                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }


            }


            else if (Convert.ToString(deckClass.playerHand[0].cardSuits) == "Clubs")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
            }

            else if (Convert.ToString(deckClass.playerHand[0].cardSuits) == "Spades")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }

            else if (Convert.ToString(deckClass.playerHand[0].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }



            pictureBox8.Refresh();
        }
        void playerCardTwoFace()
        {

            string cardValue = string.Empty;


            pictureBox9.Image = new Bitmap(951 / 13, 394 / 4);
            Graphics cardOne = Graphics.FromImage(pictureBox9.Image);
            Image image = Properties.Resources.cards;



            cardValue = Convert.ToString(deckClass.playerHand[1].cardType);


            if (Convert.ToString(deckClass.playerHand[1].cardSuits) == "Hearts")
            {

                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);

                }

                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 4, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 4, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }


            }


            else if (Convert.ToString(deckClass.playerHand[1].cardSuits) == "Clubs")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 0, (951 / 13), (394 / 4)), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 0, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
            }

            else if (Convert.ToString(deckClass.playerHand[1].cardSuits) == "Spades")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 394 / 2, (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }

            else if (Convert.ToString(deckClass.playerHand[1].cardSuits) == "Diamonds")
            {
                if (cardValue == "Ace")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(0, 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Two")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle((951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Three")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(2 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Four")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(3 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Five")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(4 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Six")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(5 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Seven")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(6 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Eight")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(7 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Nine")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(8 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Ten")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(9 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Jack")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(10 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "Queen")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(11 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }
                else if (cardValue == "King")
                {
                    cardOne.DrawImage(image, new Rectangle(0, 0, 951 / 13, 394 / 4), new Rectangle(12 * (951 / 13), 3 * (394 / 4), (951 / 13), 394 / 4), GraphicsUnit.Pixel);
                }

            }



            pictureBox9.Refresh();
        }
        private void foldButton_Click(object sender, EventArgs e)
        {
            //Computer wins automatically
            deckClass.computerAmount = deckClass.computerAmount + deckClass.potAmount;
            textBoxComputerAmount.Text = deckClass.computerAmount.ToString();
            //Hard coding to 0 to reset the pot amount
            deckClass.potAmount = 0;
            textBoxPot.Text = deckClass.potAmount.ToString();
            //Next hand button is now enabled since it is end of turn
            nextHandButton.Enabled = true;
            //Setting this button to false if it is used, this is to prevent a card evaluation to be called without new cards handed out
            buttonCheck.Enabled = false;
            raiseButton.Enabled = false;
            foldButton.Enabled = false;
        }

        private void populateCards()
        {
            tableCardOneFace();
            tableCardTwoFace();
            tableCardThreeFace();
            TableCardFourFace();
            TableCardFiveFace();

            computerCardOneFace();
            computerCardTwoFace();

            playerCardOneFace();
            playerCardTwoFace();
        }
    }
}
