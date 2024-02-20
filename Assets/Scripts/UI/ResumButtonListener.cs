using UnityEngine.UI;

namespace ShootEmUp
{
    public class ResumButtonListener
    {
        private Button resumeButton;
        private GameManager gameManager;
        
        private ResumButtonListener(Button _resumeButton, GameManager _gameManager)
        {
            resumeButton = _resumeButton;
            gameManager = _gameManager;
            resumeButton.onClick.AddListener(Resume);
        }

        private void Resume()
        {
            //timer.StartCountdown();
            gameManager.PlayingGame();
            
            
        }
        
        
    }
}