### ✊🖐✌ Rock Paper Scissors - MAUI Edition

This is a simple, interactive **Rock Paper Scissors** game built using **.NET MAUI**. Players can compete against the system in a fun animated match with gesture images, score tracking, and a clean UI experience.

---

### 🎮 Features

* 🧠 **Smart Opponent**: The system makes random moves each round.
* 🧾 **Score Tracking**: Tracks both player and system scores.
* 🏆 **Game End Logic**: First to 3 points wins the match.
* 🔁 **New Game Button**: Easily reset the game at any time.
* 💡 **Two-Win Streak Alert**: Detects when someone wins two matches in a row.

---

### 📱 Gameplay Overview

* Tap on one of the choices: Rock, Paper, or Scissors.
* The system will make a random choice and both gestures will be shown.
* Scores are updated automatically.
* The first to 3 points wins the match.
* "Play Again" lets you restart and play fresh.

---

### 🧠 How It Works

* `PlayRound(string playerChoice)`: Handles gesture images, system decision, win/loss logic, and score updates.
* `DeclareWinner()`: Shows a pop-up when someone reaches 3 points.
* `ResetGame()`: Resets game state for a new round.
* Score and image labels update in real-time on the UI.

---

### 📁 Files & Structure

```plaintext
RPSGame/
├── MainPage.xaml         # UI Layout (not shown here)
├── MainPage.xaml.cs      # Game logic and interaction handling
├── Resources/Images/
│   ├── rock_gesture.png
│   ├── paper_gesture.png
│   ├── scissors_gesture.png
│   └── question_mark.png
```

---

### 💡 Technologies

* **.NET MAUI** – Cross-platform app development
* **C#** – Backend game logic
* **XAML** – UI layout and binding

---

### 🚀 Getting Started

1. Clone the repository.
2. Open the solution in **Visual Studio 2022+** with MAUI installed.
3. Build and run on a supported Android/iOS/Windows emulator or device.
4. Tap and play!

---

### 🧠 Developer Notes

* Images update dynamically based on choices.
* Match ends automatically after either the player or system reaches 3.
* "Two Consecutive Wins" alert is triggered post-match for streak tracking.

---
