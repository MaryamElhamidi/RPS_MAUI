using System;
using System.IO;
using Xamarin;

namespace RPSGame
{
    public partial class MainPage : ContentPage
    {
        private int playerScore;
        private int systemScore;
        private Random random;

        public MainPage()
        {
            InitializeComponent();
            random = new Random();
            playerScore = 0;
            systemScore = 0;
            UpdateScoreLabels();
            playButton.IsEnabled = true;
        }

        private void UpdateScoreLabels()
        {
            playerScoreLabel.Text = $"Player Score: {playerScore}";
            systemScoreLabel.Text = $"System Score: {systemScore}";
        }

        private void ChoiceRock()
        {
            PlayGame("rock");
        }

        private void ChoicePaper()
        {
            PlayGame("paper");
        }

        private void ChoiceScissors()
        {
            PlayGame("scissors");
        }

        private void PlayGame(string playerChoice)
        {
            string systemChoice = GetSystemChoice();
            systemChoiceLabel.Text = $"System's Choice: {systemChoice}";
            ImageSource playerImageSource = GetImageSource(playerChoice);
            ImageSource systemImageSource = GetImageSource(systemChoice);
            playersChoiceImage.Source = playerImageSource;
            systemChoiceImage.Source = systemImageSource;
            int result = GetResult(playerChoice, systemChoice);
            UpdateScore(result);
            playButton.IsEnabled = true;
        }

        private string GetSystemChoice()
        {
            int randomNumber = random.Next(1, 4);
            switch (randomNumber)
            {
                case 1:
                    return "rock";
                case 2:
                    return "paper";
                default:
                    return "scissors";
            }
        }

        private ImageSource GetImageSource(string choice)
        {
            return ImageSource.FromResource($"RPSGame.Images.{choice}_gesture.png", typeof(MainPage).Assembly);
        }

        private int GetResult(string playerChoice, string systemChoice)
        {
            if (playerChoice == systemChoice)
            {
                return 0; // Draw
            }
            else if (
                (playerChoice == "rock" && systemChoice == "scissors") ||
                (playerChoice == "paper" && systemChoice == "rock") ||
                (playerChoice == "scissors" && systemChoice == "paper")
            )
            {
                return 1; // Player wins
            }
            else
            {
                return -1; // System wins
            }
        }

        private void UpdateScore(int result)
        {
            if (result == 1)
            {
                playerScore++;
            }
            else if (result == -1)
            {
                systemScore++;
            }
            UpdateScoreLabels();
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            playerScore = 0;
            systemScore = 0;
            UpdateScoreLabels();
            rockButton.IsEnabled = true;
            paperButton.IsEnabled = true;
            scissorsButton.IsEnabled = true;
            playButton.IsEnabled = false;
        }
    }
}