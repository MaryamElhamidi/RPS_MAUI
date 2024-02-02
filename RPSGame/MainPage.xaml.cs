using System;
using Microsoft.Maui.Controls;

namespace RPSGame
{
    public partial class MainPage : ContentPage
    {
        private int playerScore = 0;
        private int systemScore = 0;
        private Random random = new Random();

        public MainPage()
        {
            InitializeComponent();

            // Attach event handlers
            rockButton.Clicked += ChoiceRock;
            paperButton.Clicked += ChoicePaper;
            scissorsButton.Clicked += ChoiceScissors;
            playButton.Clicked += PlayButtonHit;
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

                // Disable ImageButtons
                rockButton.IsEnabled = false;
                paperButton.IsEnabled = false;
                scissorsButton.IsEnabled = false;

                // Enable the "New Game" button
                playButton.IsEnabled = true;
            }
        }

        private void DeclareWinner()
        {
            // Display the final winner using an alert
            string winner = (playerScore == 3) ? "Player" : "System";
            DisplayAlert("Game Over", $"{winner} wins the game!", "OK");
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
