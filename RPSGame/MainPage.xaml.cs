using System;
using Microsoft.Maui.Controls;

namespace RPSGame
{
    public partial class MainPage : ContentPage
    {
        private int playerScore = 0;
        private int systemScore = 0;
        private int consecutiveWins = 0; // Track consecutive wins
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
            if (playerChoice == "Rock" && computerChoice == "Scissors" ||
                playerChoice == "Scissors" && computerChoice == "Paper" ||
                playerChoice == "Paper" && computerChoice == "Rock")
            {
                // Player wins the round
                playerScore++;
                consecutiveWins++;
            }
            else if (playerChoice == "Rock" && computerChoice == "Paper" ||
                     playerChoice == "Scissors" && computerChoice == "Rock" ||
                     playerChoice == "Paper" && computerChoice == "Scissors")
            {
                // Computer wins the round
                systemScore++;
                consecutiveWins++;
            }
            else
            {
                // It's a tie - no points are scored
                consecutiveWins = 0;
            }

            // Update the score labels
            playerScoreLabel.Text = $"Player Score: {playerScore}";
            systemScoreLabel.Text = $"System Score: {systemScore}";

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
            else
            {
                // Enable the "New Game" button for the next round
                playButton.IsEnabled = true;

                // Check if there are two consecutive wins
                if (consecutiveWins == 2)
                {
                    DeclareMatchOver();
                }
            }
        }

        private void DeclareWinner()
        {
            // Display the final winner using an alert
            string winner = (playerScore == 3) ? "Player" : "System";
            DisplayAlert("Game Over", $"{winner} wins the game!", "OK");
        }

        private void DeclareMatchOver()
        {
            // Display match over message using an alert
            string winner = (playerScore == 3) ? "Player" : "System";
            DisplayAlert("Match Over", $"{winner} has won two consecutive times. Match is over!", "OK");

            // Disable all controls
            rockButton.IsEnabled = false;
            paperButton.IsEnabled = false;
            scissorsButton.IsEnabled = false;
            playButton.IsEnabled = false;
        }

        private void ResetGame()
        {
            // Reset scores and consecutive wins
            playerScore = 0;
            systemScore = 0;
            consecutiveWins = 0;
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
