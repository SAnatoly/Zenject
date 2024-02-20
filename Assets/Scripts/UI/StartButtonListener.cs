using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShootEmUp
{
    public class StartButtonListener
    {
        private Button startButton;
        private GameManager gameManager;
        
        private StartButtonListener(Button _startButton, GameManager _gameManager)
        {
            startButton = _startButton;
            gameManager = _gameManager;
            startButton.onClick.AddListener(StartTimer);
        }

        private void StartTimer()
        {
            //timer.StartCountdown();
            gameManager.StartGame();
            startButton.gameObject.SetActive(false);
            startButton.onClick.RemoveListener(StartTimer);
            
        }
    }
}