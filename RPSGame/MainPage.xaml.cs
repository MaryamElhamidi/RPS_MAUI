using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace RPSGame
{
    public partial class MainPage : ContentPage
    {
        private int playerScore;
        private int systemScore;

        private void ChoiceRock(object sender, EventArgs e)
        {
            PlayRound("Rock");
        }

        private void choicePaper(object sender, EventArgs e)
        {
            PlayRound("Paper");
        }

        private void ChoiceScissors(object sender, EventArgs e)
        {
            PlayRound("Scissors");
        }

        private void playButtonHit(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void PlayRound(string playerChoice)
        {
            // Disable buttons during the round
            rockButton.IsEnabled = false;
            paperButton.IsEnabled = false;
            ScissorsButton.IsEnabled = false;

            // Show player's choice image
            playersChoiceImage.Source = $"{playerChoice.ToLower()}_gesture.png";

            // Use a random number generator to decide the choice of the computer
            Random random = new Random();
            int computerChoiceIndex = random.Next(1, 4);
            string[] choices = { "Rock", "Paper", "Scissors" };
            string computerChoice = choices[computerChoiceIndex - 1];

            // Show computer's choice image and label
            systemChoiceImage.Source = $"{computerChoice.ToLower()}_gesture.png";
            systemChoiceLabel.Text = $"System's Choice: {computerChoice}";

            // Decide the winner and update scores
            if (playerChoice == computerChoice)
            {
                // It's a tie
            }
            else if ((playerChoice == "Rock" && computerChoice == "Scissors") ||
                     (playerChoice == "Paper" && computerChoice == "Rock") ||
                     (playerChoice == "Scissors" && computerChoice == "Paper"))
            {
                // Player wins the round
                playerScore++;
                playerScoreLabel.Text = $"Player Score: {playerScore}";
            }
            else
            {
                // Computer wins the round
                systemScore++;
                systemScoreLabel.Text = $"System Score: {systemScore}";
            }

            // Check if the game is over
            if (playerScore == 3 || systemScore == 3)
            {
                DeclareWinner();
            }
            else
            {
                // Enable the "New Game" button for the next round
                playButton.IsEnabled = true;
            }
        }

        private void DeclareWinner()
        {
            // Display the final winner using an alert
            string winner = (playerScore == 3) ? "Player" : "System";
            DisplayAlert("Game Over", $"{winner} wins the game!", "OK");

            // Disable buttons and enable "New Game" button
            rockButton.IsEnabled = false;
            paperButton.IsEnabled = false;
            ScissorsButton.IsEnabled = false;
            playButton.IsEnabled = true;
        }

        private void ResetGame()
        {
            // Reset scores
            playerScore = 0;
            systemScore = 0;
            playerScoreLabel.Text = "Player Score: 0";
            systemScoreLabel.Text = "System Score: 0";

            // Reset images and labels
            playersChoiceImage.Source = "question_mark.png";
            systemChoiceImage.Source = "question_mark.png";
            systemChoiceLabel.Text = "System's Choice: ";

            // Enable buttons for the new game
            rockButton.IsEnabled = true;
            paperButton.IsEnabled = true;
            ScissorsButton.IsEnabled = true;
            playButton.IsEnabled = false;
        }
    }
}