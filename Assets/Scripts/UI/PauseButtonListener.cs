using UnityEngine.UI;

namespace ShootEmUp
{
    public class PauseButtonListener
    {
        private Button pauseButton;
        private GameManager gameManager;
        
        private PauseButtonListener(Button _pauseButton, GameManager _gameManager)
        {
            pauseButton = _pauseButton;
            gameManager = _gameManager;
            pauseButton.onClick.AddListener(Pause);
        }

        private void Pause()
        {
            gameManager.PauseGame();
        }
    }
}