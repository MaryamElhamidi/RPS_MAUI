using System;
using Microsoft.Maui.Controls;
using System.IO;

namespace RPSGame
{
    public partial class MainPage : ContentPage
    {
        private int playerScore;
        private int systemScore;

        public MainPage()
        {
            InitializeComponent();
            playerScore = 0;
            systemScore = 0;
            UpdateScoreLabels();
        }

        private void OnRockImageButtonClicked(object sender, EventArgs e)
        {
            PlayGame("rock");
        }

        private void OnPaperImageButtonClicked(object sender, EventArgs e)
        {
            PlayGame("paper");
        }

        private void OnScissorsImageButtonClicked(object sender, EventArgs e)
        {
            PlayGame("scissors");
        }

        private void PlayGame(string playerChoice)
        {
            string systemChoice = GetSystemChoice();
            string result = DetermineWinner(playerChoice, systemChoice);
            UpdateScoreLabels(result);
            UpdateImages(playerChoice, systemChoice);
        }

        private string GetSystemChoice()
        {
            Random random = new Random();
            int systemChoiceIndex = random.Next(0, 3);
            string[] choices = { "rock", "paper", "scissors" };
            return choices[systemChoiceIndex];
        }

        private string DetermineWinner(string playerChoice, string systemChoice)
        {
            if (playerChoice == systemChoice)
            {
                return "It's a tie!";
            }
            else if (
                (playerChoice == "rock" && systemChoice == "scissors") ||
                (playerChoice == "paper" && systemChoice == "rock") ||
                (playerChoice == "scissors" && systemChoice == "paper")
            )
            {
                return "Player wins!";
            }
            else
            {
                return "System wins!";
            }
        }

        private void UpdateScoreLabels(string result = "")
        {
            if (result == "Player wins!")
            {
                playerScore++;
            }
            else if (result == "System wins!")
            {
                systemScore++;
            }

            playerScoreLabel.Text = $"Player Score: {playerScore}";
            systemScoreLabel.Text = $"System Score: {systemScore}";
        }

        private void UpdateImages(string playerChoice, string systemChoice)
        {
            string playerImagePath = Path.Combine("Images", $"{playerChoice}_gesture.png");
            string systemImagePath = Path.Combine("Images", $"{systemChoice}_gesture.png");

            playerChoiceImage.Source = playerImagePath;
            systemChoiceImage.Source = systemImagePath;
        }

        private void OnNewGameButtonClicked(object sender, EventArgs e)
        {
            playerScore = 0;
            systemScore = 0;
            UpdateScoreLabels();
            playerChoiceImage.Source = "questionmark.png";
            systemChoiceImage.Source = "questionmark.png";
        }
    }
}