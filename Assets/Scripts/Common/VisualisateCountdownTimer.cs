using TMPro;
using UnityEngine;

namespace ShootEmUp
{
    public class VisualisateCountdownTimer: 
        IGameStartListener, 
        IGamePlayingListener
    {
        private CountdownTimer timer;
        private TMP_Text text;

        public VisualisateCountdownTimer(TMP_Text _text, CountdownTimer _timer)
        {
            timer = _timer;
            text = _text;
            timer.changeTime += UpdateText;
            text.text = timer.GetTime().ToString();
        }

        public void UpdateText()
        {
            text.text = timer.GetTime().ToString();
        }

        public void OnStart()
        {
            text.gameObject.SetActive(true);
        }

        public void OnPlaying()
        {
            text.gameObject.SetActive(false);
        }
    }
}