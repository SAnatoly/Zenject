using UnityEngine;

namespace ShootEmUp
{
    public class GameCooldownLauncher
    {
        private GameManager gameManager;
        private CountdownTimer countdownTimer;

        private GameCooldownLauncher(GameManager _gameManager, CountdownTimer _countdownTimer)
        {
            gameManager = _gameManager;
            countdownTimer = _countdownTimer;
            _countdownTimer.completed += StartGame;
        }

        private void StartGame()
        {
            gameManager.PlayingGame();
            countdownTimer.completed -= StartGame;
        }
    }
}

