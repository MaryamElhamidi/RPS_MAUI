using System;
using Microsoft.Maui.Controls;

namespace RPSGame
{
    public partial class MainPage : ContentPage
    {
        int playerScore = 0;
        int systemScore = 0;
        int playerConsecutiveWins = 0;
        int systemConsecutiveWins = 0;
        bool isMatchOver = false;
        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        private void ChoiceRock(object sender, EventArgs e)
        {
            PlayRound("Rock");
        }

        private void ChoicePaper(object sender, EventArgs e)
        {
            PlayRound("Paper");
        }

        private void ChoiceScissors(object sender, EventArgs e)
        {
            PlayRound("Scissors");
        }

        private void PlayRound(string playerChoice)
        {
            // Show the corresponding picture for the player's choice
            playersChoiceImage.Source = $"{playerChoice.ToLower()}_gesture.png";

            // Use a random number generator to decide the choice of the computer
            int computerChoiceIndex = random.Next(1, 4);
            string[] choices = { "Rock", "Paper", "Scissors" };
            string computerChoice = choices[computerChoiceIndex - 1];

            // Show the computer's choice image and label
            systemChoiceImage.Source = $"{computerChoice.ToLower()}_gesture.png";
            systemChoiceLabel.Text = $"System's Choice: {computerChoice}";

            // Decide the winner of the round
            if (playerChoice == "Rock" && computerChoice == "Scissors")
            {
                // User wins with rock against scissors
                playerScore++;
            }
            else if (playerChoice == "Rock" && computerChoice == "Paper")
            {
                // User wins with paper against rock
                systemScore++;
            }
            else if (playerChoice == "Scissors" && computerChoice == "Paper")
            {
                // User wins with scissors against paper
                playerScore++;
            }
            else if (playerChoice == "Scissors" && computerChoice == "Rock")
            {
                // User wins with scissors against paper
                systemScore++;
            }
            else if (playerChoice == "Paper" && computerChoice == "Scissors")
            {
                // Computer wins with scissors against paper
                systemScore++;
            }
            else if (playerChoice == "Paper" && computerChoice == "Rock")
            {
                // Computer wins with scissors against paper
                playerScore++;
            }
            else
            {
                // It's a tie - no points are scored
            }

            // Update the score labels
            playerScoreLabel.Text = $"Player Score: {playerScore}";
            systemScoreLabel.Text = $"System Score: {systemScore}";

            // Check for consecutive wins
            if (playerScore == 3)
            {
                playerConsecutiveWins++;
            }
            else if (systemScore == 3)
            {
                systemConsecutiveWins++;
            }

            // Check if the game is over
            if (playerScore == 3 || systemScore == 3)
            {
                // Display the final winner using an alert
                DeclareWinner();

                // Disable ImageButtons
                rockButton.IsEnabled = false;
                paperButton.IsEnabled = false;
                scissorsButton.IsEnabled = false;

                // Enable the "New Game" button
                playButton.IsEnabled = true;

                // Set the match over flag
                isMatchOver = true;
            }
            else
            {
                // Enable the "New Game" button for the next round
                playButton.IsEnabled = true;

                // Reset consecutive wins if the match is not over
                playerConsecutiveWins = 0;
                systemConsecutiveWins = 0;
                isMatchOver = false;
            }

            // Check for consecutive wins after the match is over
            if (isMatchOver)
            {
                if (playerConsecutiveWins == 2 || systemConsecutiveWins == 2)
                {
                    DisplayAlert("Alert", "Match is over. Two Consecutive Wins.", "Ok");
                    isMatchOver = true;
                }
            }
        }

        private void DeclareWinner()
        {
            // Display the final winner using an alert
            string winner = (playerScore == 3) ? "Player" : "System";
            DisplayAlert("Game Over", $"{winner} wins the game!", "OK");

            // Set the match over flag
            isMatchOver = true;
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

            // Enable ImageButtons for the new game
            rockButton.IsEnabled = true;
            paperButton.IsEnabled = true;
            scissorsButton.IsEnabled = true;

            // Disable the "New Game" button
            playButton.IsEnabled = false;
        }

        private void PlayButtonHit(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}